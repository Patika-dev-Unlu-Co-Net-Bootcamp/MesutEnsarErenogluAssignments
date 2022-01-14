using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries.GetMovies;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.CommandVMs;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.QueryVMs;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public MovieController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            try
            {
                GetMoviesQuery query = new GetMoviesQuery(_db, _mapper);
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{movieId}")]
        public IActionResult GetbyMovieId(int movieId)
        {
            GetMovieDetailQueryVM getMovieDetailQueryVM;
            try
            {
                GetMovieDetailQuery query = new GetMovieDetailQuery(_db,_mapper);
                query.MovieId = movieId;
                GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
                validator.ValidateAndThrow(query);

                getMovieDetailQueryVM = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(getMovieDetailQueryVM);
        }
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
    }
}
