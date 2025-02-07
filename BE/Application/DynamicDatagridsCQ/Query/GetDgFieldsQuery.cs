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
    public class GetDgFieldsQuery : IRequest<DgFieldDto>
    {
        public int id { get; set; }
        public int grid_id { get; set; }
    }

    public class GetDgFieldsQueryHandler : IRequestHandler<GetDgFieldsQuery, DgFieldDto>
    {
        private readonly IDapperContext _context;

        public GetDgFieldsQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<DgFieldDto> Handle(GetDgFieldsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using (var con = _context.CreateConnection())
                {
                    DgFieldDto dgFieldDto = new DgFieldDto();
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@id", request.id);
                    ObjParm.Add("@datagridId", request.grid_id);

                    var response = (await con.QueryMultipleAsync(DapperConstants.adm_get_dg_fields, ObjParm,
                          commandType: CommandType.StoredProcedure));

                    dgFieldDto.fields = response.Read<DgField>().AsList();
                    dgFieldDto.field_calculations = response.Read<DgFieldCalculation>().AsList();
                    dgFieldDto.dgFieldResponses = response.Read<DgFieldResponseDto>().AsList();
                    dgFieldDto.dgFieldCodesDtos = response.Read<DgFieldCodesDto>().AsList();
                    dgFieldDto.dgFieldCPTCodesDtos = response.Read<DgFieldCPTCodesDto>().AsList();

                    if (dgFieldDto.fields.Any() && dgFieldDto.dgFieldResponses.Any())
                    {
                        dgFieldDto.fields.ForEach(i =>
                        {
                            var response = dgFieldDto.dgFieldResponses.Where(x => x.field_id == i.id).ToList();
                            if (response != null && response.Any())
                            {
                                i.field_response = response.OrderBy(i => i.response_sort_order).ToList();
                            }
                        });
                    }

                    if (dgFieldDto.fields.Any() && dgFieldDto.dgFieldCodesDtos.Any())
                    {
                        dgFieldDto.fields.ForEach(i =>
                        {
                            var suspects = dgFieldDto.dgFieldCodesDtos.Where(x => x.field_id == i.id).ToList();
                            if (suspects != null && suspects.Any())
                            {
                                i.field_suspects = suspects;
                            }
                        });
                    }

                    if (dgFieldDto.fields.Any() && dgFieldDto.dgFieldCPTCodesDtos.Any())
                    {
                        dgFieldDto.fields.ForEach(i =>
                        {
                            var cptcodes = dgFieldDto.dgFieldCPTCodesDtos.Where(x => x.field_id == i.id).ToList();
                            if (cptcodes != null && cptcodes.Any())
                            {
                                i.field_cpt = cptcodes;
                            }
                        });
                    }

                    return dgFieldDto;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
