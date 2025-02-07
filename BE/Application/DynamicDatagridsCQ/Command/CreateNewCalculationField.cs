using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common.Interfaces;
using CleanArchitecture.ApplicationCore.Common.Models;
using CleanArchitecture.ApplicationCore.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Application.DynamicDatagridsCQ.Command
{
    public class CreateNewCalculationField : IRequest<JsonResponse>
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
        public DateTime created_datetime { get; set; } 
        public int created_by { get; set; }
        public DateTime? modified_datetime { get; set; }
        public int? modified_by { get; set; }






    }
    public class CreateNewCalculationFieldHandler : IRequestHandler<CreateNewCalculationField, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;

        public CreateNewCalculationFieldHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<JsonResponse> Handle(CreateNewCalculationField request, CancellationToken cancellationToken)
        {
            string joined = "";


            JsonResponse response = new JsonResponse();

            using (var con = _context.CreateConnection())
            {
                // Execute the stored procedure to add or update data


                response = (await con.QueryAsync<JsonResponse>(DapperConstants.adm_createcalculationfield,
              new
              {
                  id=request.id,
                  calc_field1=request.calc_field1,
                  calc_field1_transformation =request.calc_field1_transformation,
                  calc_field2=request.calc_field2,
                  mid_operator=request.mid_operator,
                  calc_field2_transformation=request.calc_field2_transformation,
                  enable_post_operator=request.enable_post_operator,
                  post_operator=request.post_operator,
                  post_operator_val=request.post_operator_val,
                  field_id=request.field_id,
                  created_datetime=DateTime.Now,
                  created_by=request.created_by,
                  modified_datetime=request.modified_by,
                  modified_by=request.modified_by



              },
          commandType: CommandType.StoredProcedure)).FirstOrDefault();


                if (response.Status == ApiMessageResource.SuccessStatusCode)
                {
                    response.Id = response.Id;
                    response.Status = response.Status;
                    response.Message = response.Message;
                }
                else
                {
                    response.Id = null;
                    response.Status = response.Status;
                    response.Message = response.Message;
                }
            }
            return response;
      }
       
      
    }
}

