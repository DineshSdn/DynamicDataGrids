using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Query
{
    public class GetCustomFeildsQuery : IRequest<List<CustomFieldsDto>>
    {
        
    }

    public class GetCustomFeildsQueryHandler : IRequestHandler<GetCustomFeildsQuery, List<CustomFieldsDto>>
    {
        private readonly IDapperContext _context;

        public GetCustomFeildsQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<CustomFieldsDto>> Handle(GetCustomFeildsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    
                    var response = (await con.QueryAsync<CustomFieldsDto>("app.mst_getCustomFeilds", ObjParm,
                          commandType: CommandType.StoredProcedure)).ToList<CustomFieldsDto>();

 
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
