using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;
using UnluCo.Bootcamp.Hafta2.Odev.Common.Extensions;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Common;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Movie.QueryVMs;

namespace UnluCo.Bootcamp.Hafta2.Odev.Application.MovieOperations.Queries
{
    public class GetMoviesByFilterQuery
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public FilterQueryParams Params { get; set; }


        public GetMoviesByFilterQuery(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public FilterResponseModel<GetMoviesbyFilterQueryVM> Handle()
        {
         
            FilterResponseModel<Movie> movieReponse = _db.Movies.Include(x=>x.Director).Include(x=>x.Genre).GetDataAndPaggingInfo<Movie>(Params);
            var responseModels = _mapper.Map<List<GetMoviesbyFilterQueryVM>>(movieReponse.DataList);

            FilterResponseModel<GetMoviesbyFilterQueryVM> vmResponse = new FilterResponseModel<GetMoviesbyFilterQueryVM>();
            vmResponse.DataList = responseModels;
            vmResponse.PaggingInfo = movieReponse.PaggingInfo;

            foreach (var item in vmResponse.DataList)
            {
                item.ActorNames = _db.MovieAndActors.Where(x => x.Movie.MovieName == item.MovieName).Select(x => x.Actor.FullName).ToArray();
                
            }
            return vmResponse;
        }
    }
}
