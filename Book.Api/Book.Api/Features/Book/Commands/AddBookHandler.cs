using Book.Api.Infrastructure.Database;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Book.Commands
{
    public record AddBookCommand : IRequest<AddBookResponse>
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class AddBookResponse
    {
        public int Id { get; set; }
    }

    public class AddBookHandler : IRequestHandler<AddBookCommand, AddBookResponse>
    {
        private readonly AppDbContext _appDbContext;

        public AddBookHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<AddBookResponse> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var responseModel = new AddBookResponse();

            if (!(await _appDbContext.Books.AnyAsync(p => p.Name == command.Name)))
            {
                var entity = new Domain.Book() { Name = command.Name, AuthorId = command.AuthorId};

                await _appDbContext.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                responseModel.Id = entity.Id; 
            }

            return responseModel;
        }
    }
}
