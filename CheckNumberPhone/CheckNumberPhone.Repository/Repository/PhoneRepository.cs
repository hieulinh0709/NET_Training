using FindBeeNumbers.Core.Data;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace FindBeeNumbers.Repository.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly PhoneContext _beeContext;
        public PhoneRepository(
            PhoneContext beeContext)
        {
            _beeContext = beeContext;
        }

        public List<Phone> GetPhones()
        {
            var phones = _beeContext.Phones.ToList();
            return phones;
        }
    }
}
