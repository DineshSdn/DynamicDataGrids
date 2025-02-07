using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DgFieldCodes
    {
        public int id { get; set; }
        public int suspect_icd10 { get; set; }
        public int field_id { get; set; }
        public int field_type_id { get; set; }
        public string trigger_type { get; set; }
        public int? trigger_match { get; set; }
        public int? trigger_range_min { get; set; }
        public int? trigger_range_max { get; set; }
        public int? qualifier_value { get; set; }
        public string text_value { get; set; }
        public bool active { get; set; }
        public DateTime created_datetime { get; set; }
        public int created_by { get; set; }
        public DateTime? modified_datetime { get; set; }
        public int? modified_by { get; set; }
    }
}
