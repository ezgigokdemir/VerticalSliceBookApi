using Book.Api.Features.Book.Commands;
using Book.Api.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Features.Book.Queries
{
    public record GetBookByIdCommand : IRequest<GetBookByIdResponse>
    {
        public int Id { get; set; }
    }

    public class GetBookByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
    }

    public class GetBookByIdHandler : IRequestHandler<GetBookByIdCommand, GetBookByIdResponse>
    {
        private readonly AppDbContext _dbContext;

        public GetBookByIdHandler(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<GetBookByIdResponse> Handle(GetBookByIdCommand command, CancellationToken cancellationToken)
        {

            var entity = await _dbContext.Books.FirstOrDefaultAsync(p => p.Id == command.Id);

            if (entity != null)
            {
                var responseModel = new GetBookByIdResponse()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    AuthorId = entity.AuthorId
                };

                return await Task.FromResult(responseModel);
            }

            return await Task.FromResult(new GetBookByIdResponse());
        }
    }
}
