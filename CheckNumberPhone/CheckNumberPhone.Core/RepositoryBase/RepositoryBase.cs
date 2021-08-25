using CheckNumberPhone.Core.Entities;
using CheckNumberPhone.Core.Interface;
using FindBeeNumbers.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CheckNumberPhone.Core.RepositoryBase
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly PhoneContext _dbContext;

        public RepositoryBase(PhoneContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
