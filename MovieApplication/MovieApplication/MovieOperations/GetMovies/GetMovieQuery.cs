using AutoMapper;
using MovieApplication.Comman;
using MovieApplication.DBOperations;

namespace MovieApplication.MovieOperations.GetMovies
{
    public class GetMovieQuery
    {
        private readonly MovieApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMovieQuery(MovieApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.OrderBy(s => s.MovieId).ToList<Movie>();

            //List<MoviesViewModel> viewModel = new List<MoviesViewModel>();
            List<MoviesViewModel> viewModel = _mapper.Map<List<MoviesViewModel>>(movieList);
            return viewModel;
        }
        public class MoviesViewModel
        {
            public string MovieName { get; set; }
            public string Director { get; set; }
            public string ReleaseYear { get; set; }
            public string Genre { get; set; }
            public double IMDB { get; set; }
            public double Price { get; set; }
            public string MovieStory { get; set; }
        }
    }
}
