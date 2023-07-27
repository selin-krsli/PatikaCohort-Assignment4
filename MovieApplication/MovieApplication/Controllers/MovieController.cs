using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.DBOperations;
using MovieApplication.MovieOperations.CreateBook;
using MovieApplication.MovieOperations.CreateMovie;
using MovieApplication.MovieOperations.DeleteMovie;
using MovieApplication.MovieOperations.GetMovieDetail;
using MovieApplication.MovieOperations.GetMovies;
using MovieApplication.MovieOperations.UpdateBook;
using MovieApplication.MovieOperations.UpdateMovie;
using static MovieApplication.MovieOperations.CreateBook.CreateMovieCommand;
using static MovieApplication.MovieOperations.UpdateBook.UpdateMovieCommand;

namespace MovieApplication.Controllers
{
    [ApiController]
    [Route("first-week/hmw/[controller]s")]
    public class MovieController: ControllerBase
    {
        //constructorlar aracılığyla inject edilen DbContexi alabilirim.
        private readonly MovieApplicationDbContext _context;
        private readonly IMapper _mapper;
      
        public MovieController(MovieApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] 
        public IActionResult GetMovies()
        {
            GetMovieQuery query = new GetMovieQuery(_context,_mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByMovieId(int id)
        {          
            object result = null;
            try
            {
                GetMovieDetailQuery query = new GetMovieDetailQuery(_context,_mapper);
                query.MovieId = id;
                GetMovieDetailQueryValidator validationRules = new GetMovieDetailQueryValidator();
                validationRules.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }         
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            try
            {

                command.Model = newMovie;
                CreateMovieCommandValidator validationRules = new CreateMovieCommandValidator();
                validationRules.ValidateAndThrow(command); 
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdatedMovieViewModel updatedMovie)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            try
            {
                command.MovieId = id;
                command.Model = updatedMovie;
                UpdateMovieCommandValidator validationRules = new UpdateMovieCommandValidator();
                validationRules.ValidateAndThrow(command);
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.MovieId = id;
                DeleteMovieCommandValidator validationRules = new DeleteMovieCommandValidator();
                validationRules.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();

        }

    }
}
