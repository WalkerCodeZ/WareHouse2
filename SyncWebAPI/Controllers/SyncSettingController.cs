using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YsWebAPI.Models;

namespace YsWebAPI.Controllers
{
    [Route("Sync/[controller]")]
    [ApiController]
    public class SyncSettingController : ControllerBase
    {
        [HttpPut("SyncSetting/PutOnlineInfo")]
        public object PutOnlineInfo([FromBody]Nb_User nb_User)
        {
            string strInsert = "merge into sc_onlinev1 t1 using (select '"+nb_User.BranchCode+"' branchcode from dual)t2 on(t1.branchcode = t2.branchcode) when matched then update set branchname = '"+nb_User.BranchName+"', agentcode = '"+nb_User.AgentCode+"', notsyncqty = "+nb_User.NotSyncQty+", errsyncqty = "+nb_User.ErrSyncQty+", lastonlinedate = to_date('"+nb_User.LastOnlineDate+"', 'yyyy/MM/dd HH24:mi:ss'), lastsyncqty = "+nb_User.LastSyncQty+", lastelapsed = "+nb_User.LastElapsed+" when not matched then insert(branchcode, branchname, agentcode, notsyncqty, errsyncqty, lastonlinedate, lastsyncqty, lastelapsed) values('"+nb_User.BranchCode+"', '"+nb_User.BranchName+"', '"+nb_User.AgentCode+"', "+nb_User.NotSyncQty+", "+nb_User.ErrSyncQty+", to_date('"+nb_User.LastOnlineDate+"', 'yyyy/MM/dd HH24:mi:ss'), "+nb_User.LastSyncQty+", "+nb_User.LastElapsed+")";
            string effectedRows = DbOperate.Insert(strInsert);
            return "插入成功：当前受影响行数为" + effectedRows;
        }
    }
}