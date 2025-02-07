using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel
{
    public class DgFieldResultsDto
    {
        public int row_id { get; set; }
        public int id { get; set; }
        public int patient_empi { get; set; }
        public int? encounter_id { get; set; }
        public int field_id { get; set; }
        public string response { get; set; }
        public int? response_select { get; set; }
        public string response_select_name { get; set; }
        public string response_signature { get; set; }
        public string response_multi { get; set; }
        public string response_multi_name { get; set; }
        public DateTime? response_date { get; set; }
        public int? response_lookup { get; set; }
        public string lookup_code { get; set; }
        public string lookup_description { get; set; }
        public int? actual_lookup_response { get; set; }
    }
}
