using BLL.DTO.Requests;
using BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
        ISeanceService seanceService;

        public SeanceController(ISeanceService addressService)
        {
            this.seanceService = addressService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> InsertAsync([FromBody] SeanceRequest request)
        {
            try
            {
                int id = await seanceService.InsertAsync(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
