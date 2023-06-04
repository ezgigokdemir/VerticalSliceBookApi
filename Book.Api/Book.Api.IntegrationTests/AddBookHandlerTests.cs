using Book.Api.Features.Book.Commands;
using MediatR;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Shouldly;

namespace Book.Api.IntegrationTests
{
    public class AddBookHandlerTests
    {
        private readonly IMediator _mediator;

        public AddBookHandlerTests(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Fact]
        public void AddBook_Should_Succeed_Return_Valid_Id()
        {
            // Arrange
            var command = new AddBookCommand
            {
                Name = "Nutuk",
                AuthorId = 1,
                ReleaseDate = new DateTime(1927, 10, 1)
            };

            // Act
            var response = _mediator.Send(command, CancellationToken.None).Result;

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<AddBookResponse>();
            response.Id.ShouldBeGreaterThan(0);
        }
    }
}