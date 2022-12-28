using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Logger
{
    public partial class Form1 : Form
    {
        string mssql, db, user, pwd;
        int line = 0;
        int sum = 0;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                //lblInfo.Text = txtQR.Text;
                mssql = Properties.Settings.Default.mssql;
                db = Properties.Settings.Default.DB;
                user = Properties.Settings.Default.user;
                pwd = Properties.Settings.Default.pwd;
                line = Properties.Settings.Default.line + 1;
                //model = Properties.Settings.Default.model;
                SqlDataReader dataReader = null;
                lblQR.Visible = true;
                //lblketqua.Visible = true;
                SqlCommand command;
                string connetionString = "Data Source=" + mssql + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pwd;
                string sql = String.Format("SELECT TOP(1) Id,Status1 FROM Logs WHERE QRCode='{0}' AND Time1 IS NOT NULL", txtQR.Text);
                SqlConnection connection = new SqlConnection(connetionString);

                try
                {
                    connection.Open();
                    btnKQ.Visible= true;
                    DateTime now = DateTime.Now;
                    string kq = "";
                    ++sum;
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    kq = sum + " - " + now + " - [OK PASS] - " + txtQR.Text + "\r\n";
                    string stt = "";
                    string sql_new = "";
                    //Nếu thấy bản ghi thì show ra OK hay NG, rồi update - checked ok
                    if (dataReader.HasRows){

                        while (dataReader.Read())
                        {
                            stt = dataReader.GetString(1);
                        }


                        btnKQ.Text = "FOUND - "+stt;
                        btnKQ.BackColor = Color.LimeGreen;
                        btnKQ.ForeColor = Color.White;
                        sql_new = String.Format("UPDATE Logs SET Time2 = getdate(), Status2='Checked' WHERE QRCode ='{0}';", txtQR.Text);

                    }
                    else
                    {
                        btnKQ.Text = "NOT FOUND";
                        btnKQ.BackColor = Color.Red;
                        btnKQ.ForeColor = Color.White;
                        kq = sum + " - " + now + " - Not Found - " + txtQR.Text + "\r\n";
                        // SQL insert
                        sql_new = String.Format("INSERT INTO Logs(QRCode,Time2,Status2,Line) VALUES ('{0}',getdate(),'Not Found','{1}')", txtQR.Text, line);
                    }
                    dataReader.Close();
                    command.Dispose();
                    //cuối cùng vẫn cứ là query 
                    command = new SqlCommand(sql_new, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
            

                    txtLogs.AppendText(kq);
                    lblQR.Text = "QR Code: " + txtQR.Text + " - " + now.ToLongTimeString();
                    dataReader.Close();
                    command.Dispose();

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


        private void Form1_Load(object sender, EventArgs e)
        {
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
    }
}
