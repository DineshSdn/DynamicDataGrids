using Application;
using Application.CarePlanHealthProfile.Query;
using Application.DynamicDatagridsCQ.Command;
using Application.DynamicDatagridsCQ.Query;
using Application.DynamicDatagridsCQ.ViewModel;
using CleanArchitecture.ApplicationCore.CarePlanHealthProfileCQ.Query;
using CleanArchitecture.ApplicationCore.Common.Models;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Command;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.Query;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicDataGridController : ApiController
    {
        private readonly ILogger<DynamicDataGridController> _logger;
        private readonly IApplicationDBContext _context;
        public DynamicDataGridController(ILogger<DynamicDataGridController> logger, IApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetDynamicDataGridList")]
        public async Task<ActionResult<List<DynamicDataGridData>>> GetDynamicDataGridList([FromQuery] GetDynamicDataGridQuery query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet("GetDynamicDataGridMasterData")]
        public async Task<ActionResult<DynamicGridMasterDto>> GetDynamicDataGridMasterData([FromQuery] GetAllDynamicGridMasterQuery query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost("CreateNewDynamicGrid")]
        public async Task<ActionResult<JsonResponse>> CreateNewDynamicGrid([FromBody] CreateNewDynamicGridCommand query)
        {
            try
            {

                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        [HttpPost("CreateNewDgField")]
        public async Task<ActionResult<JsonResponse>> CreateNewDgField([FromBody] CreateNewDgFieldCommand query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet("GetDgFieldList")]
        public async Task<ActionResult<DgFieldDto>> GetDgFieldList([FromQuery] GetDgFieldsQuery query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        [HttpGet("DeleteDgField")]
        public async Task<ActionResult<JsonResponse>> DeleteDgField([FromQuery] DeleteDgFieldCommand query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost("CreateNewFieldResponse")]
        public async Task<ActionResult<JsonResponse>> CreateNewFieldResponse([FromBody] CreateNewFieldResponseCommand query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        [HttpGet("Data")]
        public async Task<ActionResult> Getdata()
        {
            try
            {
                // Execute query to fetch data from dg_fields table
                var dgFieldsData = await _context.dg_fields.ToListAsync();

                // Check if data is found
                if (dgFieldsData == null || dgFieldsData.Count == 0)
                {
                    // Return appropriate response if data is not found
                    return NotFound();
                }

                // If data is found, return it in the response
                return Ok(dgFieldsData);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                // Return an error response
                return StatusCode(500, "An error occurred while fetching data.");
            }
        }

        [HttpGet("GetDynamicResponse")]
        public async Task<ActionResult<List<DgFieldResponseDto>>> GetDynamicResponse([FromQuery] GetDynamicResponse query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost("UpdateDetailSortOrder")]
        public async Task<IActionResult> UpdateDetailSortOrder([FromBody] int[] dgFieldInputModels)
        {
            try
            {
                // Call the MediatR command to update the detail sort order
                await Mediator.Send(new UpdateDetailSortOrder { DgFieldInputModels = dgFieldInputModels });

                // Return success response
                return Ok("Detail sort order updated successfully.");
            }
            catch (ArgumentException ex)
            {
                // Return bad request if input list is empty
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                // Return not found if record with specific Id not found
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can log the exception here if needed

                // Return server error
                return StatusCode(500, "An error occurred while updating detail sort order.");
            }
        }







        [HttpPost("UpdateHorizontalSortOrder")]
        public async Task<IActionResult> UpdatehorizontalSortOrder([FromBody] int[] dgFieldInputModels)
        {
            try
            {
                // Call the MediatR command to update the detail sort order
                await Mediator.Send(new UpdateHorizontalsortorder { DgFieldInputModels = dgFieldInputModels });

                // Return success response
                return Ok("Detail sort order updated successfully.");
            }
            catch (ArgumentException ex)
            {
                // Return bad request if input list is empty
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                // Return not found if record with specific Id not found
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can log the exception here if needed

                // Return server error
                return StatusCode(500, "An error occurred while updating detail sort order.");
            }
        }





        [HttpGet("GetDgHealthProfileGrids")]
        public async Task<ActionResult<List<DtoforhealthProfile>>> GetDgHealthProfileGrids([FromQuery] GetDgHealthProfileGridsQuery query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }



        [HttpGet("{gridId}")]
        public async Task<ActionResult<List<Dg_field_newDto>>> GetGridData(int gridId)
        {
            try
            {
                var query = new getgridData { GridId = gridId };
                var data = await Mediator.Send(query);
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("responseofuser")]
        public async Task<ActionResult<JsonResponse>> responseof_users([FromBody] AddnewResponse query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseDto>>> GetGrid_response(int get_grid_Id)
        {
            try
            {
                var query = new GetResponse { GridId = get_grid_Id };
                var data = await Mediator.Send(query);
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("postoption")]
        public async Task<ActionResult<JsonResponse>> OpstNewOption([FromBody] Addoption query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        [HttpGet("All option")]
        public async Task<ActionResult<List<public_class_MultipleChoiseDto>>> Get_optionsbyid(int QuestionId)
        {
            try
            {
                var query = new GetOptionsbyId { QuestionId = QuestionId };
                var data = await Mediator.Send(query);
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("CreateNewCalculation")]
        public async Task<ActionResult<JsonResponse>> CreateNewCalculation([FromBody] CreateNewCalculationField query)
        {
            try
            {

                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet("formula_by_field_id")]
        public async Task<ActionResult<List<Calculation_Dto>>> GetFormula_by_field_id(int field_id)
        {
            try
            {
                var query = new GetFormulaById { field_id = field_id };
                var data = await Mediator.Send(query);
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpGet("DeleteResponse")]
        public async Task<ActionResult<JsonResponse>> DeleteResponse([FromQuery] DeleteResponse query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


       






    }


}


