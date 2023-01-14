using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Test_Process_Monitor
{
    public partial class frmMain_Report : Form
    {
        string mssql, db, user, pwd;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            try { 

                var grid = sender as DataGridView;
                int rowscount = grid.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {
                    string test_rsl = "";
                   
                    if (!(grid.Rows[i].Cells["Test_Result"].Value == null))
                    {
                        string trangthai = grid.Rows[i].Cells["Test_Result"].Value.ToString();
                        test_rsl = trangthai;


                        if (trangthai == "NG") { 
                            grid.Rows[i].Cells["Test_Result"].Style.BackColor = Color.OrangeRed;
                            grid.Rows[i].Cells["Test_Result"].Style.ForeColor = Color.White;
                            grid.Rows[i].Cells["Check_Result"].Style.BackColor = Color.OrangeRed;
                            grid.Rows[i].Cells["Check_Result"].Style.ForeColor = Color.White;
                        }
                        if (trangthai == "OK") { 
                            grid.Rows[i].Cells["Test_Result"].Style.BackColor = Color.LimeGreen;
                            grid.Rows[i].Cells["Check_Result"].Style.BackColor = Color.LimeGreen;
                        }
                    }

                    if (!(grid.Rows[i].Cells["Check_Result"].Value == null))
                    {
                        string Check_Result = grid.Rows[i].Cells["Check_Result"].Value.ToString();

                        if (Check_Result == "Not Found")
                        {
                            grid.Rows[i].Cells["Check_Result"].Style.BackColor = Color.Orange;
                            grid.Rows[i].Cells["Check_Result"].Style.ForeColor = Color.Black;

                        }
                        if (Check_Result == "Checked")
                        {
                            grid.Rows[i].Cells["Check_Result"].Value = test_rsl;
                        }
                        if (Check_Result == "")
                        {
                            string trangthai = grid.Rows[i].Cells["Test_Result"].Value.ToString();
                            if (trangthai != "NG")
                            {
                                grid.Rows[i].Cells["Check_Result"].Style.BackColor = Color.Gray;
                                grid.Rows[i].Cells["Check_Result"].Style.ForeColor = Color.White;
                                grid.Rows[i].Cells["Check_Result"].Value = "Waiting";
                            }
                            else
                                grid.Rows[i].Cells["Check_Result"].Style.BackColor = Color.White;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lúc binding");
                log.Error("Loi luc binding " + ex.ToString());
            }
        }

        private void frmMain_Monitor_Load(object sender, EventArgs e)
        {
            log.Error("Loi luc binding ");
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Press_F1);
            //set time fillter
            date2.Value= DateTime.Now;
            date1.Value= DateTime.Today.AddDays(-1);
            cbbLine.SelectedIndex = 0;
            cbbConfirmStatus.SelectedIndex = 0;
            

            //load setting
            try
            {
                mssql = Properties.Settings.Default.mssql;
                db = Properties.Settings.Default.db;
                user = Properties.Settings.Default.user;
                pwd = Properties.Settings.Default.pwd;

                if (mssql == "") { 
                    MessageBox.Show("Need setup Database config before use/ Khởi chạy lần đầu, cần cài đặt CSDL");
                    frmSetting setup = new frmSetting();
                    setup.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi trong qua trinh get setting");
                log.Error("Loi trong qua trinh get setting "+ex.ToString());
            }

        }

        //show setting windows
        void Press_F1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                frmSetting setup = new frmSetting();
                setup.ShowDialog();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btnExcel_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Chọn vị trí lưu file";
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "Report-Magnet-Test-Line-"+ cbbLine.Text +"-From "+ time1.Value.ToString("HH_mm")+ "_" + date1.Value.ToString("dd_MM_yyyy") + "-to-" + time2.Value.ToString("HH_mm") + " " + date2.Value.ToString("dd_MM_yyyy");
            // saveFileDialog1.de

            string FileURL = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                FileURL = saveFileDialog1.FileName;
            else
                return;
            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(FileURL))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            //export ra excel nhé
            try
            {
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Sheet1";
                // storing header part in Excel  
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                workbook.SaveAs(FileURL, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
               // app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void txtQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnSearch.PerformClick();

            }
        }

        public frmMain_Report()
        {
            InitializeComponent();
        }


        private void Update(string DieuKien)
        {
            //1 qerry
            // lọc lấy dữ liệu cần thiết
            //3// trình bày
            // Waiting: 0

            mssql = Properties.Settings.Default.mssql;
            db = Properties.Settings.Default.db;
            user = Properties.Settings.Default.user;
            pwd = Properties.Settings.Default.pwd;
            string line = "";



            string connetionString = "Data Source=" + mssql + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pwd;

            SqlDataReader dataReader = null;
            SqlCommand command;
            //so sánh thời gian để tạo sql
            int hientai = Int32.Parse(DateTime.Now.ToString("HH"));
            string sql = "";

            string t1 = date1.Text + " " + time1.Text;
            string t2 = date2.Text + " " + time2.Text;

            this.lblTimeRange.Text = "Data from: " + time1.Text + " " + date1.Value.ToString("dd/MM/yyyy") + " to: " + time2.Text + " " + date2.Value.ToString("dd/MM/yyyy");

            sql = String.Format("SELECT ISNULL(Time1,'1999-01-01'),ISNULL(Status1,'null'),ISNULL(Time2,'1999-01-01'),ISNULL(Status2,'null')  FROM Logs WHERE {0}", DieuKien);

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
                
                MessageBox.Show("Lỗi khi đọc total kết quả từ CSDL, !" + ex.ToString());
                log.Error("Lỗi khi đọc total kết quả từ CSDL, vui lòng kiểm tra cài đặt -> " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            mssql = Properties.Settings.Default.mssql;
            db = Properties.Settings.Default.db;
            user = Properties.Settings.Default.user;
            pwd = Properties.Settings.Default.pwd;

            SqlDataReader dataReader = null;
            SqlCommand command;
            DataTable kq = new DataTable();
            string connetionString = "Data Source=" + mssql +";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pwd;

            //Dk here
            string t1 = date1.Text + " " + time1.Text;
            string t2 = date2.Text + " " + time2.Text;
            string line = "";
            string stt2 = "";
            string qr = "";



            //Bộ lọc ở đây
            if (cbbLine.SelectedItem.ToString() != "All")
                line = " and Line='" + cbbLine.SelectedItem.ToString() + "'";


            /*
            * All
            OK Input + Waiting Output
            OK Input + OK Output
            NG Input + NG Output
            NG Input
            Not Found Output
            */
            if (cbbConfirmStatus.SelectedItem.ToString() != "All")
                stt2 = " and Status2='" + cbbConfirmStatus.SelectedItem.ToString()+"'";

            if (cbbConfirmStatus.SelectedItem.ToString() == "OK Input + Waiting Output")
                stt2 = " and Status1='OK' and Status2 is NULL";

            if (cbbConfirmStatus.SelectedItem.ToString() == "NG Input")
                stt2 = " and Status1='NG' and Status2 is NULL";

            if (cbbConfirmStatus.SelectedItem.ToString() == "OK Input + OK Output")
                stt2 = " and Status1='OK' and Status2 is NOT NULL";

            if (cbbConfirmStatus.SelectedItem.ToString() == "NG Input + NG Output")
                stt2 = " and Status1='NG' and Status2 is NOT NULL";

            if (cbbConfirmStatus.SelectedItem.ToString() == "Not Found Output")
                stt2 = " and Status2='Not Found'";

            if (txtQR.Text != "")
                //qr = " and QRCode LIKE '%Abastos%'";
                qr = string.Format("and QRCode LIKE '%{0}%'",txtQR.Text);
            // LIKE 'a%'


            string sql = String.Format("Select ROW_NUMBER() OVER(ORDER BY Id DESC) AS #,QRCode AS Code,Model,Line,FORMAT(Time1, 'HH:mm:ss dd/MM/yyyy') as Test_Time, Status1 as Test_Result, Error as Error_Details,FORMAT (Time2, 'HH:mm:ss dd/MM/yyyy') as [Check_Time],Status2 as Check_Result  FROM Logs WHERE (Time1 between '{0}' and '{1}' " +
                "or Time2 between '{0}' and '{1}') " + line+stt2+qr+ " ORDER BY Id DESC", t1,t2);

            string dieukien = String.Format(" (Time1 between '{0}' and '{1}' "+" or Time2 between '{0}' and '{1}') " + line + stt2 + qr + " ORDER BY Id DESC", t1, t2);
            SqlConnection connection = new SqlConnection(connetionString);//

            try{
                connection.Open();                   
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                kq.Load(dataReader);

                dataGridView1.DataSource = kq;
                dataGridView1.Columns[0].HeaderText = "#";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dataGridView1.Columns[8].Width = 300;
                this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataReader.Close();
                command.Dispose();
                this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                this.dataGridView1.ColumnHeadersHeight = 65;
                this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            }

            //if loi
            catch (Exception ex){
                MessageBox.Show("Error while read database !" + ex.ToString());
                log.Error("Error while read database !" + ex.ToString());
            }
            finally {
                connection.Close();
            }
            Update(dieukien);

        }
    }
}
