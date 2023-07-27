using FluentValidation;
using MovieApplication.MovieOperations.CreateBook;

namespace MovieApplication.MovieOperations.CreateMovie
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand> //Bu tanım; validasyon sınıfının CreateMovieCommand sınıfının objelerini validate eder demek oluyor.
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.ReleaseYear.Date).LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.IMDB).InclusiveBetween(3.0, 10.0);
            RuleFor(command => command.Model.MovieName).NotEmpty().MinimumLength(6);
            RuleFor(command=>command.Model.Director).NotEmpty().MinimumLength(10); 
            RuleFor(command=>command.Model.MovieStory).NotEmpty().MinimumLength(30);
            RuleFor(command=>command.Model.Price).GreaterThan(80);
        }
    }
}
