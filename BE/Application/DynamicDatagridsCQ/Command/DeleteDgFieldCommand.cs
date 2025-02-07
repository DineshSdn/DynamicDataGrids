using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common.Interfaces;
using CleanArchitecture.ApplicationCore.Common.Models;
using Dapper;
using MediatR;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Command
{
    public class DeleteDgFieldCommand : IRequest<JsonResponse>
    {
        public int id { get; set; }
    }

    public class DeleteDgFieldCommandHandler : IRequestHandler<DeleteDgFieldCommand, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;
 
        public DeleteDgFieldCommandHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<JsonResponse> Handle(DeleteDgFieldCommand request, CancellationToken cancellationToken)
        {
            JsonResponse response = new JsonResponse();

            using (var con = _context.CreateConnection())
            {
                response = (await con.QueryAsync<JsonResponse>(DapperConstants.adm_delete_dg_field,
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
