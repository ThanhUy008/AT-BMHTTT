using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.OracleClient;
using System.Data.OleDb;

namespace UIPhanHe1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()

        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;
                cmd.CommandText = "showAllJustGrantSys".ToUpper();
                cmd.CommandType = CommandType.StoredProcedure;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;
                cmd.CommandText = "showAllJustGrantTab".ToUpper();
                cmd.CommandType = CommandType.StoredProcedure;
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
