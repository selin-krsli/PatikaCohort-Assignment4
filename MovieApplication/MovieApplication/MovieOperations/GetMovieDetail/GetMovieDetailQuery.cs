using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Comman;
using MovieApplication.DBOperations;
using System.Reflection.Metadata;

namespace MovieApplication.MovieOperations.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly MovieApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public GetMovieDetailQuery(MovieApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(movie => movie.MovieId == MovieId).FirstOrDefault();
            if (movie == null)
                throw new InvalidOperationException("Movie record is not found!!");

            //aldığım movie'yi ViewModele maplemem lazım.
            //MovieDetailViewModel viewModel = new MovieDetailViewModel();
            MovieDetailViewModel viewModel = _mapper.Map<MovieDetailViewModel>(movie); 
            return viewModel;
        }
    }
    public class MovieDetailViewModel
    {
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string ReleaseYear { get; set; }
        public double Price { get; set; }
        public double IMDB { get; set; }
        public string MovieStory { get; set; }
    }
}
