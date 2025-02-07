using System.Collections.Generic;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel
{
    public class DynamicGridMasterDto
    {
        public List<DynamicGridTypeDto> dynamicGridTypes {  get; set; }
        public List<DgFieldTypeDto> dgFieldTypes { get; set; }
        public List<DgLookUpDatasetDto> dgLookUpDatasets { get; set; }
    }
}

public class DynamicGridTypeDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
    public bool active { get; set; }
}

public class DgFieldTypeDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
    public bool has_response_values { get; set; }
}

public class DgLookUpDatasetDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
    public bool active { get; set; }
}