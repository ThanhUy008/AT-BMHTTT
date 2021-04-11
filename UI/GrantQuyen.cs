using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;


namespace UIPhanHe1
{
    public partial class GrantQuyen : Form
    {
        public GrantQuyen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String command = "SELECT USERNAME FROM ALL_USERS";
            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            if (ds.Tables.Count > 0)
            {
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "USERNAME";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String command = "SELECT DISTINCT PRIVILEGE FROM DBA_SYS_PRIVS";

            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            if (ds.Tables.Count > 0)
            {
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.DisplayMember = "PRIVILEGE";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = OraDBConnect.ConString;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                
                conn.Open();
                if (checkBox1.Checked == false)
                {
                    cmd.CommandText = "GRANT_SYS_USER";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("priv", OracleType.NVarChar).Value = comboBox2.Text;
                    cmd.Parameters.Add("user_name", OracleType.NVarChar).Value = comboBox1.Text;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = String.Format("GRANT {0} TO {1} WITH GRANT OPTION", comboBox2.Text, comboBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show("Gán quyền thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
