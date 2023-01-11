using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Logger
{
    public partial class Form1 : Form
    {
        string mssql, db, user, pwd;
        string kqq = "";
        int line = 0;
        int sum = 0;
        delegate void SetTextCallback(string text); // Khai bao delegate SetTextCallBack voi tham so string
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            InitializeComponent();
        }
        #region "Nếu qr code được bắn"
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                lblnone.Text="Waiting for scan...";
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("Chưa kết nối COM hoặc bị ngắt kết nối");
                    log.Error("Chưa kết nối COM");
                    txtQR.Clear();
                    txtQR.Focus();
                    return;
                }
                if (txtQR.TextLength < 24)
                {
                    lblnone.Text = "Skip...";
                    txtQR.Clear();
                    txtQR.Focus();
                    return;
                }


                btnKQ.Text = "Waiting...";
                btnKQ.BackColor = Color.LightGray;
                btnKQ.ForeColor = Color.DarkGray;

                mssql = Properties.Settings.Default.mssql;
                db = Properties.Settings.Default.DB;
                user = Properties.Settings.Default.user;
                pwd = Properties.Settings.Default.pwd;
                line = Properties.Settings.Default.line + 1;

                SqlDataReader dataReader = null;
                lblQR.Visible = true;
                SqlCommand command;
                string connetionString = "Data Source=" + mssql + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pwd;
                string sql = String.Format("SELECT TOP(1) Id,Status1 FROM Logs WHERE QRCode='{0}' AND Time1 IS NOT NULL ORDER BY Id DESC", txtQR.Text);
                SqlConnection connection = new SqlConnection(connetionString);

                try
                {
                    connection.Open();
                    btnKQ.Visible = true;
                    DateTime now = DateTime.Now;
                    string kq = "";
                    ++sum;
                    bool status = false;
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    //kq = sum + " - " + now + " - [OK PASS] - " + txtQR.Text + "\r\n";
                    string stt = "";
                    string sql_new = "";
                    //Nếu thấy bản ghi thì show ra OK hay NG, rồi update - checked ok
                    if (dataReader.HasRows)
                    {

                        while (dataReader.Read())
                        {
                            stt = dataReader.GetString(1);
                        }

                        if (stt == "OK")
                        {
                            btnKQ.BackColor = Color.LimeGreen;
                            btnKQ.ForeColor = Color.White;
                            kq = sum + " - " + now + " - OK - " + txtQR.Text + "\r\n";
                            status = true;
                        }
                        if (stt == "NG")
                        {
                            btnKQ.BackColor = Color.Red;
                            btnKQ.ForeColor = Color.White;
                            kq = sum + " - " + now + " - NG - " + txtQR.Text + "\r\n";
                        }


                        btnKQ.Text = stt;
                        sql_new = String.Format("UPDATE Logs SET Time2 = getdate(), Status2='Checked' WHERE QRCode ='{0}';", txtQR.Text);

                    }
                    else
                    {
                        btnKQ.Text = "Not Found";
                        btnKQ.BackColor = Color.Red;
                        btnKQ.ForeColor = Color.White;
                        kq = sum + " - " + now + " - Not Found - " + txtQR.Text + "\r\n";
                        // SQL insert
                        sql_new = String.Format("INSERT INTO Logs(QRCode,Time2,Status2,Line) VALUES ('{0}',getdate(),'Not Found','{1}')", txtQR.Text, line);
                    }
                    timer4.Enabled = true;
                    dataReader.Close();
                    command.Dispose();
                    //cuối cùng vẫn cứ là query 
                    command = new SqlCommand(sql_new, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();


                    txtLogs.AppendText(kq);
                    lblQR.Text = "Code: " + txtQR.Text + " - " + now.ToLongTimeString();
                    dataReader.Close();
                    command.Dispose();

                    //Nếu bị NG thì gửi lệnh xuống COM
                    if (!status) { 
                        serialPort1.Write("CV_OFF");
                        Thread.Sleep(20);
                        serialPort1.Write("ON_SPK");
                        timer2.Enabled= true;

                      }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc CSDL, vui lòng kiểm tra cài đặt !" + ex.ToString());
                    log.Error("Lỗi khi đọc CSDL, vui lòng kiểm tra cài đặt -> "+ex.ToString());
                }
                finally
                {
                    txtQR.Clear();
                    txtQR.Focus();
                    connection.Close();
                }


            }
        }
        #endregion
        
        #region "Nếu kết nối COM"
        private void btnCOM_Click(object sender, EventArgs e)
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
        #endregion
        
        #region "Timer check COM"
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Nếu có lỗi trên cổng com thì
                if (!serialPort1.IsOpen)
                {

                    SetText("COM not connect or have an error");
                    btnCOM.Invoke(new Action(() =>
                    {
                        this.btnCOM.Text = "Connect";
                    }));

                    comboBox1.Invoke(new Action(() =>
                    {
                        this.comboBox1.Enabled = true;
                    }));

                }
                else
                {
                    serialPort1.Write("READ_STT");
                }
            }
            catch (Exception ex)
            {
                log.Error("Lỗi timer " + ex.ToString());
            }
        }
        #endregion

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

        private void SetText2(string text)
        {
            if (this.lblnone.InvokeRequired)
            {
                this.lblnone.BeginInvoke((MethodInvoker)delegate () { this.lblnone.Text = text; });
            }
            else
            {
                this.lblnone.Text = text;
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        #region "Nếu NG, sẽ check tình trạng cảm biến"
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Nếu bị enable
            //Tracking biến stt, nếu stt off -> send cv_on, spk_off, timer2.dis
          //  if(kqq== "SENSOR_OFF")
          //  {
           //     serialPort1.Write("CV_ON");
           //     Thread.Sleep(50);
           //     serialPort1.Write("OFF_SPK");
           //     SetText2("Waiting for scan...");
           // }
            //chờ được bật lại
          //  timer2.Enabled = false;

        }

        private void resetAlarm_Click(object sender, EventArgs e)
        {
            lblnone.Text = "Waiting for scan...";
            try
            {
                serialPort1.Write("CV_ON");
                Thread.Sleep(50);
                serialPort1.Write("OFF_SPK");
                timer2.Enabled = false;
            }
            catch
            {
                log.Error("Lỗi khi Reset Alarm");
            }
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {

        }

        private void lblnone_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1 qerry
            // lọc lấy dữ liệu cần thiết
            //3// trình bày

            mssql = Properties.Settings.Default.mssql;
            db = Properties.Settings.Default.DB;
            user = Properties.Settings.Default.user;
            pwd = Properties.Settings.Default.pwd;
            line = Properties.Settings.Default.line + 1;

            
            string connetionString = "Data Source=" + mssql + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pwd;

            SqlDataReader dataReader = null;
            SqlCommand command;
            //so sánh thời gian để tạo sql
            int hientai= Int32.Parse(DateTime.Now.ToString("HH"));
            string sql = "";
            string t1 = "";
            string t2 = "";

            if ((hientai>7) & (hientai<20))
            {
                //Lớn hơn 7h sáng và nhỏ hơn 20 giờ cùng ngày
                t1 = DateTime.Now.ToString("yyyy/MM/dd 08:00:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 19:59:00");
            }

            if (hientai >19)
            {
                //sẽ lấy từ 20h tới 23h59 cùng ngày
                t1 = DateTime.Now.ToString("yyyy/MM/dd 20:00:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 23:59:00");
            }

            if (hientai <8)
            {
                //20h của ngày hôm trước và 8h ngày hôm sau
                t1 = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd 20:00:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 07:59:00");  

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

                input = input_ok = input_ng = output= output_ok= output_ng= output_404= 0;
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
                        if(stt2!="null")
                        {
                            ++output;
                            if (stt2 == "OK")
                                ++output_ok;
                            if (stt2 == "NG")
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
                //Console.WriteLine(input);
                // Console.WriteLine(output_404);
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
                    this.lblInputOK.Text = "OK: " + input_ok + "  -  NG: " + input_ng;
                }));

                lblOutputOK.Invoke(new Action(() =>
                {
                    this.lblOutputOK.Text = "OK: " + output_ok + "  -  NG: " + output_ng + "     -  Not Found: " + output_404;
                }));

                dataReader.Close();
                command.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc total kết quả từ CSDL, vui lòng kiểm tra cài đặt !" + ex.ToString());
                log.Error("Lỗi khi đọc total kết quả từ CSDL, vui lòng kiểm tra cài đặt -> " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }


        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //1 qerry
            // lọc lấy dữ liệu cần thiết
            //3// trình bày

            mssql = Properties.Settings.Default.mssql;
            db = Properties.Settings.Default.DB;
            user = Properties.Settings.Default.user;
            pwd = Properties.Settings.Default.pwd;
            line = Properties.Settings.Default.line + 1;


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
                t2 = DateTime.Now.ToString("yyyy/MM/dd 19:59:00");
            }

            if (hientai > 19)
            {
                //sẽ lấy từ 20h tới 23h59 cùng ngày
                t1 = DateTime.Now.ToString("yyyy/MM/dd 20:00:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 23:59:00");
            }

            if (hientai < 8)
            {
                //20h của ngày hôm trước và 8h ngày hôm sau
                t1 = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd 20:00:00");
                t2 = DateTime.Now.ToString("yyyy/MM/dd 07:59:00");

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
                            if (stt2 == "OK")
                                ++output_ok;
                            if (stt2 == "NG")
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
                //Console.WriteLine(input);
                // Console.WriteLine(output_404);
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
                    this.lblInputOK.Text = "OK: " + input_ok + "  -  NG: " + input_ng;
                }));

                lblOutputOK.Invoke(new Action(() =>
                {
                    this.lblOutputOK.Text = "OK: " + output_ok + "  -  NG: " + output_ng + "     -  Not Found: " + output_404;
                }));

                dataReader.Close();
                command.Dispose();

            }
            catch (Exception ex)
            {
               // MessageBox.Show("Lỗi khi đọc total kết quả từ CSDL, vui lòng kiểm tra cài đặt !" + ex.ToString());
                log.Error("Lỗi khi đọc total kết quả từ CSDL, vui lòng kiểm tra cài đặt -> " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region "Nếu nhận được dữ liệu ở COM"
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            kqq = serialPort1.ReadLine();
            DateTime now = DateTime.Now;
            try
            {
                SetText("Connected " + serialPort1.PortName + now.ToString(". HH:mm:ss ") + kqq);
                
                if (kqq.Contains("CV_OFF_OK"))
                    SetText2("NG -> Conveyor stopped");
            }
            catch (Exception ex)
            {
                log.Error("Lỗi khi nhận or xử lí dữ liệu từ cổng COM " + ex.ToString());

            }
        }
        #endregion "Hết nhận dữ liệu COM"
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = SerialPort.GetPortNames();
                if (Properties.Settings.Default.mssql == "")
                {
                    MessageBox.Show("Đây là lần đầu tiên khởi chạy, vui lòng cài đặt các thông số cần thiết");
                    frmSetting setup = new frmSetting();
                    setup.ShowDialog();

                }

                txtQR.Focus();
                this.KeyPreview = true;
                this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            }
            catch (Exception ex)
            {
                log.Error("Lỗi Load FORM" + ex.ToString());
                //MessageBox.Show(ex.ToString());
            }
        }

        #region "Mở F1 Setting"
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                frmSetting setup = new frmSetting();
                setup.ShowDialog();
            }
        }
        #endregion
    }
}
