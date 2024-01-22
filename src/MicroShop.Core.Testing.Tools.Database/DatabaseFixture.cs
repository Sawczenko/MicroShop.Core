using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MicroShop.Core.Testing.Tools.Database
{
    public class DatabaseFixture<TDbContext> : IAsyncLifetime
        where TDbContext : DbContext, new()
    {
        public TDbContext Context { get; private set; }
        private readonly string _connectionString;

        public DatabaseFixture(string connectionString)
        {
            _connectionString = connectionString;
            var options = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlServer(_connectionString)
                .Options;

            Context = (TDbContext)Activator.CreateInstance(typeof(TDbContext), options);
        }

        public async Task DisposeAsync()
        {
            await Context.Database.EnsureDeletedAsync();
            await Context.DisposeAsync();
        }

        public async Task InitializeAsync()
        {
            await Context.Database.EnsureDeletedAsync();
            await Context.Database.MigrateAsync();
        }
    }
}
