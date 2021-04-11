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

namespace UIPhanHe1.AT_BMHTTT.UI
{
    public partial class GrantQuyenRole : Form
    {
        public GrantQuyenRole()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String command = "SELECT ROLE FROM DBA_ROLES";
            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            if (ds.Tables.Count > 0)
            {
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "ROLE";
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
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;
                if (checkBox1.Checked == false)
                {
                    cmd.CommandText = "GRANT_SYS_ROLE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("priv", OracleType.NVarChar).Value = comboBox2.Text;
                    cmd.Parameters.Add("role_name", OracleType.NVarChar).Value = comboBox1.Text;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = String.Format("GRANT {0} TO {1} WITH ADMIN OPTION", comboBox2.Text, comboBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Gán quyền thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
