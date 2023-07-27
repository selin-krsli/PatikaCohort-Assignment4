using AutoMapper;
using MovieApplication.MovieOperations.GetMovieDetail;
using static MovieApplication.MovieOperations.CreateBook.CreateMovieCommand;
using static MovieApplication.MovieOperations.GetMovies.GetMovieQuery;
using static MovieApplication.MovieOperations.UpdateBook.UpdateMovieCommand;

namespace MovieApplication.Comman
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMovieModel, Movie'ye maplenebilir olsun. Birincisi source ikinci parametre ise destination.
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Movie, MoviesViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            
        }
    }
}
