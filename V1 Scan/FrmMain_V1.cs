using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Collections.ObjectModel;

namespace Test_Logger
{
    public partial class Form1 : Form
    {
        string mssql, db, user, pwd, model;
        int line;
        int sum = 0;
        bool timeout = false;
        static string info = "";
        static string ketquaNG = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
              
        delegate void SetTextCallback(string text); // Khai bao delegate SetTextCallBack voi tham so string

        public Form1()
        {
            InitializeComponent();
            log4net.Config.BasicConfigurator.Configure();
        }

        //Sự kiện com lỗi
        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            
            log.Error("Lỗi COM serialPort1_ErrorReceived");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Console.WriteLine(info);
            lblnone.Invoke(new Action(() =>
            {
                this.lblnone.Text = "Waiting for test result...";
            }));

            //1. Nếu info k bằng wait thì cứ loop ở đây
            int timeout1 = 0; int timeout2 = 0;
            timeout = false;
            //timeout1 = 120000/50=2400 (2p), 
            while (info != "WAIT" && !timeout)       
            {
                Thread.Sleep(50);              
                if (++timeout1 > 2400)
                { 
                    timeout = true; 
                    break; 
                }
            }

            //2. Nếu bằng wait rồi thì ngồi chờ đổi sang NG or OK
            while (info== "WAIT" && !timeout)
            {
                Thread.Sleep(50);
                if (++timeout2 > 2400)
                {
                    timeout = true;
                    break;
                }
            }     
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (timeout) { 
                txtQR.Enabled = true;
                txtQR.Clear();
                txtQR.Focus();
                txtLogs.Enabled = true;
                this.lblnone.Text = "Waiting for other scan session...";
                timeout = false;
                return;
            }



