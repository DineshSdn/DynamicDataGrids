using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Query;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace Application.DynamicDatagridsCQ.Query
{
    public class GetDynamicResponse : IRequest<List<DgFieldResponseDto>>
    {
        public int fieldid { get; set; }
    }

    public class GetDynamicResponseHandler : IRequestHandler<GetDynamicResponse, List<DgFieldResponseDto>>
    {
        private readonly IDapperContext _context;

        public GetDynamicResponseHandler(IDapperContext context)
        {
            _context = context;
        }

     

        public async Task<List<DgFieldResponseDto>> Handle(GetDynamicResponse request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@fieldid", request.fieldid);

                    var dataGrids = (await con.QueryAsync<DgFieldResponseDto>(DapperConstants.adm_getdynamic_response, ObjParm,
                        commandType: CommandType.StoredProcedure)).ToList<DgFieldResponseDto>();

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
