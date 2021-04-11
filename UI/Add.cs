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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
            if(checkBox2.Checked == true)
            textBox2.ReadOnly = true;
            else textBox2.ReadOnly = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
            if (checkBox1.Checked == true)
                textBox2.ReadOnly = false;
            else textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;
                if (checkBox1.Checked == true)
                {
                    cmd.CommandText = "createUser".ToUpper();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pi_username", OracleType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("pi_password", OracleType.NVarChar).Value = textBox2.Text;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "createRole".ToUpper();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pi_username", OracleType.NVarChar).Value = textBox1.Text;
                     cmd.ExecuteNonQuery();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
