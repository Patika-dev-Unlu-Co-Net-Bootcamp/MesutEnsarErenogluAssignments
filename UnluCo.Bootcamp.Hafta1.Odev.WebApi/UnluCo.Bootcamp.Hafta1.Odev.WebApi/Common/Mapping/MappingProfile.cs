using AutoMapper;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.QueryVMs;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Common.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            //Movie  
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


        }
    }
}
