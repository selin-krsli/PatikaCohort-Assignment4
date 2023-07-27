using FluentValidation;
using MovieApplication.MovieOperations.UpdateBook;

namespace MovieApplication.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommandValidator:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command=>command.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.Price).GreaterThan(80);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.MovieName).NotEmpty().MinimumLength(6);
            RuleFor(command => command.Model.MovieStory).NotEmpty().MinimumLength(30);
        }
    }
}
