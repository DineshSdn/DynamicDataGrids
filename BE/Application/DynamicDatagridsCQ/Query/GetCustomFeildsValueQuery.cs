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
    public class GetCustomFeildsValueQuery : IRequest<List<CustomFieldValuesDto>>
    {
        public int patient_empi {get;set;}
    }

    public class GetCustomFeildsValueQueryHandler : IRequestHandler<GetCustomFeildsValueQuery, List<CustomFieldValuesDto>>
    {
        private readonly IDapperContext _context;

        public GetCustomFeildsValueQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<CustomFieldValuesDto>> Handle(GetCustomFeildsValueQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    
                    var response = (await con.QueryAsync<CustomFieldValuesDto>("app.mst_getCustomFeildValue", new
                    {

                        patient_empi = request.patient_empi
                    },
                          commandType: CommandType.StoredProcedure)).ToList<CustomFieldValuesDto>();

 
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
