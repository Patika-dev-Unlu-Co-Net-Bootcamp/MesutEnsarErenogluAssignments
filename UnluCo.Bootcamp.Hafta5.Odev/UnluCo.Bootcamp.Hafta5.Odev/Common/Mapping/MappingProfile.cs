using AutoMapper;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.QueryVMs;
using UnluCo.Bootcamp.Hafta2.Odev.Entity;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Account;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Movie.QueryVMs;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Common.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            #region Movie  
            //GetMovies
            CreateMap<Movie, GetMoviesQueryVM>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FullName))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

            //GetMovieDetail
            CreateMap<Movie, GetMovieDetailQueryVM>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FullName))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

            //CreateMovieCommand
            CreateMap<CreateMovieCommandVM, Movie>();

            //UpdateMovieCommand
            CreateMap<UpdateMovieCommandVM, Movie>();

            //GetMoviebyNameQuery
            CreateMap<Movie, GetMoviebyNameQueryVM>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FullName))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

            //GetMoviesbyFilterQuery
            CreateMap<Movie, GetMoviesbyFilterQueryVM>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FullName))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

            #endregion

            #region Account 
            //RegisterModel
            CreateMap<RegisterModel, AppUser>();

            #endregion

        }
    }
}
