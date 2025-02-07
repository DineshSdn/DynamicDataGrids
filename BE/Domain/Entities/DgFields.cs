using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DgFields
    {
        public int id { get; set; }
        public string name { get; set; }
        public int field_type { get; set; }
        public bool is_required { get; set; }
        public bool? is_integer_only { get; set; }
        public int? integer_validation_min { get; set; }
        public int? integer_validation_max { get; set; }
        public int? lookup_dataset { get; set; }
        public int datagrid_id { get; set; }
        public bool active { get; set; }
        public bool show_in_tabular { get; set; }
        public int tabular_sort_order { get; set; }
        public bool show_in_detail { get; set; }
        public int detail_sort_order { get; set; }
        public DateTime created_datetime { get; set; }
        public int created_by { get; set; }
        public DateTime? modified_datetime { get; set; }
        public int? modified_by { get; set; }
        [MaxLength(255)]
        public string field_tooltip { get; set; }
     
    }
}
