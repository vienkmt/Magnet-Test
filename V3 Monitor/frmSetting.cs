using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Process_Monitor
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // check sql
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            //connetionString = "Data Source=192.168.5.33\ECUSSQL2008;Initial Catalog=EQM;User ID=sa;Password=123456";
            connetionString = "Data Source=" + txtString.Text + ";Initial Catalog=" + txtDB.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPassword.Text;
            sql = "select * from logs";
            connection = new SqlConnection(connetionString);


            //ok thì lưu
            Properties.Settings.Default.mssql = txtString.Text;
            Properties.Settings.Default.user = txtUser.Text;
            Properties.Settings.Default.pwd = txtPassword.Text;
            Properties.Settings.Default.db = txtDB.Text;

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Save OK");
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu!. " + ex.ToString());
                return;
            }
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            try
            {
                //ok thì lưu
                txtString.Text = Properties.Settings.Default.mssql;
                txtUser.Text = Properties.Settings.Default.user;
                txtPassword.Text = Properties.Settings.Default.pwd;
                txtDB.Text = Properties.Settings.Default.db;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when get setting. " + ex.ToString());
            }
        }
    }
}
