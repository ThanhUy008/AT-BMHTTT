﻿using System;
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
            string[] priv = { "SELECT", "INSERT", "UPDATE", "DELETE" };

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


        private void button6_Click(object sender, EventArgs e)
        {
            String command =  String.Format("SELECT COLUMN_NAME FROM USER_TAB_COLS WHERE TABLE_NAME = '{0}'", comboBox3.Text);
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
        }
    }
}
