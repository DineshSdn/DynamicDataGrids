namespace CleanArchitecture.ApplicationCore.MasterDataCQ.ViewModel
{
    public class MasterDataDto
    {
        public int Id { get; set; }
        public int globalcategory_id { get; set; }
        public string category_key { get; set; }
        public string code { get; set; }
        public string code_key { get; set; }
        public int? parent_globalcategory_to_code_id { get; set; }
        public bool disabled { get; set; }

    }
}
