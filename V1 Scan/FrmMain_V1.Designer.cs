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
            this.lblketqua = new System.Windows.Forms.Label();
            this.lblQR = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCOM = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnKQ = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblSerial = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtQR
            // 
            this.txtQR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQR.Location = new System.Drawing.Point(12, 65);
            this.txtQR.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtQR.Name = "txtQR";
            this.txtQR.Size = new System.Drawing.Size(1263, 32);
            this.txtQR.TabIndex = 0;
            this.txtQR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblnone
            // 
            this.lblnone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnone.Font = new System.Drawing.Font("Segoe UI Semibold", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnone.Location = new System.Drawing.Point(12, 9);
            this.lblnone.Name = "lblnone";
            this.lblnone.Size = new System.Drawing.Size(1276, 52);
            this.lblnone.TabIndex = 3;
            this.lblnone.Text = "Waiting for scan...";
            this.lblnone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogs.Location = new System.Drawing.Point(12, 218);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(1263, 603);
            this.txtLogs.TabIndex = 4;
            // 
            // lblketqua
            // 
            this.lblketqua.AutoSize = true;
            this.lblketqua.Font = new System.Drawing.Font("Segoe UI Semibold", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblketqua.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblketqua.Location = new System.Drawing.Point(1133, 853);
            this.lblketqua.Name = "lblketqua";
            this.lblketqua.Size = new System.Drawing.Size(55, 25);
            this.lblketqua.TabIndex = 5;
            this.lblketqua.Text = "PASS";
            this.lblketqua.Visible = false;
            // 
            // lblQR
            // 
            this.lblQR.AutoSize = true;
            this.lblQR.Font = new System.Drawing.Font("Segoe UI Semibold", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQR.Location = new System.Drawing.Point(282, 149);
            this.lblQR.Name = "lblQR";
            this.lblQR.Size = new System.Drawing.Size(38, 25);
            this.lblQR.TabIndex = 6;
            this.lblQR.Text = "QR";
            this.lblQR.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(1336, 813);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 20);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "label1";
            this.lblInfo.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 837);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 30);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click_1);
            // 
            // btnCOM
            // 
            this.btnCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOM.Location = new System.Drawing.Point(236, 837);
            this.btnCOM.Name = "btnCOM";
            this.btnCOM.Size = new System.Drawing.Size(227, 53);
            this.btnCOM.TabIndex = 88;
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
            this.btnKQ.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKQ.Location = new System.Drawing.Point(12, 133);
            this.btnKQ.Name = "btnKQ";
            this.btnKQ.Size = new System.Drawing.Size(241, 76);
            this.btnKQ.TabIndex = 9;
            this.btnKQ.Text = "PASS";
            this.btnKQ.UseVisualStyleBackColor = true;
            this.btnKQ.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(485, 838);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(239, 52);
            this.btnCancel.TabIndex = 10;
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
            this.lblSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Location = new System.Drawing.Point(17, 894);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(65, 17);
            this.lblSerial.TabIndex = 6;
            this.lblSerial.Text = "Serial Stt";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(948, 853);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 48);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 937);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnKQ);
            this.Controls.Add(this.btnCOM);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblQR);
            this.Controls.Add(this.lblketqua);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.lblnone);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtQR);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Magnet Test V1.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtQR;
        private System.Windows.Forms.Label lblnone;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label lblketqua;
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
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

