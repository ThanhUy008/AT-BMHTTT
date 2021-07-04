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
    public partial class Xoa : Form
    {
        public Xoa()
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
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;
                cmd.CommandText = "ALTER SESSION SET \"_ORACLE_SCRIPT\"=true";
                cmd.ExecuteNonQuery();
                cmd.CommandText = String.Format("drop user {0} ", comboBox1.Text).ToUpper();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công");
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
