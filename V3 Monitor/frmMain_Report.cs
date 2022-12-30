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
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lúc binding");
                log.Error("Loi luc binding " + ex.ToString());
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

       
        public frmMain_Report()
        {
            InitializeComponent();
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
            if (cbbConfirmStatus.SelectedItem.ToString() != "All")
                stt2 = " and Status2='" + cbbConfirmStatus.SelectedItem.ToString()+"'";
            if (txtQR.Text != "")
                qr = " and QRCode='" + txtQR.Text + "'";
                


            string sql = String.Format("Select ROW_NUMBER() OVER(ORDER BY Id DESC) AS #,QRCode,Model,Line,FORMAT(Time1, 'HH:mm dd/MM/yyyy') as Test_Time, Status1 as Test_Result, Error as Error_Details,FORMAT (Time2, 'HH:mm dd/MM/yyyy') as [Check_Time],Status2 as Check_Result  FROM Logs WHERE (Time1 between '{0}' and '{1}' " +
                "or Time2 between '{0}' and '{1}') ORDER BY Id DESC" + line+stt2+qr,t1,t2);

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
            

        }
    }
}
