using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel
{
    public class DgFieldCPTCodesDto
    {
        public int id { get; set; }
        public int cpt_code_id { get; set; }
        public string? cpt_code { get; set; }
        public string? cpt_description { get; set; }
        public int field_id { get; set; }
        public int field_type_id { get; set; }
        public string? trigger_type { get; set; }
        public int? trigger_match { get; set; }
        public int? trigger_range_min { get; set; }
        public int? trigger_range_max { get; set; }
        public int? qualifier_value { get; set; }
        public string? text_value { get; set; }
    }
}
