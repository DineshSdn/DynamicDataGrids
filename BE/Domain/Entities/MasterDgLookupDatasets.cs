using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MasterDgLookupDatasets
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool active { get; set; }
        public DateTime created_datetime { get; set; }
        public int created_by { get; set; }
        public DateTime? modified_datetime { get; set; }
        public int? modified_by { get; set; }
    }
}
