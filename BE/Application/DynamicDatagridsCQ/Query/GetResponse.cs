using Application.CarePlanHealthProfile.Query;
using Application.DynamicDatagridsCQ.ViewModel;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Application.DynamicDatagridsCQ.Query
{
    public class GetResponse : IRequest<List<Responsesenwdto>>
    {
        public int GridId { get; set; } // Add property for GridId
    }

    public class GetResponseHandler : IRequestHandler<GetResponse, List<Responsesenwdto>>
    {
        private readonly IDapperContext _context;

        public GetResponseHandler(IDapperContext context)
        {
            _context = context;
        }



        public async Task<List<Responsesenwdto>> Handle(GetResponse request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        GridId = request.GridId
                    };

                    var dataGrids = (await con.QueryAsync<Responsesenwdto>(
                        DapperConstants.adm_get_response_grid,
                        parameters,
                        commandType: CommandType.StoredProcedure)).ToList();

                    return dataGrids; // Wrap the list in Task.FromResult
                }
            }
            catch
            {
                throw;
            }
        }

    }
}