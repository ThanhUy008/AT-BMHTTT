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
    public partial class ThuHoiQuyen : Form
    {
        
        public ThuHoiQuyen()
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

        private void button2_Click(object sender, EventArgs e)
        {
            String command =String.Format("SELECT DISTINCT PRIVILEGE FROM DBA_SYS_PRIVS WHERE GRANTEE ='{0}'",comboBox1.Text) ;

            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            //if (ds.Tables.Count > 0)
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

                cmd.CommandText = String.Format("revoke {0} from {1}",comboBox2.Text, comboBox1.Text).ToUpper();
                cmd.ExecuteNonQuery();
                MessageBox.Show("revoke quyền thành công");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
