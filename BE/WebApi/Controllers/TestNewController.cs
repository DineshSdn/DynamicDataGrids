using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.DynamicDataGridsCQ.ViewModel;
using Domain.Entities;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestNewController : ControllerBase
    {
        private readonly ILogger<DynamicDataGridController> _logger;
        private readonly IApplicationDBContext _context;

        public TestNewController(ILogger<DynamicDataGridController> logger, IApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Data")]
        public async Task<ActionResult> Getdata()
        {
            try
            {
                var dgFieldsData = await _context.dg_fields.ToListAsync();

                if (dgFieldsData == null || dgFieldsData.Count == 0)
                {
                    return NotFound();
                }

                return Ok(dgFieldsData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while fetching data.");
            }
        }


        [HttpGet("Response")]
        public async Task<ActionResult> GetResponsebasedonid()
        {
            try
            {
                var dgFieldsData = await _context.dg_field_responses
                             .ToListAsync();


                if (dgFieldsData == null || dgFieldsData.Count == 0)
                {
                    return NotFound();
                }

                return Ok(dgFieldsData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occurred while fetching data.");
            }
        }


        [HttpPost("post_master_dg_type")]
        public async Task<ActionResult> postmaster([FromBody] int[] dgFieldInputModels)
        {

            var list = new List<MasterDgTypes>
            {

                new MasterDgTypes
                {
                    id=1,
                    name = "Tabular",
                    code = "tabular",
                    active = true,
                    created_datetime = DateTime.Now,
                    created_by = 1,
                    modified_datetime=null,
                    modified_by = null,

                },
                new MasterDgTypes
                {
                    id=2,
                    name = "Multi-Line",
                    code = "multirow",
                    active = true,
                    created_datetime = DateTime.Now,
                    created_by = 1,
                    modified_datetime=null,
                    modified_by = null,

                }
            };

            Func<MasterDgTypes, MasterDgTypes, bool> matchCondition = (x, y) =>
            {
                return string.Equals(x.name, y.name, StringComparison.InvariantCultureIgnoreCase);
            };

            _context.PerformDataSeed(list, matchCondition);
            return Ok(list);
        }



        [HttpPost("post_master_dg_field_type")]
        public async Task<ActionResult> postmastertypes([FromBody] int[] dgFieldInputModels)
        {


            var list = new List<MasterDgFieldTypes>
            {

                new MasterDgFieldTypes
                {
                    
                    name = "Text",
                    code = "text",
                    has_response_values=true,
                    active = true,
                    created_datetime = DateTime.Now,
                    created_by = 1,
                    modified_datetime=null,
                    modified_by = null,

                },
                new MasterDgFieldTypes
                {
                    
                    name = "Textarea",
                    code = "textarea",
                    has_response_values=true,
                    active = true,
                    created_datetime = DateTime.Now,
                    created_by = 1,
                    modified_datetime=null,
                    modified_by = null,

                },
              
                  new MasterDgFieldTypes
                {
                   
                    name = "Dropdown",
                    code = "dropdown",
                    has_response_values=true,
                    active = true,
                    created_datetime = DateTime.Now,
                    created_by = 1,
                    modified_datetime=null,
                    modified_by = null,

                },
                   new MasterDgFieldTypes
                {
                 
                    name = "Multiselect",
                    code = "multiselect",
                    has_response_values=true,
                    active = true,
                    created_datetime = DateTime.Now,
                    created_by = 1,
                    modified_datetime=null,
                    modified_by = null,

                },
                    new MasterDgFieldTypes
                {
                  
                    name = "Calculated",
                    code = "calculated",
                    has_response_values=true,
                    active = true,
                    created_datetime = DateTime.Now,
                    created_by = 1,
                    modified_datetime=null,
                    modified_by = null,

                },

            };

            Func<MasterDgFieldTypes, MasterDgFieldTypes, bool> matchCondition = (x, y) =>
            {
                return string.Equals(x.name, y.name, StringComparison.InvariantCultureIgnoreCase);
            };

            _context.PerformDataSeed(list, matchCondition);
            return Ok(list);
        }

        [HttpPost("Data")]
        public async Task<ActionResult> PostData([FromBody] int[] dgFieldInputModels)
        {
            

            int srnumber = 1;
            try
            {
                // Check if input list is empty
                if (dgFieldInputModels == null || !dgFieldInputModels.Any())
                {
                    return BadRequest("Input list cannot be empty.");
                }

                // Iterate through the input list and set the detail_sort_order asynchronously
                foreach (var id in dgFieldInputModels)
                {
                    // Find the corresponding record in the database asynchronously
                    var dgField = await _context.dg_fields.FirstOrDefaultAsync(d => d.id == id);

                    // If record is not found, return appropriate response
                    if (dgField == null)
                    {
                        return NotFound($"Record with Id {id} not found.");
                    }

                    // Set the detail_sort_order
                    dgField.detail_sort_order = srnumber;
                    srnumber++;
                }

                // Save changes to the database asynchronously
                await _context.SaveChangesAsync();

                // Return success response
                return Ok("Detail sort order updated successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, ex.Message);
                // Return an error response
                return StatusCode(500, "An error occurred while updating detail sort order.");
            }
        }


    }
}