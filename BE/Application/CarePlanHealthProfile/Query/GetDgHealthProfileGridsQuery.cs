using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.CarePlanHealthProfileCQ.Query
{
    public class GetDgHealthProfileGridsQuery : IRequest<List<DtoforhealthProfile>>
    {

    }

    public class GetDgHealthProfileGridsQueryHandler : IRequestHandler<GetDgHealthProfileGridsQuery, List<DtoforhealthProfile>>
    {
        private readonly IDapperContext _context;

        public GetDgHealthProfileGridsQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<DtoforhealthProfile>> Handle(GetDgHealthProfileGridsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    var dataGrids = (await con.QueryAsync<DtoforhealthProfile>(DapperConstants.adm_get_health_profile_grids,
                          commandType: CommandType.StoredProcedure)).ToList();

                    return dataGrids;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
