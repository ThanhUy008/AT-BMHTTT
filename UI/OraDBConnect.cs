using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;

namespace UIPhanHe1
{
    class OraDBConnect
    {
        public static OracleConnection con;
        public static String UserName = "TRUONG";
        public static String ConString = String.Format("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id ={0}; Password =root", UserName);

        public static bool Query(String command,DataSet ds)
        {

            try
            {
                //using (OracleConnection con = new OracleConnection(ConString))
                //{
                if (con == null)
                {
                    System.Windows.Forms.MessageBox.Show(Program.temp);
                }
                else
                {
                    OracleCommand cmd = new OracleCommand(command, con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    oda.Fill(ds);
                }
                //}
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
               // Console.WriteLine(ex);
                return false;
            }
            return true;
        }
    }
}
