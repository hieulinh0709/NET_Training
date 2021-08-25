using CheckNumberPhone.Core.RepositoryBase;
using FindBeeNumbers.Core.Data;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindBeeNumbers.Repository.Repository
{
    public class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
    {
        private readonly PhoneContext _dbContext;

        public PhoneRepository(
            PhoneContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Phone>> GetAllPhones()
        {
            var phones = await _dbContext.Phones.ToListAsync();
            return phones;
        }
    }
}
