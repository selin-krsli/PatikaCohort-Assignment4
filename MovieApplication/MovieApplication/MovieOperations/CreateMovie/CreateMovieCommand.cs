using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApplication.DBOperations;

namespace MovieApplication.MovieOperations.CreateBook
{
    public class CreateMovieCommand
    {
        private readonly MovieApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieModel Model { get; set; }
        public CreateMovieCommand(MovieApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(movie => movie.MovieName == Model.MovieName);

            if (movie != null)
                throw new InvalidOperationException("Movie is already exist!!");

            //context'im Entity alıyor, Entity'i yaratıp onun fieldlarına Model içerisinden setliyor olmam gerekiyor.
            //movie = new Movie();
            movie = _mapper.Map<Movie>(Model); //Model ile gelen veriyi Movie objesine convert et.
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            
        }
        //buradaki model Usera göstermek istediğimiz model değil almak sitediğimiz model, input.
        //Yani controllerdaki Entity Model'e karşılık geliyor.
        public class CreateMovieModel
        {
            public string MovieName { get; set; }
            public string Director { get; set; }
            public int GenreId { get; set; }
            public DateTime ReleaseYear { get; set; }
            public double IMDB { get; set; }
            public double Price { get; set; }
            public string MovieStory { get; set; }
        }
    }
}
