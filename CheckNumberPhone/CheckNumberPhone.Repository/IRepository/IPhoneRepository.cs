using FindBeeNumbers.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindBeeNumbers.Repository.IRepository
{
    public interface IPhoneRepository
    {
        Task<List<Phone>> GetAllPhones();
    }
}
