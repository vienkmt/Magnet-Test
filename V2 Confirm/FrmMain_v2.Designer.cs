namespace Test_Logger
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
            this.resetAlarm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblinput = new System.Windows.Forms.Label();
            this.lblInputOK = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.lblOutputOK = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimeRange = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQR
            // 
            this.txtQR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQR.BackColor = System.Drawing.Color.GhostWhite;
            this.txtQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtQR.Location = new System.Drawing.Point(9, 96);
            this.txtQR.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtQR.Name = "txtQR";
            this.txtQR.Size = new System.Drawing.Size(863, 32);
            this.txtQR.TabIndex = 0;
            this.txtQR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblnone
            // 
            this.lblnone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblnone.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblnone.Location = new System.Drawing.Point(206, 0);
            this.lblnone.Name = "lblnone";
            this.lblnone.Size = new System.Drawing.Size(654, 40);
            this.lblnone.TabIndex = 3;
            this.lblnone.Text = "Waiting for scan...";
            this.lblnone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtLogs, 2);
            this.txtLogs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogs.Location = new System.Drawing.Point(3, 83);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(857, 256);
            this.txtLogs.TabIndex = 4;
            this.txtLogs.TabStop = false;
            // 
            // lblQR
            // 
            this.lblQR.AutoSize = true;
            this.lblQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQR.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQR.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblQR.Location = new System.Drawing.Point(206, 40);
            this.lblQR.Name = "lblQR";
            this.lblQR.Size = new System.Drawing.Size(654, 40);
            this.lblQR.TabIndex = 6;
            this.lblQR.Text = "CN Code";
            this.lblQR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnKQ
            // 
            this.btnKQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKQ.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKQ.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnKQ.Location = new System.Drawing.Point(3, 3);
            this.btnKQ.Name = "btnKQ";
            this.tableLayoutPanel2.SetRowSpan(this.btnKQ, 2);
            this.btnKQ.Size = new System.Drawing.Size(197, 74);
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
            this.comboBox1.Location = new System.Drawing.Point(11, 497);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 37);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.TabStop = false;
            // 
            // btnCOM
            // 
            this.btnCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCOM.Location = new System.Drawing.Point(146, 496);
            this.btnCOM.Name = "btnCOM";
            this.btnCOM.Size = new System.Drawing.Size(140, 39);
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
            this.lblSerial.Location = new System.Drawing.Point(7, 539);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(45, 20);
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
            // resetAlarm
            // 
            this.resetAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetAlarm.Location = new System.Drawing.Point(600, 498);
            this.resetAlarm.Name = "resetAlarm";
            this.resetAlarm.Size = new System.Drawing.Size(122, 39);
            this.resetAlarm.TabIndex = 11;
            this.resetAlarm.TabStop = false;
            this.resetAlarm.Text = "Reset Alarm";
            this.resetAlarm.UseVisualStyleBackColor = true;
            this.resetAlarm.Click += new System.EventHandler(this.resetAlarm_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(729, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 39);
            this.button1.TabIndex = 12;
            this.button1.TabStop = false;
            this.button1.Text = "View Statistics";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Ivory;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lblinput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInputOK, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOutput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWaiting, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOutputOK, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeRange, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 74);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lblinput
            // 
            this.lblinput.AutoSize = true;
            this.lblinput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblinput.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinput.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblinput.Location = new System.Drawing.Point(4, 1);
            this.lblinput.Name = "lblinput";
            this.lblinput.Size = new System.Drawing.Size(280, 35);
            this.lblinput.TabIndex = 0;
            this.lblinput.Text = "Total Input: 0";
            this.lblinput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInputOK
            // 
            this.lblInputOK.AutoSize = true;
            this.lblInputOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputOK.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInputOK.Location = new System.Drawing.Point(4, 37);
            this.lblInputOK.Name = "lblInputOK";
            this.lblInputOK.Size = new System.Drawing.Size(280, 36);
            this.lblInputOK.TabIndex = 2;
            this.lblInputOK.Text = "OK:0     NG: 0";
            this.lblInputOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutput.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblOutput.Location = new System.Drawing.Point(291, 1);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(280, 35);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Total Output: 0";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWaiting.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblWaiting.Location = new System.Drawing.Point(578, 1);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(281, 35);
            this.lblWaiting.TabIndex = 4;
            this.lblWaiting.Text = "Waiting: 0";
            this.lblWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOutputOK
            // 
            this.lblOutputOK.AutoSize = true;
            this.lblOutputOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputOK.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblOutputOK.Location = new System.Drawing.Point(291, 37);
            this.lblOutputOK.Name = "lblOutputOK";
            this.lblOutputOK.Size = new System.Drawing.Size(280, 36);
            this.lblOutputOK.TabIndex = 3;
            this.lblOutputOK.Text = "OK: 0     NG: 0     Not Found: 0";
            this.lblOutputOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer4
            // 
            this.timer4.Interval = 2000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblnone, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblQR, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnKQ, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLogs, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 140);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(863, 342);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // lblTimeRange
            // 
            this.lblTimeRange.AutoSize = true;
            this.lblTimeRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeRange.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRange.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTimeRange.Location = new System.Drawing.Point(578, 37);
            this.lblTimeRange.Name = "lblTimeRange";
            this.lblTimeRange.Size = new System.Drawing.Size(281, 36);
            this.lblTimeRange.TabIndex = 5;
            this.lblTimeRange.Text = "Data from 08:00:00 to 20:00:00";
            this.lblTimeRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resetAlarm);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.btnCOM);
            this.Controls.Add(this.comboBox1);
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.Button resetAlarm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblinput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInputOK;
        private System.Windows.Forms.Label lblOutputOK;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTimeRange;
    }
}
