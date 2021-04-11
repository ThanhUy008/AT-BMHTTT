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
                cmd.CommandText = "DROPUSER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pi_username", OracleType.NVarChar).Value = comboBox1.Text;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
