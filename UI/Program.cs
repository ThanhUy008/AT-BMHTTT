using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIPhanHe1.AT_BMHTTT.UI;
using System.Data;
using System.Data.OracleClient;
namespace UIPhanHe1
{

    static class Program
    {
        //public static OracleConnection con;
        public static String temp;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                using (OraDBConnect.con = new OracleConnection(OraDBConnect.ConString))
                {
                    OraDBConnect.con.Open();
                    temp = "Nice";
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                    OraDBConnect.con.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            System.Windows.Forms.MessageBox.Show("Done");
        }
    }
}
