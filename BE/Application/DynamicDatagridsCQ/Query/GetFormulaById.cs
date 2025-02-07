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
    public class GetFormulaById : IRequest<List<Calculation_Dto>>
    {
        public int field_id { get; set; } // Add property for GridId
    }

    public class GetFormulaByIdHandler : IRequestHandler<GetFormulaById, List<Calculation_Dto>>
    {
        private readonly IDapperContext _context;

        public GetFormulaByIdHandler(IDapperContext context)
        {
            _context = context;
        }


        public async Task<List<Calculation_Dto>> Handle(GetFormulaById request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        field_id = request.field_id
                    };

                    var dataGrids = (await con.QueryAsync<Calculation_Dto>(
                        DapperConstants.adm_get_formula_for_calculation,
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