using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Common.Models
{
    public class PayPeriodResponseModel
    {
        public int pay_period_id { get; set; }
        public string name { get; set; }
        public int time_sheet_id { get; set; }
    }
}
