using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DgCore
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool show_health_profile { get; set; }
        public int type { get; set; }
        public bool active { get; set; }
        public string code_key { get; set; }
        public DateTime created_datetime { get; set; }
        public int created_by { get; set; }
        public DateTime? modified_datetime { get; set; }
        public int? modified_by { get; set; }
        public String? MasterDgTypes { get; set; }
    }
}
