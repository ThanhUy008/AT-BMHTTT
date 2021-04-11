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
    public partial class ThongTinRole : Form
    {
        public ThongTinRole()
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
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;

                cmd.CommandText = "showRolePrivSys".ToUpper();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("rolename", OracleType.NVarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("c1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                oda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;

                cmd.CommandText = "showRolePrivTab".ToUpper();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("rolename", OracleType.NVarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("c1", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                oda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
