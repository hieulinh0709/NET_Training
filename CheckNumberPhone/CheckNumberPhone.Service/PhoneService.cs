using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Service.Interface;
using System.Collections.Generic;

namespace FindBeeNumbers.Service
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public List<Phone> GetPhones()
        {
            return _phoneRepository.GetPhones();
        }
    }
}
