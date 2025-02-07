using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel
{
    public class DgFieldDto
    {
        public List<DgField> fields { get; set; }
        public List<DgFieldCalculation> field_calculations { get; set; }
        public List<DgFieldResponseDto> dgFieldResponses { get; set; }
        public List<DgFieldCodesDto> dgFieldCodesDtos { get; set; }
        public List<DgFieldCPTCodesDto> dgFieldCPTCodesDtos { get; set; }
        public List<DgFieldResultsDto> dgFieldResultsDtos { get;set; }
        public List<EncounterCPTCodes> encounterCPTCodes { get; set; }
        public List<EncounterSuspectCodes> encounterSuspectCodes { get; set; }
    }

    public class EncounterCPTCodes
    {
        public string cpt_code { get; set; }
    }

    public class EncounterSuspectCodes
    {
        public string icd_code { get; set; }
    }

    public class DgField
    {
        public int id { get; set; }
        public string name { get; set; }
        public int field_type_id { get; set; }
        public string field_type_name { get; set; }
        public bool has_response_values { get; set; }
        public bool is_required { get; set; }
        public bool? is_integer_only { get; set; }
        public int? integer_validation_min { get; set; }
        public int? integer_validation_max { get; set; }
        public int? lookup_dataset { get; set; }
        public string lookup_dataset_name { get; set; }
        public int datagrid_id { get; set; }
        public bool status { get; set; }
        public bool show_in_tabular { get; set; }
        public int tabular_sort_order { get; set; }
        public bool show_in_detail { get; set; }
        public int detail_sort_order { get; set; }
        public int response_count { get; set; }
        public string field_tooltip { get; set; }
        public List<DgFieldResponseDto>? field_response { get; set; }
        public List<DgFieldCodesDto>? field_suspects { get; set; }
        public List<DgFieldCPTCodesDto>? field_cpt { get; set; }        
        public string? field_selected_value { get; set; }
        public int edited_field_result_id { get; set; }
    }
}
