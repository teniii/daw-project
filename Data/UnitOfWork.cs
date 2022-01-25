using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectAPI.Core.IConfiguration;
using ProjectAPI.Core.IRepositories;
using ProjectAPI.Core.Repositories;

namespace ProjectAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MovieContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public IMovieRepository Movies { get; private set; }

        public UnitOfWork(
            MovieContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
            Movies = new MovieRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}