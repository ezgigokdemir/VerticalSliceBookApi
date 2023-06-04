using Book.Api.Features.Book.Commands;
using Book.Api.Features.Book.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Book.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public ActionResult<AddBookResponse> AddBook([FromBody] AddBookCommand request) 
        {
            
            var response = _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<GetBookByIdResponse> GetAllBooks([FromBody] GetBookByIdCommand request)
        {

            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
