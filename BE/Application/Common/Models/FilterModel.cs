namespace CleanArchitecture.ApplicationCore.Common.Models
{
    public class FilterModel
    {
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public string SortColumn { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
        public string payers { get; set; }
        public string states { get; set; }
        public string countries { get; set; }
        public string cities { get; set; }
        public string clients { get; set; }
        public string awvstatus { get; set; }
        public string status { get; set; }
        public string projects { get; set; }
        public string SearchText { get; set; }
        public string DateFilter { get; set; }
        public string languages { get; set; }
        public string project_type { get; set; }
        public string reasons { get; set; }
        public string statuses { get; set; }
        public int? Qual_Status { get; set; }
        public int? prospectivereviewstatus { get; set; } 
        public int? gender { get; set; }
        public string postal { get; set; }
        public string ethnicity { get; set; }
        public string pcp { get; set; }

        public string member_id { get; set; }
        public int? min_age { get; set; }
        public int? max_age { get; set; }
        public float? min_risk { get; set; }
        public float? max_risk { get; set; }

        public string icdCode { get; set; }
        public string hccCode { get; set; }
        public string gapTypeId { get; set; }

        public string eligibility { get; set; } = string.Empty;

    }
}
