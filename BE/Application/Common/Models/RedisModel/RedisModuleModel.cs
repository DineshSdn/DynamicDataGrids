using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Common.Models.RedisModel
{
    public class RedisModuleModel
    {
        public string ModuleName { get; set;}
        public string implementationStatus { get; set; }
        public string cachingStatus { get; set; }
        public string cachingTime { get; set; }
        public string deleteKey { get; set; }
        public string deletePattern { get; set; }
    }
}
