using CleanArchitecture.ApplicationCore.Common;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DynamicDatagridsCQ.Command
{
    public class UpdateDetailSortOrder : IRequest<Unit>
    {
        public int[] DgFieldInputModels { get; set; }
    }

    public class UpdateDetailSortOrderHandler : IRequestHandler<UpdateDetailSortOrder, Unit>
    {
        private readonly IDapperContext _context;

        public UpdateDetailSortOrderHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDetailSortOrder request, CancellationToken cancellationToken)
        {
            int srnumber = 1;
            try
            {
                if (request.DgFieldInputModels == null || !request.DgFieldInputModels.Any())
                {
                    throw new ArgumentException("Input list cannot be empty.");
                }

                using (var con = _context.CreateConnection())
                {
                    foreach (var id in request.DgFieldInputModels)
                    {
                        var sqlCommand = $"SELECT * FROM dg_fields WHERE id = @id";
                        var dgField = await con.QueryFirstOrDefaultAsync<DgField>(sqlCommand, new { id });

                        if (dgField == null)
                        {
                            throw new KeyNotFoundException($"Record with Id {id} not found.");
                        }

                        dgField.detail_sort_order = srnumber;
                        srnumber++;
                    }
                    srnumber = 1;
                    foreach (var id in request.DgFieldInputModels)
                    {
                        var sqlCommand = $"UPDATE dg_fields SET detail_sort_order = @detail_sort_order WHERE id = @id";
                        await con.ExecuteAsync(sqlCommand, new { detail_sort_order = srnumber, id });
                        srnumber++;
                    }
                }

                return Unit.Value; // Success
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating detail sort order.", ex);
            }
        }
    }
}
