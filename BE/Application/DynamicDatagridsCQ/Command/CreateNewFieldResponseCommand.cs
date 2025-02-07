using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common.Interfaces;
using CleanArchitecture.ApplicationCore.Common.Models;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Command
{
    public class CreateNewFieldResponseCommand : IRequest<JsonResponse>
    {
        public List<DgFieldResponseDto> dgFieldResponses { get; set; }
    }

    public class CreateNewFieldResponseCommandHandler : IRequestHandler<CreateNewFieldResponseCommand, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;

        public CreateNewFieldResponseCommandHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<JsonResponse> Handle(CreateNewFieldResponseCommand request, CancellationToken cancellationToken)
        {
            JsonResponse response = new JsonResponse();

            // Convert DgFieldResponseDto list to XML
            XElement xEleResponses = new XElement("DgFieldResponse",        
                from result in request.dgFieldResponses
                select new XElement("Response",
                    new XElement("name", result.name),
                    new XElement("field_id", result.field_id),
                    new XElement("active", result.active),
                    new XElement("ideal_choice", result.ideal_choice),
                    new XElement("response_sort_order", result.response_sort_order),
                    new XElement("created_datetime", result.created_datetime),
                    new XElement("created_by", result.created_by),
                    new XElement("modified_datetime", result.modified_datetime),
                    new XElement("modified_by", result.modified_by)
                ));

            using (var con = _context.CreateConnection())
            {
                // Execute stored procedure InsertIntoDgFieldResponse
                response = (await con.QueryAsync<JsonResponse>("InsertIntoDgFieldResponse",
                    new
                    {
                        name = request.dgFieldResponses.FirstOrDefault()?.name,
                        field_id = request.dgFieldResponses.FirstOrDefault()?.field_id,
                        active = request.dgFieldResponses.FirstOrDefault()?.active,
                        ideal_choice = request.dgFieldResponses.FirstOrDefault()?.ideal_choice,
                        response_sort_order = request.dgFieldResponses.FirstOrDefault()?.response_sort_order,
                        created_datetime = request.dgFieldResponses.FirstOrDefault()?.created_datetime,
                        created_by = request.dgFieldResponses.FirstOrDefault()?.created_by,
                        modified_datetime = request.dgFieldResponses.FirstOrDefault()?.modified_datetime,
                        modified_by = request.dgFieldResponses.FirstOrDefault()?.modified_by
                    },
                    commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }
            return response;
        }
    }
}

       

   