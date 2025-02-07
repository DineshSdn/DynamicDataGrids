using System;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel
{
    public class DynamicDataGridData
    {
        public int id { get; set; }
        public string head_name { get; set; }
        public string description { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public bool show_health_profile { get; set; }
        public string rolename { get; set; }
        public string role_id { get; set; }
        public int? sort { get; set; }
    }


    public class DtoforhealthProfile
    {
        public int id { get; set; }
        public string name { get; set; }

        public int type_id { get; set; }
        public string description { get; set; }
        public string type_name { get; set; }

        public bool STATUS { get; set; }
        public bool show_health_profile { get; set; }



    }

}
