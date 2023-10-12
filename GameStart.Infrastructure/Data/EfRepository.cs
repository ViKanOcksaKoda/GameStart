using Ardalis.Specification.EntityFrameworkCore;
using GameStart.Core.Interfaces;

namespace GameStart.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(GameStartContext dbContext) : base(dbContext)
        {
        }
    }
}
