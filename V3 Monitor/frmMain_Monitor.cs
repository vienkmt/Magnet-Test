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
    public partial class frmMain_Monitor : Form
    {
        string mssql, db, user, pwd, line, model;

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            try { 

                var grid = sender as DataGridView;
                int rowscount = grid.Rows.Count;

                for (int i = 0; i < rowscount; i++)
                {

                    if (!(grid.Rows[i].Cells[4].Value == null))
                    {
                        string trangthai = grid.Rows[i].Cells["Ketqua"].Value.ToString();
                        if (trangthai == "NG") { 
                            grid.Rows[i].Cells["Ketqua"].Style.BackColor = Color.Red;
                        }
                        if (trangthai == "OK") { 
                            grid.Rows[i].Cells["Ketqua"].Style.BackColor = Color.LimeGreen;
                        }
                    }

                    if (!(grid.Rows[i].Cells[0].Value == null))
                        grid.Rows[i].Cells[0].Value = i + 1;

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("LOI luc bindding");
            }

        }

        private void frmMain_Monitor_Load(object sender, EventArgs e)
        {
            //txtQR.Focus();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Press_F1);
            //set time fillter
            date2.Value= DateTime.Now;
            date1.Value= DateTime.Today.AddDays(-1);

            //load setting
            try
            {
                mssql = Properties.Settings.Default.mssql;
                db = Properties.Settings.Default.db;
                user = Properties.Settings.Default.user;
                pwd = Properties.Settings.Default.pwd;

                if (mssql == "") { 
                    MessageBox.Show("Need setup Database config before use");
                    frmSetting setup = new frmSetting();
                    setup.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi trong qua trinh get setting");
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

        int sum = 0;
        public frmMain_Monitor()
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

            string sql = String.Format("Select Worker1,Serial,FORMAT (Time1, 'HH:mm dd/MM/yyyy') as Time1," +
                "FORMAT (Time2, 'HH:mm dd/MM/yyyy') as Time2,Model, IIF(Status1=1, 'OK', 'NG') as Ketqua,Status2  FROM Logs WHERE Time1 between '{0}' and '{1}' " +
                "or Time2 between '{0}' and '{1}'",t1,t2);
            SqlConnection connection = new SqlConnection(connetionString);

            try{
                connection.Open();                   
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                kq.Load(dataReader);

                dataGridView1.DataSource = kq;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Time1";
                dataGridView1.Columns[1].HeaderText = "Time2";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                // dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Ketqua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataReader.Close();
                command.Dispose();
            }

            //if loi
            catch (Exception ex){
                MessageBox.Show("Error while read database !" + ex.ToString());
            }
            finally {
                connection.Close();
            }
            

        }
    }
}
