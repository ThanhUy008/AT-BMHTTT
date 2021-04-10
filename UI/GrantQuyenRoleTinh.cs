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
    public partial class GrantQuyenRoleTinh : Form
    {
        public GrantQuyenRoleTinh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(OraDBConnect.ConString);

            try
            {
                String command = "SELECT ROLE FROM DBA_ROLES";
                OracleCommand cmd = new OracleCommand(command, con);
                con.Open();
                OracleDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] priv = { "SELECT", "INSERT", "UPDATE", "DELETE" };

            for (int i = 0; i < priv.Length; i++)
            {
                comboBox2.Items.Add(priv[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(OraDBConnect.ConString);

            try
            {
                String command = "SELECT TABLE_NAME from DBA_TABLES WHERE OWNER = 'TRUONG'";
                OracleCommand cmd = new OracleCommand(command, con);
                con.Open();
                OracleDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(rd[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(OraDBConnect.ConString);
            try
            {
                String table_name = comboBox3.Text;
                String command = String.Format("SELECT COLUMN_NAME FROM USER_TAB_COLS WHERE TABLE_NAME = '{0}'", table_name);
                OracleCommand cmd = new OracleCommand(command, con);
                con.Open();
                OracleDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox4.Items.Add(rd[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
