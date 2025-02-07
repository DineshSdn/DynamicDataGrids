namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel
{
    public class DgFieldCalculation
    {
        public int id { get; set; }
        public int calc_field1 { get; set; }
        public string calc_field1_transformation { get; set; }
        public int calc_field2 { get; set; }
        public string mid_operator { get; set; }
        public string calc_field2_transformation { get; set; }
        public bool enable_post_operator { get; set; }
        public string post_operator { get; set; }
        public int? post_operator_val { get; set; }
        public int field_id { get; set; }
    }
}