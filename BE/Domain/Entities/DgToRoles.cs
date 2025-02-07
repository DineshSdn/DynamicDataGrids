
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("dg_to_roles")]
    public class DgToRoles: AuditableEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("DgCore")]
        public int datagrid_id { get; set; }
        [Required]
        [ForeignKey("role")]
        public int role_id { get; set; }
        public bool active { get; set; }
        public DgCore DgCore { get; set; }
        public Role role { get; set; }
    }
}
