﻿using System;
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
        public static String ConString = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id =c##user; Password =root";


        public static bool Query(String command,DataSet ds)
        {
            
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))

                {

                    OracleCommand cmd = new OracleCommand(command, con);

                    OracleDataAdapter oda = new OracleDataAdapter(cmd);

                 //   ds = new DataSet();

                    oda.Fill(ds);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}