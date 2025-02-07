using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DynamicDatagridsCQ.ViewModel
{
    public class Dg_field_newDto
    {
        public int id { get; set; } 
        public string name { get; set; }
        public int field_type_id { get; set; }
        public string field_type_name { get; set; }
        public int has_response_values { get; set; }
        public Boolean is_required { get; set; }
        public Boolean is_integer_only { get; set; }
        public int integer_validation_min { get; set; }
        public int integer_validation_max { get; set; }
        public Boolean lookup_dataset { get; set; }
        public string lookup_dataset_name { get; set; }
        public int datagrid_id { get; set; }
        public Boolean status { get; set; }
        public Boolean show_in_tabular { get; set; }
        public int tabular_sort_order { get; set; }
        public Boolean show_in_detail { get; set; }

        public int detail_sort_order { get; set; }

        public int response_count { get; set; }
        public string  field_tooltip { get; set; }
        public int field_selected_value { get; set; }

        public int edited_field_result_id { get; set; }

    }
}



