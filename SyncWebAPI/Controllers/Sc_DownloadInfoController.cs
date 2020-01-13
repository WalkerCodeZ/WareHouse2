using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using YsWebAPI.Models;
using Newtonsoft.Json.Converters;

namespace YsWebAPI.Controllers.Sync
{
    [Route("Sync/[controller]")]        //Sync/sc_downloadinfo
    [ApiController]
    public class Sc_DownloadInfoController : ControllerBase
    {
        [HttpGet("GetDownloadInfo/{key}/{b}/{bd}/{t}/{c}")]   ///
        public Parameters GetDownloadInfo(string key,string b,string bd,string t,string c)
        {
            OracleConnection cn = DbOperate.Conn();
            DataTable dt = DbOperate.Execute("select * from sc_DownloadInfo where key = '" + key + "' AND branchcode = '" + b + "' AND dbranchcode = '" + bd + "' AND tablename = '" + t + "' AND category = '" + c + "'", cn);
            Parameters parameters = new Parameters();
            parameters.BranchCode= dt.Rows[0][0].ToString();
            parameters.TableName= dt.Rows[0][1].ToString();
            parameters.Category= dt.Rows[0][2].ToString();
            parameters.BeginDate =Convert.ToDateTime(dt.Rows[0][3]);
            parameters.EndDate =Convert.ToDateTime(dt.Rows[0][4]);
            parameters.PageIndex =Convert.ToInt32(dt.Rows[0][5]);
            parameters.Key= dt.Rows[0][7].ToString();
            parameters.DataBaseId = dt.Rows[0][9].ToString(); ;
            parameters.DBranchCode = dt.Rows[0][10].ToString();
            return parameters;
        }

        [HttpPut("PutDownloadInfo")]
        public object PutDownloadInfo([FromBody]Parameters parameters)
        {
            string strInsert = "merge into sc_downloadinfo t1 using (select '" + parameters.BranchCode + "' branchcode,'" + parameters.DBranchCode + "' dbranchcode,'" + parameters.TableName + "' tablename,'" + parameters.Category + "' category,'" + parameters.DataBaseId + "' databaseid from dual) t2 on(t1.branchcode = t2.branchcode and t1.dbranchcode = t2.dbranchcode and t1.tablename = t2.tablename and t1.category = t2.category and t1.databaseid = t2.databaseid) when matched then update set key = '" + parameters.Key + "', pageindex = " + parameters.PageIndex + ", begindate = to_date('" + parameters.BeginDate + "', 'yyyy/MM/dd HH24:mi:ss'), enddate = to_date('" + parameters.EndDate + "', 'yyyy/MM/dd HH24:mi:ss') when not matched then insert(branchcode, tablename, category, begindate, enddate, pageindex, key, databaseid, dbranchcode) values('" + parameters.BranchCode + "', '" + parameters.TableName + "', '" + parameters.Category + "', to_date('" + parameters.BeginDate + "', 'yyyy/MM/dd HH24:mi:ss'), to_date('" + parameters.EndDate + "', 'yyyy/MM/dd HH24:mi:ss'), " + parameters.PageIndex + ", '" + parameters.Key + "', '" + parameters.DataBaseId + "', '" + parameters.DBranchCode + "')";
            string effectedRows = DbOperate.Insert(strInsert); //将数据插入数据库
            return "data:"+parameters+" 插入成功;\n\n 当前受影响的行数："+effectedRows+"行。";
        }
    }
}