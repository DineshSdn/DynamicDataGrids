using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel
{
    public class DgFieldResponseDto
    {

        public int id { get; set; }
        public string name { get; set; }
        public int field_id { get; set; }
        public bool active { get; set; }
        public bool ideal_choice { get; set; }
        public int response_sort_order { get; set; }
        public DateTime created_datetime { get; set; }
        public int created_by { get; set; }
        public DateTime modified_datetime { get; set; }
        public int modified_by { get; set; }

    }
}
