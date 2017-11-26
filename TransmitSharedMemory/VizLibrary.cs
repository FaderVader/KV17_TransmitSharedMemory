using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TransmitSharedMemory
{
    
    // SendToSMM handles a pool of hosts connected either via tcpip or udp
    // key|value data is transmitted to these hosts using separate threads
    // mfaulty connections or dead viz syste.ms will influence the data transfer to the other hosts
    public class SendToSMM
    {
        public static List<SendViaTcp> tcphosts = new List<SendViaTcp>();
        static List<SendViaUdp> udphosts = new List<SendViaUdp>();
        public string receivedString;
        public SendToSMM()
        {            
        }

        public List<SendViaTcp> tcpHostsPublic { get { return tcphosts; }  } //added to expose in listbox

        // adds a host to the tcpip host list. if 0 was used for the port this method will try to estalish
        // a viz command interface (using communication port commPort) and query viz for the tcpip port used for shared memory
        public void AddTcpHost(string host, int port, int commPort)
        {
            bool found = false;
            // check if the host is already in the list
            foreach (SendViaTcp tcphost in tcphosts)
            {
                found = (tcphost.host == host) || found;
            }
            // new host will be added port number 0 was specified
            if (!found && port == 0)
            {
                TcpClient tcpClient = new TcpClient();
                try
                {
                    tcpClient.Connect(host, commPort);
                }
                catch (SocketException /*e*/)
                {
                    tcpClient = null;
                }
                // if a connection could be made query viz for the smm tcpip port
                using (tcpClient)
                {
                    if (tcpClient != null && tcpClient.Connected)
                    {
                        byte[] recvBuffer = new byte[1024];
                        tcpClient.Client.Send(Encoding.UTF8.GetBytes("1 CONFIGURATION*COMMUNICATION*SMM_TCP_SERVICE GET\0"));
                        tcpClient.Client.Receive(recvBuffer);                                       

                        receivedString = Encoding.UTF8.GetString(recvBuffer).Substring(2);       // check the string version of data returned
                        string receivedBytes = BitConverter.ToString(recvBuffer);                // debugging: for inspecting the actual byte-array

                        try
                        {
                            port = Convert.ToInt32(receivedString);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not understand assigned port. \nValue returned was: " + receivedString);
                            port = 0;
                        }                                                                                                                       
                        tcpClient.Close();
                    } 
                }
            }
            // a new host will be added
            if (!found && port > 0)
            {
                tcphosts.Add(new SendViaTcp(host, port));
            }
        }

        public void AddTcpHost(string host, int port)
        {
            AddTcpHost(host, port, 6100);
        }

        public void AddTcpHost(string host)
        {
            AddTcpHost(host, 0, 6100);
        }
        public void RemoveTcpHost(string host)
        {
            SendViaTcp found = null;
            foreach (SendViaTcp tcphost in tcphosts)
            {
                if (tcphost.host == host)
                {
                    found = tcphost;
                }
            }
            if (found != null)
            {
                found.ExitThread();
                found.threaddone.WaitOne();
                tcphosts.Remove(found);
            }
        }


        // the implementation for udp host handling
        public void AddUdpHost(string host, int port, int commPort)
        {
            bool found = false;
            foreach (SendViaUdp udphost in udphosts)
            {
                found = (udphost.host == host) || found;
            }

            if (!found && port == 0)
            {
                TcpClient tcpClient = new TcpClient();
                try
                {
                    tcpClient.Connect(host, commPort);
                }
                catch (SocketException /*e*/)
                {
                    tcpClient = null;
                }
                if (tcpClient != null && tcpClient.Connected)
                {
                    byte[] recvBuffer = new byte[1024];
                    tcpClient.Client.Send(Encoding.UTF8.GetBytes("1 CONFIGURATION*COMMUNICATION*SMM_UDP_SERVICE GET\0"));
                    tcpClient.Client.Receive(recvBuffer);
                    port = Convert.ToInt16(Encoding.UTF8.GetString(recvBuffer).Substring(2));
                    tcpClient.Close();
                }
            }
            if (!found && port > 0)
            {
                udphosts.Add(new SendViaUdp(host, port));
            }
        }

        public void AddUdpHost(string host, int port)
        {
            AddUdpHost(host, port, 6100);
        }

        public void AddUdpHost(string host)
        {
            AddUdpHost(host, 0, 6100);
        }

        public void RemoveUdpHost(string host)
        {
            SendViaUdp found = null;
            foreach (SendViaUdp udphost in udphosts)
            {
                if (udphost.host == host)
                {
                    found = udphost;
                }
            }
            if (found != null)
            {
                found.ExitThread();
                found.threaddone.WaitOne();
                udphosts.Remove(found);
            }
        }


        // the main send routine. iterate over all tcp and udp hosts and add the new key|value pair to their send queue
        public void Send(string data)
        {
            foreach (SendViaTcp tcphost in tcphosts)
            {
                tcphost.AddToQeue(data);
            }

            foreach (SendViaUdp udphost in udphosts)
            {
                udphost.AddToQeue(data);
            }

        }

        private char GetHexDigit(uint i)
        {
            if (i <= 9)
                return Convert.ToChar(Convert.ToUInt32('0') + i);
            else
                return Convert.ToChar(Convert.ToUInt32('A') + i - 10);
        }

        // escapeString replaces unsafe ASCII characters with a "$" followed by two hexadecimal digits.
        private string escapeString(string s)
        {
            string returnStr = "";
            int i = 0;
            char a;

            for (i = 0; i < s.Length; ++i)
            {
                a = s[i];

                if (Char.IsLetterOrDigit(a) || a == '.' || a == '-' || a == '+')
                    returnStr += a;
                else
                {
                    uint digit = (uint)a;
                    returnStr += '$';
                    returnStr += GetHexDigit((digit >> 4) & 15u);
                    returnStr += GetHexDigit(digit & 15u);
                }
            }
            return returnStr;
        }

        // a few implemenations to make sending easier
        public void Send(string key, string val)
        {
            Send(key + "|" + escapeString(val));
        }
        public void Send(string key, int val)
        {
            string data = key + "|" + val.ToString();
            Send(data);
        }
        public void Send(string key, double val)
        {
            string data = key + "|" + val.ToString();
            Send(data);
        }

        public void Send(string key, double val, int precision)
        {
            string data = key + "|" + val.ToString("F" + precision.ToString());
            Send(data);
        }
        // we need to send a killthread to all hosts and wait until they report back to make sure we closed all sockets.
        public void Cleanup()
        {
            foreach (SendViaTcp tcphost in tcphosts)
            {
                tcphost.ExitThread();
                tcphost.threaddone.WaitOne();
            }
            tcphosts.Clear();

            foreach (SendViaUdp udphost in udphosts)
            {
                udphost.ExitThread();
                udphost.threaddone.WaitOne();
            }
            udphosts.Clear();
        }
    }


    // this call uses a worker thread to send key|value pairs to the shared memory of a viz engine via a tcpip connection
    public class SendViaTcp
    {
        public string host; // the destination host name
        public int port; // the destination port
        private Queue<string> dataqueue = new Queue<string>(); // the queue containting key|value paurs
        private ManualResetEvent newdata = new ManualResetEvent(false); // this even gets signaled when new data is inserted into the queue
        private ManualResetEvent exitthread = new ManualResetEvent(false); // signal this event to kill the thread. newdata must be set as well
        public ManualResetEvent threaddone = new ManualResetEvent(false); // this event gets signaled when the thread is done and the socket is closed

        // the worker thread which send the data to viz
        public void SendThreadProc()
        {
            TcpClient tcpClient;
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(host, port);
            }
            catch (SocketException /*e*/)
            {
                tcpClient = null;
            }
            // set the keep alive option for this socket
            tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            while (true)
            {
                // wait for new data to arrive
                newdata.WaitOne();
                if (exitthread.WaitOne(0))
                    break; //exit the thread when requested
                if (tcpClient == null)
                {
                    try
                    {
                        tcpClient = new TcpClient();
                        tcpClient.Connect(host, port);
                        tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                    }
                    catch (SocketException /*e*/)
                    {
                        // if something went wrong send the thread asleep for a little while
                        tcpClient = null;
                        Thread.Sleep(10);
                    }
                }
                // if the connection was succesful and there is data in the queue try sending
                while (tcpClient != null && tcpClient.Connected && dataqueue.Count > 0)
                {
                    newdata.Reset();
                    string top = dataqueue.Peek(); // take the top key|value pair from the queue
                    try
                    {
                        int ret = tcpClient.Client.Send(Encoding.UTF8.GetBytes(top + "\0"));
                        if (ret == Encoding.UTF8.GetBytes(top + "\0").Length)
                            dataqueue.Dequeue(); // only dequeue if sending was successful
                    }
                    catch (SocketException /*e*/)
                    {
                        tcpClient.Close();
                        tcpClient = null;
                        Thread.Sleep(10);
                    }
                }
            }
            threaddone.Set();
        }

        public SendViaTcp(string h, int p)
        {
            host = h;
            port = p;
            dataqueue = new Queue<string>();
            Thread t = new Thread(new ThreadStart(SendThreadProc));
            t.Start();
        }
        public void AddToQeue(string data)
        {
            dataqueue.Enqueue(data);
            newdata.Set();
        }
        public void ExitThread()
        {
            exitthread.Set();
            newdata.Set();
        }

    }

    // same as the class above, but uses udp to send the data
    class SendViaUdp
    {
        public string host; // the destination host
        public int port; // the desitnation port
        private Queue<string> dataqueue = new Queue<string>();
        private ManualResetEvent newdata = new ManualResetEvent(false);
        private ManualResetEvent exitthread = new ManualResetEvent(false);
        public ManualResetEvent threaddone = new ManualResetEvent(false);
        public void SendThreadProc()
        {
            IPAddress serverAddr = IPAddress.Parse(host);
            IPEndPoint endPoint = new IPEndPoint(serverAddr, port);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                                ProtocolType.Udp);
            while (true)
            {
                newdata.WaitOne();
                newdata.Reset();
                if (exitthread.WaitOne(0))
                    break;

                while (dataqueue.Count > 0)
                {
                    string top = dataqueue.Dequeue(); // dequeue all the time, as udp will not tell us whether the data arrived at the destination
                    sock.SendTo(Encoding.UTF8.GetBytes(top), endPoint);
                }
            }
            sock.Close();
            threaddone.Set();
        }

        public SendViaUdp(string h, int p)
        {
            host = h;
            port = p;
            dataqueue = new Queue<string>();
            Thread t = new Thread(new ThreadStart(SendThreadProc));
            t.Start();
        }
        public void AddToQeue(string data)
        {
            dataqueue.Enqueue(data);
            newdata.Set();
        }
        public void ExitThread()
        {
            exitthread.Set();
            newdata.Set();
        }

    }
}
