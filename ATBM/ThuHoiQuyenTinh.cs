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

                cmd.CommandText = String.Format("revoke {0} on {1} from {2}", comboBox2.Text, comboBox3.Text, comboBox1.Text).ToUpper();
                cmd.ExecuteNonQuery();
                MessageBox.Show("revoke quyền thành công");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String command = String.Format("SELECT DISTINCT PRIVILEGE FROM USER_TAB_PRIVS WHERE GRANTEE = '{0}' AND TABLE_NAME = '{1}'", comboBox1.Text.ToUpper(), comboBox3.Text);

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
            String command = String.Format("SELECT DISTINCT TABLE_NAME FROM USER_TAB_PRIVS WHERE GRANTEE = '{0}'", comboBox1.Text.ToUpper());

            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            if (ds.Tables.Count > 0)
            {
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.DisplayMember = "TABLE_NAME";
            }
        }
    }
}
