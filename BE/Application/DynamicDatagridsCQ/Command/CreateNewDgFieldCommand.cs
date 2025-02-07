using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common.Interfaces;
using CleanArchitecture.ApplicationCore.Common.Models;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Dapper;
using MediatR;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Command
{
    public class CreateNewDgFieldCommand : IRequest<JsonResponse>
    {
        public int id { get; set; }
        public string name { get; set; }
        public int field_type_id { get; set; }
        public string field_type_name { get; set; }
        public int has_response_values { get; set; }
        public bool is_required { get; set; }
        public bool? is_integer_only { get; set; }
        public int? integer_validation_min { get; set; }
        public int? integer_validation_max { get; set; }
        public int? lookup_dataset { get; set; }

        public string? lookup_dataset_name { get; set; }
        public int datagrid_id { get; set; }
        public bool status { get; set; }
        public bool show_in_tabular { get; set; }
        public int tabular_sort_order { get; set; }
        public bool show_in_detail { get; set; }
        public int detail_sort_order { get; set; }
        public int response_count { get; set; }
        public string field_tooltip { get; set; }
        public int field_selected_value { get; set; }
        public int edited_field_result_id { get; set; }

        public DgFieldCalculation? dgFieldCalculation { get; set; }



        //    @id=0,
        //@name='Onset(2)',
        //@field_type_id=1,
        //@field_type_name='abc',
        //@has_response_values=1,
        //@is_required=1,
        //@is_integer_only=0,
        //@integer_validation_min=NULL,
        //@integer_validation_max=NULL,
        //@lookup_dataset=NULL,
        //@lookup_dataset_name='New Db',
        //@datagrid_id=4,
        //@status=1,
        //@show_in_tabular=1,
        //@tabular_sort_order=5,
        //@show_in_detail=1,
        //@detail_sort_order=2,
        //@response_count=2,
        //@field_tooltip=2,
        //@field_selected_value=NUll,
        //@edited_field_result_id=1;
    }
    public class CreateNewDgFieldCommandHandler : IRequestHandler<CreateNewDgFieldCommand, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;

        public CreateNewDgFieldCommandHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<JsonResponse> Handle(CreateNewDgFieldCommand request, CancellationToken cancellationToken)
        {
            JsonResponse response = new JsonResponse();
            XElement xEleCalculation = null;

            if (request.dgFieldCalculation != null)
            {
                request.dgFieldCalculation.mid_operator = string.IsNullOrEmpty(request.dgFieldCalculation.mid_operator) ? request.dgFieldCalculation.mid_operator :
                                                            request.dgFieldCalculation.mid_operator.Substring(2);
                request.dgFieldCalculation.post_operator = string.IsNullOrEmpty(request.dgFieldCalculation.post_operator) ? request.dgFieldCalculation.post_operator :
                                                            request.dgFieldCalculation.post_operator.Substring(2);

                xEleCalculation = new XElement("DgFieldCalculation",
                                               new XElement("id", request.dgFieldCalculation.id),
                                               new XElement("calc_field1", request.dgFieldCalculation.calc_field1),
                                               new XElement("calc_field1_transformation", request.dgFieldCalculation.calc_field1_transformation),
                                               new XElement("calc_field2", request.dgFieldCalculation.calc_field2),
                                               new XElement("mid_operator", request.dgFieldCalculation.mid_operator),
                                               new XElement("calc_field2_transformation", request.dgFieldCalculation.calc_field2_transformation),
                                               new XElement("enable_post_operator", request.dgFieldCalculation.enable_post_operator),
                                               new XElement("post_operator", request.dgFieldCalculation.post_operator),
                                               new XElement("post_operator_val", request.dgFieldCalculation.post_operator_val),
                                               new XElement("field_id", request.dgFieldCalculation.field_id)
                                               );
            }

            using (var con = _context.CreateConnection())
            {
                var result = (await con.QueryAsync<JsonResponse>(DapperConstants.adm_createDgField,
                     new
                     {
                         id = request.id,
                         name = request.name,
                         field_type_id = request.field_type_id,
                         field_type_name = request.field_type_name,
                         has_response_values = request.has_response_values,
                         is_required = request.is_required,
                         is_integer_only = request.is_integer_only,
                         integer_validation_min = request.integer_validation_min,
                         integer_validation_max = request.integer_validation_max,
                         lookup_dataset = request.lookup_dataset,
                         lookup_dataset_name = request.lookup_dataset_name,
                         datagrid_id = request.datagrid_id,
                         status = request.status,
                         show_in_tabular = request.show_in_tabular,
                         tabular_sort_order = request.tabular_sort_order,
                         show_in_detail = request.show_in_detail,
                         detail_sort_order = request.detail_sort_order,
                         response_count = request.response_count,
                         field_tooltip = request.field_tooltip,
                         field_selected_value = request.field_selected_value,
                         edited_field_result_id = request.edited_field_result_id
                     },
                     commandType: CommandType.StoredProcedure)).FirstOrDefault();

                if (result != null)
                {
                    response.Data = result.Id; // Assuming the stored procedure returns the new ID here
                    response.Status = result.Status;
                    response.Message = result.Message;
                }
                else
                {
                    response.Status = 1;
                    response.Message = "Failed to create new data grid field.";
                }
            }
            return response; // Ensure the method returns the response object in all cases
        }


    }
}

