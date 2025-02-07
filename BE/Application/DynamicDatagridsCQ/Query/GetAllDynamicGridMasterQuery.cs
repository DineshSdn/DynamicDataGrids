using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Dapper;
using MediatR;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Query
{
    public class GetAllDynamicGridMasterQuery : IRequest<DynamicGridMasterDto>
    {

    }

    public class GetAllDynamicGridMasterQueryHandler : IRequestHandler<GetAllDynamicGridMasterQuery, DynamicGridMasterDto>
    {
        private readonly IDapperContext _context;

        public GetAllDynamicGridMasterQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<DynamicGridMasterDto> Handle(GetAllDynamicGridMasterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    DynamicGridMasterDto dynamicGridMasterList = new DynamicGridMasterDto();
                    var response = await con.QueryMultipleAsync(DapperConstants.adm_getdynamic_grid_master_data, commandType: CommandType.StoredProcedure);

                    // read as IEnumerable<dynamic>
                    dynamicGridMasterList.dynamicGridTypes = response.Read<DynamicGridTypeDto>().AsList();
                    dynamicGridMasterList.dgFieldTypes = response.Read<DgFieldTypeDto>().ToList();
                    dynamicGridMasterList.dgLookUpDatasets = response.Read<DgLookUpDatasetDto>().ToList();
                    return dynamicGridMasterList;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
