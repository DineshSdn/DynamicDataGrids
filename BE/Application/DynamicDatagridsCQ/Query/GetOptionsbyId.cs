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
    public class GetOptionsbyId : IRequest<List<public_class_MultipleChoiseDto>>
    {
        public int QuestionId { get; set; } // Add property for GridId
    }

    public class GetOptionsbyIdHandler : IRequestHandler<GetOptionsbyId, List<public_class_MultipleChoiseDto>>
    {
        private readonly IDapperContext _context;

        public GetOptionsbyIdHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<public_class_MultipleChoiseDto>> Handle(GetOptionsbyId request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        QuestionId = request.QuestionId
                    };

                    var dataGrids = (await con.QueryAsync<public_class_MultipleChoiseDto>(
                        DapperConstants.adm_get_option_id,
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