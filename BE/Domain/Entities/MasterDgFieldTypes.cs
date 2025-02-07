using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("master_dg_field_types")]
    public class MasterDgFieldTypes
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool has_response_values { get; set; }
        public bool active { get; set; }
        public DateTime created_datetime { get; set; }
        public int created_by { get; set; }
        public DateTime? modified_datetime { get; set; }
        public int? modified_by { get; set; }
    }
}
