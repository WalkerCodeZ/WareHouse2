using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using SyncWebAPI.Controllers;

namespace YsWebAPI
{
    public class DbOperate
    {
        //DataTable dt;
        //OracleConnection cn;
        //OracleCommand cmd;
        //OracleDataAdapter da;

        public static OracleConnection Conn(/*string strconn*/)
        {
            string strcn = AppSetting.GetConfig("ConnectionStrings:SyncOrcl");
            OracleConnection cn = new OracleConnection(strcn);
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cn;
        }
        public static DataTable Execute(string strSql, OracleConnection cn)
        {
            OracleCommand cmd = new OracleCommand(strSql, cn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static string Insert(string strInsert)
        {
            OracleConnection cn1 = Conn();
            OracleCommand cmd1 = new OracleCommand(strInsert, cn1);
            int n = cmd1.ExecuteNonQuery();
            return n.ToString();
        }
    }
}
