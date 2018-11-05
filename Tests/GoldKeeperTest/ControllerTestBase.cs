using System;
using Data;
using Microsoft.EntityFrameworkCore;

namespace GoldKeeperTest
{
    public class ControllerTestBase : IDisposable
    {
        public readonly DomainContext context;

        public ControllerTestBase()
        {
            var options = new DbContextOptionsBuilder<DomainContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            context = new DomainContext(options);
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
