using CleanArchitecture.ApplicationCore.CarePlanHealthProfileCQ.Query;
using CleanArchitecture.ApplicationCore.Common.Constants;
using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DynamicDatagridsCQ.ViewModel;
using Dapper;

namespace Application.CarePlanHealthProfile.Query
{
    public class getgridData : IRequest<List<Dg_field_newDto>>
    {
        public int GridId { get; set; } // Add property for GridId
    }

    public class getgridDataHandler : IRequestHandler<getgridData, List<Dg_field_newDto>>
    {
        private readonly IDapperContext _context;

        public getgridDataHandler(IDapperContext context)
        {
            _context = context;
        }
       
        public async Task<List<Dg_field_newDto>> Handle(getgridData request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        GridId = request.GridId // Replace yourGridIdValue with the actual value of GridId
                    };

                    var dataGrids = (await con.QueryAsync<Dg_field_newDto>(
                        DapperConstants.adm_get_health_profile_grids1,
                        parameters,
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