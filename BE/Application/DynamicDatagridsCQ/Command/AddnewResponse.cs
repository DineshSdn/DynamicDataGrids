using CleanArchitecture.ApplicationCore.Common.Interfaces;
using CleanArchitecture.ApplicationCore.Common.Models;
using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Command;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.DynamicDatagridsCQ.ViewModel;
using Dapper;
using FluentValidation.Validators;

namespace Application.DynamicDatagridsCQ.Command
{
    public class AddnewResponse : IRequest<JsonResponse>
    {
        public List<ResponseDto> responsedto { get; set; }
    }

    public class AddnewResponseHandler : IRequestHandler<AddnewResponse, JsonResponse>
    {
        private readonly IDapperContext _context;
        private readonly ICurrentUserService _userService;

        public AddnewResponseHandler(IDapperContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<JsonResponse> Handle(AddnewResponse request, CancellationToken cancellationToken)
        {
            JsonResponse response = new JsonResponse();

            using (var con = _context.CreateConnection())
            {
                var insertedId = await con.QuerySingleAsync<int>(
                    "InsertResponse",
                    new
                    {   id= request.responsedto.FirstOrDefault()?.id,
                        userid = request.responsedto.FirstOrDefault()?.userid,
                        gridid = request.responsedto.FirstOrDefault()?.gridid,
                        Queid = request.responsedto.FirstOrDefault()?.questionid,
                        question = request.responsedto.FirstOrDefault()?.question,
                        response = request.responsedto.FirstOrDefault()?.response,
                        time = request.responsedto.FirstOrDefault()?.time
                    },
                    commandType: CommandType.StoredProcedure);

                response.Data = insertedId;
            }

            return response;
        }
    }
}