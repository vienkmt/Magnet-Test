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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtQR = new System.Windows.Forms.TextBox();
            this.lblnone = new System.Windows.Forms.Label();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.lblQR = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCOM = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnKQ = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort();
            this.lblSerial = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblinput = new System.Windows.Forms.Label();
            this.lblInputOK = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.lblOutputOK = new System.Windows.Forms.Label();
            this.lblTimeRange = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQR
            // 
            this.txtQR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQR.Location = new System.Drawing.Point(12, 89);
            this.txtQR.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtQR.Name = "txtQR";
            this.txtQR.Size = new System.Drawing.Size(1097, 32);
            this.txtQR.TabIndex = 0;
            this.txtQR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblnone
            // 
            this.lblnone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblnone.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnone.Location = new System.Drawing.Point(168, 0);
            this.lblnone.Name = "lblnone";
            this.lblnone.Size = new System.Drawing.Size(922, 33);
            this.lblnone.TabIndex = 3;
            this.lblnone.Text = "Waiting for scan...";
            this.lblnone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLogs
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtLogs, 2);
            this.txtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogs.Location = new System.Drawing.Point(3, 69);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(1087, 364);
            this.txtLogs.TabIndex = 4;
            this.txtLogs.TabStop = false;
            // 
            // lblQR
            // 
            this.lblQR.AutoSize = true;
            this.lblQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQR.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQR.Location = new System.Drawing.Point(168, 33);
            this.lblQR.Name = "lblQR";
            this.lblQR.Size = new System.Drawing.Size(922, 33);
            this.lblQR.TabIndex = 6;
            this.lblQR.Text = "QR";
            this.lblQR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQR.Visible = false;
            this.lblQR.Click += new System.EventHandler(this.lblQR_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(1336, 772);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 19);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "label1";
            this.lblInfo.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(147, 33);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click_1);
            // 
            // btnCOM
            // 
            this.btnCOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCOM.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOM.Location = new System.Drawing.Point(170, 3);
            this.btnCOM.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnCOM.Name = "btnCOM";
            this.btnCOM.Size = new System.Drawing.Size(140, 35);
            this.btnCOM.TabIndex = 88;
            this.btnCOM.TabStop = false;
            this.btnCOM.Text = "CONNECT";
            this.btnCOM.UseVisualStyleBackColor = true;
            this.btnCOM.Click += new System.EventHandler(this.btnCOM_Click_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnKQ
            // 
            this.btnKQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKQ.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKQ.Location = new System.Drawing.Point(3, 3);
            this.btnKQ.Name = "btnKQ";
            this.tableLayoutPanel2.SetRowSpan(this.btnKQ, 2);
            this.btnKQ.Size = new System.Drawing.Size(159, 60);
            this.btnKQ.TabIndex = 9;
            this.btnKQ.TabStop = false;
            this.btnKQ.Text = "Result";
            this.btnKQ.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(330, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(167, 35);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel Test";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.ReadTimeout = 100;
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
            this.serialPort1.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serialPort1_PinChanged);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.lblSerial, 3);
            this.lblSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Location = new System.Drawing.Point(3, 41);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(1084, 24);
            this.lblSerial.TabIndex = 6;
            this.lblSerial.Text = "Serial Stt";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1097, 70);
            this.tableLayoutPanel1.TabIndex = 89;
            // 
            // lblinput
            // 
            this.lblinput.AutoSize = true;
            this.lblinput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblinput.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinput.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblinput.Location = new System.Drawing.Point(4, 1);
            this.lblinput.Name = "lblinput";
            this.lblinput.Size = new System.Drawing.Size(358, 33);
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
            this.lblInputOK.Location = new System.Drawing.Point(4, 35);
            this.lblInputOK.Name = "lblInputOK";
            this.lblInputOK.Size = new System.Drawing.Size(358, 34);
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
            this.lblOutput.Location = new System.Drawing.Point(369, 1);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(358, 33);
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
            this.lblWaiting.Location = new System.Drawing.Point(734, 1);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(359, 33);
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
            this.lblOutputOK.Location = new System.Drawing.Point(369, 35);
            this.lblOutputOK.Name = "lblOutputOK";
            this.lblOutputOK.Size = new System.Drawing.Size(358, 34);
            this.lblOutputOK.TabIndex = 3;
            this.lblOutputOK.Text = "OK: 0     NG: 0     Not Found: 0";
            this.lblOutputOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeRange
            // 
            this.lblTimeRange.AutoSize = true;
            this.lblTimeRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeRange.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRange.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTimeRange.Location = new System.Drawing.Point(734, 35);
            this.lblTimeRange.Name = "lblTimeRange";
            this.lblTimeRange.Size = new System.Drawing.Size(359, 34);
            this.lblTimeRange.TabIndex = 5;
            this.lblTimeRange.Text = "Data from 00:00:00 to 00:00:00";
            this.lblTimeRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.15152F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.84848F));
            this.tableLayoutPanel2.Controls.Add(this.txtLogs, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnKQ, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblnone, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblQR, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 126);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1093, 436);
            this.tableLayoutPanel2.TabIndex = 90;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 770F));
            this.tableLayoutPanel3.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCOM, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblSerial, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 568);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.76812F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.23188F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(947, 65);
            this.tableLayoutPanel3.TabIndex = 91;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(966, 575);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 31);
            this.button1.TabIndex = 92;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 645);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtQR);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Magnet Test V1.4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtQR;
        private System.Windows.Forms.Label lblnone;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label lblQR;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnCOM;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnKQ;
        private System.Windows.Forms.Button btnCancel;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblSerial;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblinput;
        private System.Windows.Forms.Label lblInputOK;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Label lblOutputOK;
        private System.Windows.Forms.Label lblTimeRange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
    }
}

