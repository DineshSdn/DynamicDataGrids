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

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Query
{
    public class GetDynamicDataGridQuery : IRequest<List<DynamicDataGridData>>
    {
        public int id { get; set; }
    }

    public class GetDynamicDataGridQueryHandler : IRequestHandler<GetDynamicDataGridQuery, List<DynamicDataGridData>>
    {
        private readonly IDapperContext _context;

        public GetDynamicDataGridQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<DynamicDataGridData>> Handle(GetDynamicDataGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@id", request.id);

                    var dataGrids = (await con.QueryAsync<DynamicDataGridData>(DapperConstants.adm_getdynamic_data_grids, ObjParm,
                          commandType: CommandType.StoredProcedure)).ToList<DynamicDataGridData>();

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
