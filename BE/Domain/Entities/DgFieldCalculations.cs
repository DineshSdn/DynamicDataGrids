using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DgFieldCalculations
    {
        public int id { get; set; }
        public int calc_field1 { get; set; }
        public string calc_field1_transformation { get; set; }
        public int calc_field2 { get; set; }
        public string mid_operator { get; set; }
        public string calc_field2_transformation { get; set; }
        public bool enable_post_operator { get; set; }
        public string post_operator { get; set; }
        public int? post_operator_val { get; set; }
        public int field_id { get; set; }
        public DateTime created_datetime { get; set; }
        public int created_by { get; set; }
        public DateTime? modified_datetime { get; set; }
        public int? modified_by { get; set; }
    }
}
