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
    public partial class ThuHoiQuyenUser : Form
    {
        public ThuHoiQuyenUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(OraDBConnect.ConString);

            try
            {
                String command = "SELECT USERNAME FROM ALL_USERS";
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
    }
}
