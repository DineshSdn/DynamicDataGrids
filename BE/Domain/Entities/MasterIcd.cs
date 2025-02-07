using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MasterIcd : AuditableEntity
    {
        public int id { get; set; }
        public bool active { get; set; }
        [MaxLength(255)]
        public string codeset { get; set; }
        [MaxLength(255)]
        public string codeset_version { get; set; }
        public DateTime active_start { get; set; }
        public DateTime active_end { get; set; }
        public bool is_sensitive { get; set; }
        [MaxLength(255)]
        public string categoryCode { get; set; }
        [MaxLength(255)]
        public string code { get; set; }
        [Column(TypeName = "NVARCHAR(max)")]
        public string description { get; set; }
        public bool isBillable { get; set; }
        public bool is_billable { get; set; }
        public int? hcc_code { get; set; }
    }
}
