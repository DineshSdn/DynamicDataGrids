using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common.Interfaces;
using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.Common.Models;
using CleanArchitecture.ApplicationCore.MasterDataCQ.ViewModel;
using MediatR;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace Application.DynamicDatagridsCQ.Command
{
    public class CreateNewDynamicGridCommand : IRequest<JsonResponse>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool show_health_profile { get; set; }
        public int type { get; set; }
        public bool active { get; set; }

        public string code_key { get; set; }  
        public int created_by { get; set; }
   
        public string MasterDgTypes { get; set; }   
   




    //    @type = 1, -- Example value for INT datatype
    //@active = 1, -- Example value for BIT datatype(true)
    //@code_key = 'SampleCodeKey',
    //@created_by = 1, -- Example value for INT datatype
    //@MasterDgTypes = 'SampleMasterDgTypes'; -- 
    }
    public class CreateNewDynamicGridCommandHandler : IRequestHandler<CreateNewDynamicGridCommand, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;

        public CreateNewDynamicGridCommandHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<JsonResponse> Handle(CreateNewDynamicGridCommand request, CancellationToken cancellationToken)
        {
            string joined = "";
          
          
            JsonResponse response = new JsonResponse();

            using (var con = _context.CreateConnection())
            {
                // Execute the stored procedure to add or update data

                if(request.id==0)
                {
                    response = (await con.QueryAsync<JsonResponse>(DapperConstants.adm_createdynamicdatagrids,
                  new
                  {

                      id = (int?)null,
                      name = request.name,
                      description = request.description,
                      show_health_profile = request.show_health_profile,
                      type = request.type,
                      active = request.active,
                      code_key = request.code_key,
                      created_by = request.created_by,
                      MasterDgTypes = request.MasterDgTypes,

                  },
              commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
                else
                {
                    response = (await con.QueryAsync<JsonResponse>(DapperConstants.adm_createdynamicdatagrids,
                 new
                 {

                     id = request.id,
                     name = request.name,
                     description = request.description,
                     show_health_profile = request.show_health_profile,
                     type = request.type,
                     active = request.active,
                     code_key = request.code_key,
                     created_by = request.created_by,
                     MasterDgTypes = request.MasterDgTypes,

                 },
             commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
                
             

                // Update response properties based on the result
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

