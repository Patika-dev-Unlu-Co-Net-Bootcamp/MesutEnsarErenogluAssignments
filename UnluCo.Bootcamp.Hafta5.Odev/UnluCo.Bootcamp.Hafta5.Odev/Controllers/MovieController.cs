using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries.GetMovies;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.CommandVMs;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.QueryVMs;
using UnluCo.Bootcamp.Hafta2.Odev.Application.MovieOperations.Queries;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Common;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    //we can't add the attribute as usual on a controller since it has to get dependencies at runtime.
    //The key difference is that TypeFilterAttribute will figure out what are the filters dependencies, fetches them through DI, and creates the filter.
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public MovieController(AppDbContext db,IMapper mapper,IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _db = db;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
        /// <summary>
        /// With this method, sorting, searching and pagination operations can be performed between movies according to the parameters from query.
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        
        [HttpGet]
        [ResponseCache(Duration = 30000, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult GetMoviesbyFilter([FromQuery] FilterQueryParams queryParams)
        {
            GetMoviesByFilterQuery query = new GetMoviesByFilterQuery(_db, _mapper);
            query.Params = queryParams;
            var response = query.Handle();

            Response.Headers.Add("PaggingInfo", System.Text.Json.JsonSerializer.Serialize(response.PaggingInfo));
            return Ok(response.DataList);
        }




        /// <summary>
        /// This function return all movies which are active in the database 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var moviesFromCache = await _distributedCache.GetAsync("movies");
            if (moviesFromCache == null)
            {
                GetMoviesQuery query = new GetMoviesQuery(_db, _mapper);
                var result = query.Handle();
                if (result.Count >= 100) 
                {
                   await _distributedCache.SetAsync("movies", Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(result)));
                }
                return Ok(result);
            }
            var movies = System.Text.Json.JsonSerializer.Deserialize<List<GetMoviesQueryVM>>(moviesFromCache);

            return Ok(movies);

        }
        /// <summary>
        /// This function returns a movie which is active and has same Id which mentioned in the url
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet("{movieId}")]
        public IActionResult GetMoviebyId(int movieId)
        {
            _memoryCache.TryGetValue($"GetMovieDetail{movieId}", out GetMovieDetailQueryVM vm);

            if (vm == null)
            {
                GetMovieDetailQuery query = new GetMovieDetailQuery(_db, _mapper);
                query.MovieId = movieId;
                GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
                validator.ValidateAndThrow(query);

                vm = query.Handle();
                _memoryCache.Set($"GetMovieDetail{movieId}", vm, new MemoryCacheEntryOptions {
                     AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
                     Priority = CacheItemPriority.Normal
                });
            }
            
            return Ok(vm);
        }
        /// <summary>
        /// This function creates a movie and store in the database regarding to model from body 
        /// </summary>
        /// <param name="newMovie"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieCommandVM newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_db,_mapper);
            try
            {
                command.Model = newMovie;
                CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return StatusCode(201, new { message = $"{command.Model.MovieName} oluşturuldu!" });
        }
        /// <summary>
        /// This funciton updates a movie which has Id that mentioned in the url regarding to model from body
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(int movieId,[FromBody]UpdateMovieCommandVM Model)
        {
            try
            {
                UpdateMovieCommand command = new UpdateMovieCommand(_db,_mapper);
                command.Model = Model;
                command.MovieId = movieId;
                UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { message = "Güncelleme tamamlandı!" });
        }
        /// <summary>
        /// This function makes a movie's status inactive. 
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPatch("{movieId}")]
        public IActionResult DeleteMovie(int movieId, [FromBody] DeleteMovieCommandVM Model)
        {
            try
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_db);
                command.MovieId = movieId;
                command.Model = Model;
                DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new {message = "Seçilen film silindi" });
        }
        /// <summary>
        /// This function deletes a movie from database permanently
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpDelete("{movieId}")]
        public IActionResult DeleteMoviePermanently(int movieId)
        {
            try
            {
                DeleteMoviePermanentlyCommand command = new DeleteMoviePermanentlyCommand(_db);
                command.MovieId = movieId;
                if (movieId <= 0)
                {
                    return StatusCode(404,new {message="Silmek istediğiniz filme ulaşılamadı!" });
                }
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { message = "Seçilen film kalıcı olarak silindi" });
        }
        /// <summary>
        /// This function provides a movie which has same name with the name which mentioned in the query
        /// </summary>
        /// <param name="MovieName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMoviebyName([FromQuery] string MovieName)
        {
            GetMoviebyNameQueryVM vm;
            try
            {
                GetMoviebyNameQuery query = new GetMoviebyNameQuery(_db, _mapper);
                query.MovieName = MovieName;

                GetMoviebyNameQueryValidator validator = new GetMoviebyNameQueryValidator();
                validator.ValidateAndThrow(query);

                vm = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(vm);
        }

        
        

        /// <summary>
        /// This function add actors which has ID in the array from body to movie which has Id which mentiond in the url
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPut("{movieId}")]
        public  IActionResult AddActorstoMovie(int movieId,[FromBody] AddActorstoMovieCommandVM Model)
        {
            try
            {
                AddActorstoMovieCommand command = new AddActorstoMovieCommand(_db);
                command.MovieId = movieId;
                command.Model = Model;
                AddActorstoMovieCommandValidator validator = new AddActorstoMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new {message="Belirtilen aktörler eklendi!" });
        }
    }
}
