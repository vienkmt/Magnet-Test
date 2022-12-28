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

namespace Test_Process_Monitors
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            //Load setting vào các ô kia
            try
            {
                //ok thì lưu

            }
            catch (Exception ex)
            {
                MessageBox.Show("có lỗi: " + ex.ToString());
            }
         }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // check sql
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            //connetionString = "Data Source=192.168.5.33\\ECUSSQL2008;Initial Catalog=EQM;User ID=sa;Password=123456";
            connetionString = "Data Source="+txtString.Text +";Initial Catalog="+txtDB.Text+";User ID="+txtUser.Text+";Password="+txtPassword.Text;
            sql = "select * from logs";
            connection = new SqlConnection(connetionString);


            //ok thì lưu
           // Properties.Settings.Default.mssql = txtString.Text;
         //   Properties.Settings.Default.user = txtUser.Text;
          //  Properties.Settings.Default.pwd = txtPassword.Text;
         //   Properties.Settings.Default.line = txtLine.Text;
         //   Properties.Settings.Default.model = txtModel.Text;
          //  Properties.Settings.Default.DB = txtDB.Text;

            try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.HasRows) { 
                      //  Properties.Settings.Default.Save();
                        MessageBox.Show("Save OK");
                     }
                        dataReader.Close();
                        command.Dispose();
                        connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu!. "+ ex.ToString());
                    return;
                }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLine_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
