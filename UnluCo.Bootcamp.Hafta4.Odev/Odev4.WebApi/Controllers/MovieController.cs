using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odev4.WebApi.Filter;
using Odev4.WebApi.Models.Movie;
using System;
using System.Threading.Tasks;

namespace Odev4.WebApi.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomResultFilterAttribute))]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetAllActive();
            
            return Ok(movies);
        }
        
        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMoviebyId(int movieId)
        {
            var movie = await _movieService.GetbyId(movieId);
            return Ok(movie);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieModel Model)
        {
            try
            {
                MovieDto movieDto = new MovieDto();
                movieDto.MovieName = Model.MovieName;
                movieDto.ReleaseDate = Model.ReleaseDate;
                await _movieService.Add(movieDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        
    }
}
