using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DynamicDatagridsCQ.ViewModel
{
    public class Responsesenwdto
    {
        public int id { get; set; }
        public int gridid { get; set; }
        public int userid {  get; set; }    
        public int questionid { get; set; }
        public string response { get; set; }
        public DateTime time { get; set; } = DateTime.Now;
    }
}
