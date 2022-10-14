using BLL.DTO.Requests;
using BLL.DTO.Responses;
using BLL.Interfaces.Services;
using BLL.Validation.Requests;
using DAL.Exceptions;
using DAL.Pagination;
using DAL.Parameters;
using EFController.Extension;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EFController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieService movieService;
        IMovieService cinemaService;

        public MovieController(IMovieService movieService, IMovieService cinemaService)
        {
            this.movieService = movieService;
            this.cinemaService = cinemaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PagedList<MovieResponse>>> GetPagedAsync([FromQuery] MovieParameters parameters)
        {
            try
            {
                if (!parameters.ValidPriceRange)
                {
                    return BadRequest("Max price cannot be less than min price.");
                }
                else if (!parameters.ValidSeanceTimeRange)
                {
                    return BadRequest("Max production time cannot be less than min production time.");
                }

                var movie = await movieService.GetAsync(parameters);

                Response.Headers.Add("X-Pagination", movie.SerializeMetadata());

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieResponse>> GetByIdAsync(int id)
        {
            try
            {
                return Ok(await movieService.GetByIdAsync(id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertAsync([FromBody] MovieRequest request)
        {
            try
            {
                ValidationResult results = new MovieRequestValidator().Validate(request);
                if (!results.IsValid)
                    return BadRequest(results.ToString("\n"));

                var cinema = await cinemaService.GetByIdAsync(request.CinemaId);
                if (cinema == null)
                    return BadRequest("Invalid cinemaId");

                await movieService.InsertAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAsync([FromBody] MovieRequest request)
        {
            try
            {
                ValidationResult results = new MovieRequestValidator().Validate(request);
                if (!results.IsValid)
                    return BadRequest(results.ToString("\n"));

                var shop = await cinemaService.GetByIdAsync(request.CinemaId);
                if (shop == null)
                    return BadRequest("Invalid cinemaId");

                await movieService.UpdateAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await movieService.DeleteAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
