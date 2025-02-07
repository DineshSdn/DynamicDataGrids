using Application.DynamicDatagridsCQ.ViewModel;
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
using System.Xml.Linq;
using Dapper;

namespace Application.DynamicDatagridsCQ.Command
{
    public class Addoption : IRequest<JsonResponse>
    {
        public List<public_class_MultipleChoiseDto> optiondto { get; set; }
    }

    public class AddoptionHandler : IRequestHandler<Addoption, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;

        public AddoptionHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<JsonResponse> Handle(Addoption request, CancellationToken cancellationToken)
        {
            JsonResponse response = new JsonResponse();

            // Convert DgFieldResponseDto list to XMLId	DgFieldId	Option
     
            XElement xEleResponses = new XElement("DgFieldResponse",
                from result in request.optiondto
                select new XElement("Response",
                    new XElement("DgFieldId", result.DgFieldId),
                    new XElement("Option", result.Option)
                ));

            using (var con = _context.CreateConnection())
            {
                // Execute stored procedure InsertIntoDgFieldResponse
                response = (await con.QueryAsync<JsonResponse>("InsertMultipleChoiceOption_first",
                    new
                    {
                        input_id = request.optiondto.FirstOrDefault()?.DgFieldId,
                        input_option = request.optiondto.FirstOrDefault()?.Option
                    },
                    commandType: CommandType.StoredProcedure)).FirstOrDefault();    
            }

            return response;
        }

      
    }
}
