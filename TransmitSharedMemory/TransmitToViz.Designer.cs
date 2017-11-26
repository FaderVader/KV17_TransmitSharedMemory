namespace TransmitSharedMemory
// =============================================================================
//
//   Copyright 2013 Vizrt Austria GmbH
//   All Rights Reserved.
//
//   This is PROPRIETARY SOURCE CODE of Vizrt Austria GmbH
//   the contents of this file may not be disclosed to third parties, copied or
//   duplicated in any form, in whole or in part, without the prior written
//   permission of Vizrt Austria GmbH
//
//  =============================================================================

//namespace TestSendToSMM
{
    partial class TransmitToViz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbHost = new System.Windows.Forms.TextBox();
            this.addHost = new System.Windows.Forms.Button();
            this.sendInt = new System.Windows.Forms.Button();
            this.tbIntKey = new System.Windows.Forms.TextBox();
            this.tbIntVal = new System.Windows.Forms.TextBox();
            this.seriesInt = new System.Windows.Forms.Button();
            this.RemoveHost = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.sendDbl = new System.Windows.Forms.Button();
            this.tbDblKey = new System.Windows.Forms.TextBox();
            this.tbDblVal = new System.Windows.Forms.TextBox();
            this.precDbl = new System.Windows.Forms.Button();
            this.sendStr = new System.Windows.Forms.Button();
            this.tbStrKey = new System.Windows.Forms.TextBox();
            this.tbStrVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbxAllRegisteredDestinations = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(291, 72);
            this.tbHost.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(260, 38);
            this.tbHost.TabIndex = 0;
            this.tbHost.Text = "localhost";
            // 
            // addHost
            // 
            this.addHost.Location = new System.Drawing.Point(931, 69);
            this.addHost.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.addHost.Name = "addHost";
            this.addHost.Size = new System.Drawing.Size(200, 55);
            this.addHost.TabIndex = 2;
            this.addHost.Text = "Add";
            this.addHost.UseVisualStyleBackColor = true;
            this.addHost.Click += new System.EventHandler(this.addHost_Click);
            // 
            // sendInt
            // 
            this.sendInt.Location = new System.Drawing.Point(931, 420);
            this.sendInt.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sendInt.Name = "sendInt";
            this.sendInt.Size = new System.Drawing.Size(200, 55);
            this.sendInt.TabIndex = 2;
            this.sendInt.Text = "Send";
            this.sendInt.UseVisualStyleBackColor = true;
            this.sendInt.Click += new System.EventHandler(this.sendInt_Click);
            // 
            // tbIntKey
            // 
            this.tbIntKey.Location = new System.Drawing.Point(291, 422);
            this.tbIntKey.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbIntKey.Name = "tbIntKey";
            this.tbIntKey.Size = new System.Drawing.Size(260, 38);
            this.tbIntKey.TabIndex = 3;
            this.tbIntKey.Text = "intkey";
            // 
            // tbIntVal
            // 
            this.tbIntVal.Location = new System.Drawing.Point(611, 422);
            this.tbIntVal.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbIntVal.Name = "tbIntVal";
            this.tbIntVal.Size = new System.Drawing.Size(260, 38);
            this.tbIntVal.TabIndex = 4;
            this.tbIntVal.Text = "1234";
            // 
            // seriesInt
            // 
            this.seriesInt.Location = new System.Drawing.Point(1184, 420);
            this.seriesInt.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.seriesInt.Name = "seriesInt";
            this.seriesInt.Size = new System.Drawing.Size(200, 55);
            this.seriesInt.TabIndex = 5;
            this.seriesInt.Text = "Series";
            this.seriesInt.UseVisualStyleBackColor = true;
            this.seriesInt.Click += new System.EventHandler(this.seriesInt_Click);
            // 
            // RemoveHost
            // 
            this.RemoveHost.Location = new System.Drawing.Point(1184, 69);
            this.RemoveHost.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.RemoveHost.Name = "RemoveHost";
            this.RemoveHost.Size = new System.Drawing.Size(200, 55);
            this.RemoveHost.TabIndex = 6;
            this.RemoveHost.Text = "Remove";
            this.RemoveHost.UseVisualStyleBackColor = true;
            this.RemoveHost.Click += new System.EventHandler(this.RemoveHost_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(611, 72);
            this.tbPort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(260, 38);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "127.0.0.1";
            // 
            // sendDbl
            // 
            this.sendDbl.Location = new System.Drawing.Point(931, 489);
            this.sendDbl.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sendDbl.Name = "sendDbl";
            this.sendDbl.Size = new System.Drawing.Size(200, 55);
            this.sendDbl.TabIndex = 2;
            this.sendDbl.Text = "Send";
            this.sendDbl.UseVisualStyleBackColor = true;
            this.sendDbl.Click += new System.EventHandler(this.sendDbl_Click);
            // 
            // tbDblKey
            // 
            this.tbDblKey.Location = new System.Drawing.Point(291, 491);
            this.tbDblKey.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbDblKey.Name = "tbDblKey";
            this.tbDblKey.Size = new System.Drawing.Size(260, 38);
            this.tbDblKey.TabIndex = 3;
            this.tbDblKey.Text = "dblkey";
            // 
            // tbDblVal
            // 
            this.tbDblVal.Location = new System.Drawing.Point(611, 491);
            this.tbDblVal.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbDblVal.Name = "tbDblVal";
            this.tbDblVal.Size = new System.Drawing.Size(260, 38);
            this.tbDblVal.TabIndex = 4;
            this.tbDblVal.Text = "1234.56";
            // 
            // precDbl
            // 
            this.precDbl.Location = new System.Drawing.Point(1184, 489);
            this.precDbl.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.precDbl.Name = "precDbl";
            this.precDbl.Size = new System.Drawing.Size(200, 55);
            this.precDbl.TabIndex = 5;
            this.precDbl.Text = "####.##";
            this.precDbl.UseVisualStyleBackColor = true;
            this.precDbl.Click += new System.EventHandler(this.precDbl_Click);
            // 
            // sendStr
            // 
            this.sendStr.Location = new System.Drawing.Point(931, 558);
            this.sendStr.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sendStr.Name = "sendStr";
            this.sendStr.Size = new System.Drawing.Size(200, 55);
            this.sendStr.TabIndex = 2;
            this.sendStr.Text = "Send";
            this.sendStr.UseVisualStyleBackColor = true;
            this.sendStr.Click += new System.EventHandler(this.sendStr_Click);
            // 
            // tbStrKey
            // 
            this.tbStrKey.Location = new System.Drawing.Point(291, 560);
            this.tbStrKey.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbStrKey.Name = "tbStrKey";
            this.tbStrKey.Size = new System.Drawing.Size(260, 38);
            this.tbStrKey.TabIndex = 3;
            this.tbStrKey.Text = "strkey";
            // 
            // tbStrVal
            // 
            this.tbStrVal.Location = new System.Drawing.Point(611, 560);
            this.tbStrVal.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbStrVal.Name = "tbStrVal";
            this.tbStrVal.Size = new System.Drawing.Size(260, 38);
            this.tbStrVal.TabIndex = 4;
            this.tbStrVal.Text = "abc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 432);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Integer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 501);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Double";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 570);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "String";
            // 
            // lbxAllRegisteredDestinations
            // 
            this.lbxAllRegisteredDestinations.FormattingEnabled = true;
            this.lbxAllRegisteredDestinations.ItemHeight = 31;
            this.lbxAllRegisteredDestinations.Location = new System.Drawing.Point(291, 155);
            this.lbxAllRegisteredDestinations.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lbxAllRegisteredDestinations.Name = "lbxAllRegisteredDestinations";
            this.lbxAllRegisteredDestinations.Size = new System.Drawing.Size(580, 221);
            this.lbxAllRegisteredDestinations.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "List of dest";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(931, 155);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(453, 221);
            this.txtResponse.TabIndex = 10;
            // 
            // TransmitToViz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 703);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbxAllRegisteredDestinations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemoveHost);
            this.Controls.Add(this.tbStrVal);
            this.Controls.Add(this.precDbl);
            this.Controls.Add(this.tbDblVal);
            this.Controls.Add(this.tbStrKey);
            this.Controls.Add(this.seriesInt);
            this.Controls.Add(this.tbDblKey);
            this.Controls.Add(this.sendStr);
            this.Controls.Add(this.tbIntVal);
            this.Controls.Add(this.sendDbl);
            this.Controls.Add(this.tbIntKey);
            this.Controls.Add(this.sendInt);
            this.Controls.Add(this.addHost);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbHost);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "TransmitToViz";
            this.Text = "Transmit to Viz SHM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Button addHost;
        private System.Windows.Forms.Button sendInt;
        private System.Windows.Forms.TextBox tbIntKey;
        private System.Windows.Forms.TextBox tbIntVal;
        private System.Windows.Forms.Button seriesInt;
        private System.Windows.Forms.Button RemoveHost;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button sendDbl;
        private System.Windows.Forms.TextBox tbDblKey;
        private System.Windows.Forms.TextBox tbDblVal;
        private System.Windows.Forms.Button precDbl;
        private System.Windows.Forms.Button sendStr;
        private System.Windows.Forms.TextBox tbStrKey;
        private System.Windows.Forms.TextBox tbStrVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxAllRegisteredDestinations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResponse;
    }
}

