using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Book.Api.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public DbSet<Domain.Book> Books { get; set; }
    }
}
