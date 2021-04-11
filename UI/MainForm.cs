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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DSUser xemDSUser = new DSUser();
            this.Hide();
            xemDSUser.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThongTinUser TTUser = new ThongTinUser();
            this.Hide();
            TTUser.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThongTinRole TTRole = new ThongTinRole();
            this.Hide();
            TTRole.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add addNew = new Add();
            this.Hide();
            addNew.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeUserPass changePass = new ChangeUserPass();
            this.Hide();
            changePass.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GrantQuyen grantUser = new GrantQuyen();
            this.Hide();
            grantUser.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GrantQuyenTinh grantUserTinh = new GrantQuyenTinh();
            this.Hide();
            grantUserTinh.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GrantQuyenRole grantRole = new GrantQuyenRole();
            this.Hide();
            grantRole.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GrantQuyenRoleTinh grantRoleTinh = new GrantQuyenRoleTinh();
            this.Hide();
            grantRoleTinh.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ThuHoiQuyenUser revokeUser = new ThuHoiQuyenUser();
            this.Hide();
            revokeUser.ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ThuHoiQuyenRole revokeRole = new ThuHoiQuyenRole();
            this.Hide();
            revokeRole.ShowDialog();
            this.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 vuaCap = new Form1();
            this.Hide();
            vuaCap.ShowDialog();
            this.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            EditPrivilegesUser editUser = new EditPrivilegesUser();
            this.Hide();
            editUser.ShowDialog();
            this.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            EditPrivilegesRole editRole = new EditPrivilegesRole();
            this.Hide();
            editRole.ShowDialog();
            this.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Xoa xoaUser = new Xoa();
            this.Hide();
            xoaUser.ShowDialog();
            this.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {

            XoaRole xoaRole = new XoaRole();
            this.Hide();
            xoaRole.ShowDialog();
            this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    OracleCommand cmd = new OracleCommand();
            //    cmd.Connection = OraDBConnect.con;

            //    cmd.CommandText = "beginSession".ToUpper();
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();
            
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
