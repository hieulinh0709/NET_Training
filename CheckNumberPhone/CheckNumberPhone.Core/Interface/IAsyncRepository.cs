using FindBeeNumbers.Core.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CheckNumberPhone.Core.Interface
{
    public interface IAsyncRepository<T> where T : IAggregateRoot
    {
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
    }
}