            txtQR.Enabled = true;
            this.lblnone.Text = "Waiting for scan...";

            
            if ((info == "OK") || (info == "NG"))
            {
                Console.WriteLine("Found Result -> " + info);

                // lblInfo.Text = txtQR.Text;
                mssql = Properties.Settings.Default.mssql;
                db = Properties.Settings.Default.DB;
                user = Properties.Settings.Default.user;
                pwd = Properties.Settings.Default.pwd;
                line = Properties.Settings.Default.line;
                model = Properties.Settings.Default.model;

                //Disable tất cả các UI Đi, change txt, 
                //Chờ đợi gói tin từ cổng com
                //nếu có chứa từ WAIT thì bỏ qua
                //Nếu bắt gặp OK hay NG thì ngay lập tức gửi lên csdl, và quay lại chế độ chờ scan
                //Nếu chờ mãi k thấy thì cũng cancel quay lại chế độ scan
                //Nếu ấn nút huỷ thì cũng cancel

                SqlCommand command;
                string connetionString = "Data Source=" + mssql + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pwd;
                string sql = "";
                //lblketqua.Visible = true;
                btnKQ.Visible= true;
                lblQR.Visible = true;
                DateTime now = DateTime.Now;
                ++sum;
                string kq = "";
                if (info == "OK")
                {
                    btnKQ.Text = "PASS";
                    btnKQ.BackColor = Color.LimeGreen;
                    btnKQ.ForeColor = Color.White;
                    sql = String.Format("INSERT INTO Logs(QRCode,Model,Status1,Line,Time1) VALUES ('{0}','{1}','OK',{2},getdate())", txtQR.Text, model, line);
                    //lblketqua.ForeColor = Color.Green;
                    lblQR.Text = now.ToLongTimeString() + " - OK - " + txtQR.Text;
                    kq = sum + " - OK - " + now + " - " + txtQR.Text + "\r\n";
                }
                   
                if (info == "NG")
                {
                    //Nếu gặp NG, thì bóc tách chuỗi NG, tìm vị trí NG
                    string NG_Pos = "";
                    for(int i = 0; i < ketquaNG.Length; i++)
                    {
                        if (ketquaNG[i] == '1')
                            NG_Pos += (i+1).ToString() + '.';

                    }
                    //trim -
                    if(NG_Pos!="")
                        NG_Pos = NG_Pos.Remove(NG_Pos.Length - 1, 1);
                    
                    sql = String.Format("INSERT INTO Logs(QRCode,Model,Status1,Line,Time1,Error) VALUES ('{0}','{1}','NG',{2},getdate(),'{3}')", txtQR.Text, model, line,NG_Pos);
                    //lblketqua.Text = "NG";
                    btnKQ.BackColor = Color.Red;
                    btnKQ.ForeColor = Color.White;
                    btnKQ.Text = "NG";
                    lblQR.Text = now.ToLongTimeString() + " - NG - " + txtQR.Text;
                    kq = sum + " - NG - " + now + " - " + txtQR.Text + "\r\n";
                }
                    

                SqlConnection connection = new SqlConnection(connetionString);

                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    txtLogs.Enabled = true;
                    txtLogs.AppendText(kq);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm bản ghi mới vào CSDL, vui lòng kiểm tra cài đặt !" + ex.ToString());
                    log.Error("Lỗi khi thêm bản ghi mới vào CSDL: " + ex.ToString());
                }
                finally
                {
                    txtQR.Clear();
                    txtQR.Focus();
                    lblnone.Text = "Waiting for scan...";
                    connection.Close();
                    
                }

            }
            else
                {
                    txtQR.Clear();
                    txtQR.Focus();
                    MessageBox.Show("Can't get info");
                    log.Error("Can't get info");
            }    

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timeout = true;
        }

        //xử lý dữ liệu nhận được từ cổng COM comget
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string kqq = serialPort1.ReadLine();       
            DateTime now = DateTime.Now;
            try
            {
                ketquaNG = kqq.Split('#')[4];

                if (kqq.Contains("WAIT"))
                    info = "WAIT";
                if (kqq.Contains("NG"))
                    info = "NG";
                if (kqq.Contains("OK"))
                    info = "OK";

                Console.WriteLine(kqq.Trim('\r'));
                SetText("Connected "+serialPort1.PortName+now.ToString(". HH:mm:ss ")+kqq);
            }
            catch (Exception ex)
            {
                log.Error("Lỗi khi nhận or xử lí dữ liệu từ cổng COM "+ex.ToString());

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           // lblnone.Focus();
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("Chưa kết nối COM hoặc bị ngắt kết nối");
                    log.Error("Chưa kết nối COM");

                    txtQR.Clear();
                    txtQR.Focus();
                    return;
                }

                if (txtQR.TextLength<20)
                {
                    lblnone.Text = "Mã CN Code không hợp lệ, vui lòng scan lại...";
                    lblnone.ForeColor = Color.Red;
                    btnKQ.Text = "NG CN Code";
                    txtQR.Clear();
                    txtQR.Focus();
                    return;
                }



                btnCancel.Visible = true;
                txtLogs.Enabled = false;
                btnKQ.Text = "Waiting...";
                btnKQ.BackColor = Color.LightGray;
                btnKQ.ForeColor = Color.DarkGray;
                lblnone.Text = "Waiting for test result...";
                lblnone.ForeColor = Color.Black;
                txtQR.Enabled= false;
                timer2.Enabled = true;
                backgroundWorker1.RunWorkerAsync();

            }
        }



        private void Update()
        {
            //1 qerry
            // lọc lấy dữ liệu cần thiết
            //3// trình bày
            // Waiting: 0

            mssql = Properties.Settings.Default.mssql;
            db = Properties.Settings.Default.DB;
            user = Properties.Settings.Default.user;
            pwd = Properties.Settings.Default.pwd;
            line = Properties.Settings.Default.line;


            string connetionString = "Data Source=" + mssql + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pwd;

            SqlDataReader dataReader = null;
            SqlCommand command;
            //so sánh thời gian để tạo sql
            int hientai = Int32.Parse(DateTime.Now.ToString("HH"));
            string sql = "";
            string t1 = "";
            string t2 = "";

            if ((hientai > 7) & (hientai < 20))
            {
                //Lớn hơn 7h sáng và nhỏ hơn 20 giờ cùng ngày
                t1 = DateTime.Now.ToString("yyyy/MM/dd 08:00:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 19:50:59");
                lblTimeRange.Invoke(new Action(() =>
                {
                    this.lblTimeRange.Text = "Data from 08:00:00 to " + DateTime.Now.ToString("HH:mm:ss");
                }));

            }

            if (hientai > 19)
            {
                //sẽ lấy từ 20h tới 23h59 cùng ngày
                t1 = DateTime.Now.ToString("yyyy/MM/dd 19:51:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 23:59:59");
                lblTimeRange.Invoke(new Action(() =>
                {
                    this.lblTimeRange.Text = "Data from 20:00:00 to " + DateTime.Now.ToString("HH:mm:ss");
                }));
            }

            if (hientai < 8)
            {
                //20h của ngày hôm trước và 8h ngày hôm sau
                t1 = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd 20:00:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 07:50:00");
                lblTimeRange.Invoke(new Action(() =>
                {
                    this.lblTimeRange.Text = "Data from 20:00:00 to " + DateTime.Now.ToString("HH:mm:ss");
                }));
            }
            sql = String.Format("SELECT ISNULL(Time1,'1999-01-01'),ISNULL(Status1,'null'),ISNULL(Time2,'1999-01-01'),ISNULL(Status2,'null') FROM Logs WHERE (Time1 between '{0}' and '{1}' or Time2 between '{0}' and '{1}') AND Line={2}", t1, t2, line);
            SqlConnection connection = new SqlConnection(connetionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                string stt = "";
                int input, input_ok, input_ng;
                int output, output_ok, output_ng, output_404;

                input = input_ok = input_ng = output = output_ok = output_ng = output_404 = 0;
                if (dataReader.HasRows)
                {
                    //Có kết quả, bắt đầu đếm các số liệu cần thiết.
                    while (dataReader.Read())
                    {

                        string stt1 = dataReader.GetString(1);
                        string stt2 = dataReader.GetString(3);
                        string time1 = dataReader.GetDateTime(0).ToString();
                        string time2 = dataReader.GetDateTime(2).ToString();

                        if (stt1 != "null")
                        {
                            ++input;
                            if (stt1 == "OK")
                                ++input_ok;
                            if (stt1 == "NG")
                                ++input_ng;

                        }
                        if (stt2 != "null")
                        {
                            ++output;
                            if ((stt2 == "Checked") & (stt1 == "OK"))
                                ++output_ok;
                            if ((stt2 == "Checked") & (stt1 == "NG"))
                                ++output_ng;
                            if (stt2 == "Not Found")
                                ++output_404;
                        }
                    }
                }
                else
                {
                    //Không có dữ liệu, thì =0;
                }

                //Hiển thị dữ liệu nhé
                lblinput.Invoke(new Action(() =>
                {
                    this.lblinput.Text = "Total Input: " + input;
                }));
                lblOutput.Invoke(new Action(() =>
                {
                    this.lblOutput.Text = "Total Output: " + output;
                }));
                lblInputOK.Invoke(new Action(() =>
                {
                    this.lblInputOK.Text = "OK: " + input_ok + "     NG: " + input_ng;
                }));


                lblOutputOK.Invoke(new Action(() =>
                {
                    this.lblOutputOK.Text = "OK: " + output_ok + "     NG: " + output_ng + "     Not Found: " + output_404;
                }));
                lblWaiting.Invoke(new Action(() =>
                {
                    this.lblWaiting.Text = "Waiting: " + (input_ok - output_ok).ToString();

                }));
                dataReader.Close();
                command.Dispose();

            }
            catch (Exception ex)
            {
                timer2.Enabled = false;
                MessageBox.Show("Lỗi khi đọc total kết quả từ CSDL, !" + ex.ToString());  
                log.Error("Lỗi khi đọc total kết quả từ CSDL, vui lòng kiểm tra cài đặt -> " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
            //Quét các cổng Serial đang hoạt động lên ComboBox1
            //Cố gắng kết nối tới COM Port trước đó, nếu k ok thì bật ra màn hình setup
            try {
                comboBox1.DataSource = SerialPort.GetPortNames();
                txtQR.Focus();
                
                if (Properties.Settings.Default.mssql == "")
                {
                    MessageBox.Show("Đây là lần đầu tiên khởi chạy, vui lòng cài đặt các thông số cần thiết");
                    frmSetting setup = new frmSetting();
                    setup.ShowDialog();

                }

            }
            catch (Exception ex)
            {
                log.Error("Lỗi F1 Load "+ex.ToString());
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                this.KeyPreview = true;
                this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            }



        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                frmSetting setup = new frmSetting();
                setup.ShowDialog();
            }
        }


        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting setup = new frmSetting();
            setup.ShowDialog();
        }
        //Form đóng thì giải phóng COM đi nhé
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            log.Debug("serial new");
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
               // Thread.Sleep(100);
               // Console.WriteLine("-- wait ---");
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
        }

        private void lblQR_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void SetText(string text)
        {
            if (this.lblSerial.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else 
                this.lblSerial.Text = text;
        }

        //comsetup
        private void btnCOM_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtQR.Focus();
                
                //Nếu đang mở thì close đã
                if (serialPort1.IsOpen)
                    serialPort1.Close();

                // Nếu mở rồi thì Close, rồi -> Connect
                if (btnCOM.Text == "Disconnect")
                {
                    btnCOM.Text = "CONNECT";
                    comboBox1.Enabled = true;
                   // lblSerial.Visible = false;
                    return;
                }


                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();

                if (serialPort1.IsOpen)
                {
                    comboBox1.Enabled = false;
                    lblSerial.Visible = true;
                    lblSerial.Text = "Connected " + serialPort1.PortName;
                    btnCOM.Text = "Disconnect";
                }

            }
            catch
            {
                log.Error("Serial port " + comboBox1.Text + " opening error");
                MessageBox.Show("Serial port " + comboBox1.Text + " opening error");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try { 
                //Console.WriteLine(serialPort1.IsOpen);
                //Nếu có lỗi trên cổng com thì
                if (!serialPort1.IsOpen) {
                
                    SetText("COM not connect or have an error");
                    btnCOM.Invoke(new Action(() =>
                    {
                        this.btnCOM.Text = "CONNECT";
                    }));

                    comboBox1.Invoke(new Action(() =>
                    {
                        this.comboBox1.Enabled = true;
                    }));

                }
            }
            catch (Exception ex)
            {
                log.Error("Lỗi timer " + ex.ToString());
            }

        }

        //Khi click, sẽ load ra các COM đang hoạt động
        private void comboBox1_Click_1(object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
        }
    }
}
