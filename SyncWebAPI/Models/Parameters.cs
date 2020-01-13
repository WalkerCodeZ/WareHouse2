using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YsWebAPI
{
    public class Parameters
    {
        public string Key
        {
            get;set;
        }
        public string BranchCode
        {
            get; set;
        }
        public string DBranchCode
        {
            get; set;
        }
        public string TableName
        {
            get; set;
        }
        public string Category
        {
            get; set;
        }
        //[JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime BeginDate
        {
            get;set;
        }
        //[JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime EndDate
        {
            get; set;
        }
        public int PageIndex
        {
            get; set;
        }
        public string DataBaseId
        {
            get; set;
        }
    }
}