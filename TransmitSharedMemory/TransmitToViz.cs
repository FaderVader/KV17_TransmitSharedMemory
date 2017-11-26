using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace TransmitSharedMemory
{
    public partial class TransmitToViz : Form
    {  
        SendToSMM SendCollection;
        public TransmitToViz()
        {
            InitializeComponent();
            SendCollection = new SendToSMM();
            
        }

        private void UpdateListBox()
        {
            txtResponse.Text = "";
            lbxAllRegisteredDestinations.Items.Clear();
            foreach (SendViaTcp connection in SendCollection.tcpHostsPublic)
            {
                lbxAllRegisteredDestinations.Items.Add(connection.host + ":" + connection.port);
            }
            txtResponse.Text = SendCollection.receivedString;
        }

        private void addHost_Click(object sender, EventArgs e)
        {
            SendCollection.AddTcpHost(tbHost.Text);
            UpdateListBox();            
        }

        private void RemoveHost_Click(object sender, EventArgs e)
        {
            SendCollection.RemoveTcpHost(tbHost.Text);
            UpdateListBox();
        }

        private void sendInt_Click(object sender, EventArgs e)
        {
            SendCollection.Send(tbIntKey.Text, Convert.ToInt16(tbIntVal.Text));
        }

        private void seriesInt_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                SendCollection.Send(tbIntKey.Text + Convert.ToString(i), Convert.ToInt16(tbIntVal.Text) + i);
                Thread.Sleep(30);
            }
        }


        private void sendDbl_Click(object sender, EventArgs e)
        {
            SendCollection.Send(tbDblKey.Text, Convert.ToDouble(tbDblVal.Text));
        }

        private void precDbl_Click(object sender, EventArgs e)
        {
            SendCollection.Send(tbDblKey.Text, Convert.ToDouble(tbDblVal.Text), 2);
        }

        private void sendStr_Click(object sender, EventArgs e)
        {
            SendCollection.Send(tbStrKey.Text, tbStrVal.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendCollection.Cleanup();
        }

    }
}
