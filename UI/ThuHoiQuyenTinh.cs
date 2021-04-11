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
    public partial class ThuHoiQuyenTinh : Form
    {
        public ThuHoiQuyenTinh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = "";
            String command = "";
            if (checkBox3.Checked)
            {
                command = "SELECT USERNAME FROM ALL_USERS";
                type = "USERNAME";
            }
            else if (checkBox4.Checked)
            {
                command = "SELECT ROLE FROM DBA_ROLES";
                type = "ROLE";
            }

            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            if (ds.Tables.Count > 0)
            {
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = type;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Checked = !checkBox3.Checked;
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = !checkBox4.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;

                cmd.CommandText = "revokeUserTablePriv".ToUpper();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("username", OracleType.NVarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("type_priv", OracleType.NVarChar).Value = comboBox2.Text;
                cmd.Parameters.Add("tab_name", OracleType.NVarChar).Value = comboBox3.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("revoke quyền thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] priv = { "SELECT", "INSERT", "UPDATE", "DELETE" };
            if (comboBox2.Items.Count == 0)
                for (int i = 0; i < priv.Length; i++)
                {
                    comboBox2.Items.Add(priv[i]);
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String command = String.Format(@"SELECT VIEW_NAME FROM DBA_VIEWS WHERE VIEW_NAME like '%{0}%'",comboBox1.Text);
            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            if (ds.Tables.Count > 0)
            {
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.DisplayMember = "VIEW_NAME";
            }
        }
    }
}
