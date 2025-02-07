using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common.Interfaces;
using CleanArchitecture.ApplicationCore.Common.Models;
using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Command;
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
    public class DeleteResponse : IRequest<JsonResponse>
    {
        public int id { get; set; }
    }

    public class DeleteResponseHandler : IRequestHandler<DeleteResponse, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;

        public DeleteResponseHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        
        public async Task<JsonResponse> Handle(DeleteResponse request, CancellationToken cancellationToken)
        {
            JsonResponse response = new JsonResponse();

            using (var con = _context.CreateConnection())
            {
                response = (await con.QueryAsync<JsonResponse>(DapperConstants.adm_delete_response_field,
                     new
                     {
                         id = request.id,
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
