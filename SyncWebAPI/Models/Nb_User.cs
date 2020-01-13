using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YsWebAPI.Models
{
    public class Nb_User
    {
        public string BranchCode
        {
            get; set;
        }
        public string BranchName
        {
            get; set;
        }
        public string AgentCode
        {
            get; set;
        }
        public int NotSyncQty
        {
            get; set;
        }
        public int ErrSyncQty
        {
            get; set;
        }
        public DateTime LastOnlineDate
        {
            get; set;
        }
        public int LastSyncQty
        {
            get; set;
        }
        public int LastElapsed
        {
            get; set;
        }
       
    }
}
