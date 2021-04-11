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
    public partial class GrantQuyenTinh : Form
    {
        public GrantQuyenTinh()
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
            string[] priv = { "SELECT", "INSERT", "UPDATE", "DELETE" };
            if(comboBox2.Items.Count == 0)
            for (int i = 0; i < priv.Length; i++) 
            {
                comboBox2.Items.Add(priv[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String command = String.Format("SELECT TABLE_NAME from DBA_TABLES WHERE OWNER = '{0}'", OraDBConnect.UserName.ToUpper());
            DataSet ds = new DataSet();
            OraDBConnect.Query(command, ds);
            if (ds.Tables.Count > 0)
            {
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.DisplayMember = "TABLE_NAME";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String command = String.Format("SELECT COLUMN_NAME FROM USER_TAB_COLS WHERE TABLE_NAME = '{0}'", comboBox3.Text);
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(command, OraDBConnect.con);
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            oda.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                checkedListBox1.DataSource = ds.Tables[0];
                checkedListBox1.DisplayMember = "COLUMN_NAME";
                checkedListBox1.ValueMember = "COLUMN_NAME";

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
            {
                String temp = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                if (temp == "SELECT" || temp == "UPDATE")
                {
                    checkedListBox1.Enabled = true;
                }
                else
                {
                    checkedListBox1.Enabled = false;
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<String> checkedList = new List<String>();
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;

                checkedList.Add(castedItem["COLUMN_NAME"].ToString());
            }


            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OraDBConnect.con;
                String column = "";
                String withGrantOption = "";
                if (checkedList.Count != 0)
                {
                    for (int i = 0; i < checkedList.Count; i++)
                    {
                        column = column + checkedList[i] + ", ";
                    }
                    column = column.Remove(column.Length - 1);
                    column = column.Remove(column.Length - 1);
                }
                if (checkBox1.Checked == false)
                {
                    withGrantOption = " WITH GRANT OPTION";
                }
                else
                {

                }
                if (checkedList.Count == 0)
                {

                    cmd.CommandText = "GRANT_DATA_USER";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("data_priv", OracleType.NVarChar).Value = comboBox2.Text;
                    cmd.Parameters.Add("table_name", OracleType.NVarChar).Value = comboBox3.Text;
                    cmd.Parameters.Add("user_name", OracleType.NVarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("withGrantOption", OracleType.NVarChar).Value = withGrantOption;

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "grant_data_user_2".ToUpper();
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    if (comboBox2.Text == "SELECT")
                    {
                        cmd.Parameters.Add("data_priv", OracleType.NVarChar).Value = comboBox2.Text;
                        cmd.Parameters.Add("table_name", OracleType.NVarChar).Value = comboBox3.Text;
                        cmd.Parameters.Add("user_name", OracleType.NVarChar).Value = comboBox1.Text;
                        cmd.Parameters.Add("columnList", OracleType.NVarChar).Value = column;

                        cmd.Parameters.Add("withGrantOption", OracleType.NVarChar).Value = withGrantOption;
                        
                    }
                    else
                    {
                        cmd.CommandText = "GRANT_DATA_USER";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("data_priv", OracleType.NVarChar).Value = comboBox2.Text;
                        cmd.Parameters.Add("table_name", OracleType.NVarChar).Value = comboBox3.Text;
                        cmd.Parameters.Add("user_name", OracleType.NVarChar).Value = comboBox1.Text;
                        cmd.Parameters.Add("withGrantOption", OracleType.NVarChar).Value = withGrantOption;
                    }

                    cmd.ExecuteNonQuery();
                }
                /* if (checkedList.Count == 0)
                 {
                     if (checkBox1.Checked == false)
                     {
                         cmd.CommandText = "GRANT_DATA_USER";
                         cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.Add("data_priv", OracleType.NVarChar).Value = comboBox2.Text;
                         cmd.Parameters.Add("table_name", OracleType.NVarChar).Value = comboBox3.Text;
                         cmd.Parameters.Add("user_name", OracleType.NVarChar).Value = comboBox1.Text;
                         cmd.ExecuteNonQuery();
                     }
                     else
                     {
                         cmd.CommandText = String.Format("GRANT {0} ON {1} TO {2} WITH GRANT OPTION", comboBox2.Text, comboBox3.Text, comboBox1.Text);
                         cmd.ExecuteNonQuery();
                     }
                 }
                 else
                 {
                     if (comboBox2.Text == "SELECT")
                     {
                         cmd.CommandText = String.Format(@"CREATE OR REPLACE VIEW {0}_{2} AS
                                                         SELECT {1}
                                                         FROM {0}", comboBox3.Text, column, comboBox1.Text);
                         cmd.ExecuteNonQuery();
                     }

                     if (checkBox1.Checked == false)
                     {
                         if (comboBox2.Text == "SELECT")
                         {
                             cmd.CommandText = String.Format("GRANT {0} ON {1}_{2} TO {2}", comboBox2.Text, comboBox3.Text, comboBox1.Text);
                             cmd.ExecuteNonQuery();
                         }
                         else
                         {
                             cmd.CommandText = String.Format("GRANT {0} ({1}) ON {2} TO {3}", comboBox2.Text, column, comboBox3.Text, comboBox1.Text);
                             cmd.ExecuteNonQuery();
                         }
                     }
                     else
                     {
                         if (comboBox2.Text == "SELECT")
                         {
                             cmd.CommandText = String.Format("GRANT {0} ON {1}_{2} TO {2} WITH GRANT OPTION", comboBox2.Text, comboBox3.Text, comboBox1.Text);
                             cmd.ExecuteNonQuery();
                         }
                         else
                         {
                             cmd.CommandText = String.Format("GRANT {0} ({1}) ON {2} TO {3} WITH GRANT OPTION", comboBox2.Text, column, comboBox3.Text, comboBox1.Text);
                             cmd.ExecuteNonQuery();
                         }
                     }
                     */

            
                MessageBox.Show("Gán quyền thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
    
        }
    }
}
