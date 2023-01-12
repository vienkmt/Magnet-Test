﻿namespace Test_Logger
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtQR = new System.Windows.Forms.TextBox();
            this.lblnone = new System.Windows.Forms.Label();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.lblQR = new System.Windows.Forms.Label();
            this.btnKQ = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCOM = new System.Windows.Forms.Button();
            this.lblSerial = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.resetAlarm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblinput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInputOK = new System.Windows.Forms.Label();
            this.lblOutputOK = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQR
            // 
            this.txtQR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQR.Location = new System.Drawing.Point(13, 107);
            this.txtQR.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtQR.Name = "txtQR";
            this.txtQR.Size = new System.Drawing.Size(1065, 56);
            this.txtQR.TabIndex = 0;
            this.txtQR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblnone
            // 
            this.lblnone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnone.Font = new System.Drawing.Font("Segoe UI Semibold", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnone.Location = new System.Drawing.Point(234, 176);
            this.lblnone.Name = "lblnone";
            this.lblnone.Size = new System.Drawing.Size(818, 41);
            this.lblnone.TabIndex = 3;
            this.lblnone.Text = "Waiting for scan...";
            this.lblnone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogs.Location = new System.Drawing.Point(10, 234);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(1069, 429);
            this.txtLogs.TabIndex = 4;
            this.txtLogs.TabStop = false;
            // 
            // lblQR
            // 
            this.lblQR.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblQR.AutoSize = true;
            this.lblQR.Font = new System.Drawing.Font("Segoe UI Semibold", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQR.Location = new System.Drawing.Point(536, 684);
            this.lblQR.Name = "lblQR";
            this.lblQR.Size = new System.Drawing.Size(116, 50);
            this.lblQR.TabIndex = 6;
            this.lblQR.Text = "Code:";
            this.lblQR.Visible = false;
            // 
            // btnKQ
            // 
            this.btnKQ.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKQ.Location = new System.Drawing.Point(10, 160);
            this.btnKQ.Name = "btnKQ";
            this.btnKQ.Size = new System.Drawing.Size(218, 62);
            this.btnKQ.TabIndex = 7;
            this.btnKQ.TabStop = false;
            this.btnKQ.Text = "Result";
            this.btnKQ.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 685);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 63);
            this.comboBox1.TabIndex = 8;
            // 
            // btnCOM
            // 
            this.btnCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCOM.Location = new System.Drawing.Point(171, 684);
            this.btnCOM.Name = "btnCOM";
            this.btnCOM.Size = new System.Drawing.Size(151, 39);
            this.btnCOM.TabIndex = 9;
            this.btnCOM.TabStop = false;
            this.btnCOM.Text = "Connect";
            this.btnCOM.UseVisualStyleBackColor = true;
            this.btnCOM.Click += new System.EventHandler(this.btnCOM_Click);
            // 
            // lblSerial
            // 
            this.lblSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(7, 731);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(91, 37);
            this.lblSerial.TabIndex = 10;
            this.lblSerial.Text = "COM";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // resetAlarm
            // 
            this.resetAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetAlarm.Location = new System.Drawing.Point(900, 686);
            this.resetAlarm.Name = "resetAlarm";
            this.resetAlarm.Size = new System.Drawing.Size(179, 39);
            this.resetAlarm.TabIndex = 11;
            this.resetAlarm.TabStop = false;
            this.resetAlarm.Text = "Reset Alarm";
            this.resetAlarm.UseVisualStyleBackColor = true;
            this.resetAlarm.Click += new System.EventHandler(this.resetAlarm_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(684, 686);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 39);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.6408F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.3592F));
            this.tableLayoutPanel1.Controls.Add(this.lblinput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOutput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInputOK, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOutputOK, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1065, 88);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lblinput
            // 
            this.lblinput.AutoSize = true;
            this.lblinput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinput.Location = new System.Drawing.Point(3, 0);
            this.lblinput.Name = "lblinput";
            this.lblinput.Size = new System.Drawing.Size(288, 44);
            this.lblinput.TabIndex = 0;
            this.lblinput.Text = "Total Input: 0";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(297, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(765, 44);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Total Output: 0";
            // 
            // lblInputOK
            // 
            this.lblInputOK.AutoSize = true;
            this.lblInputOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputOK.Location = new System.Drawing.Point(3, 44);
            this.lblInputOK.Name = "lblInputOK";
            this.lblInputOK.Size = new System.Drawing.Size(288, 44);
            this.lblInputOK.TabIndex = 2;
            this.lblInputOK.Text = "OK:0  - NG: 0";
            // 
            // lblOutputOK
            // 
            this.lblOutputOK.AutoSize = true;
            this.lblOutputOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputOK.Location = new System.Drawing.Point(297, 44);
            this.lblOutputOK.Name = "lblOutputOK";
            this.lblOutputOK.Size = new System.Drawing.Size(765, 44);
            this.lblOutputOK.TabIndex = 3;
            this.lblOutputOK.Text = "OK: 0    - NG: 0  - Not Found: 0";
            // 
            // timer4
            // 
            this.timer4.Interval = 3000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 760);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resetAlarm);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.btnCOM);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnKQ);
            this.Controls.Add(this.lblQR);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.lblnone);
            this.Controls.Add(this.txtQR);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "V2 - Magnet Test Confirm 1.2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtQR;
        private System.Windows.Forms.Label lblnone;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label lblQR;
        private System.Windows.Forms.Button btnKQ;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnCOM;
        private System.Windows.Forms.Label lblSerial;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button resetAlarm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblinput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInputOK;
        private System.Windows.Forms.Label lblOutputOK;
        private System.Windows.Forms.Timer timer4;
    }
}
