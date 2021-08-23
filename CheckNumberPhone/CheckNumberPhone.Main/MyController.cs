using CheckNumberPhone.Main.Interface;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Service.Interface;
using System.Collections.Generic;

namespace CheckNumberPhone.Main
{
    public class MyController : IController
    {
        private readonly IPhoneService _phoneService;

        public MyController(
            IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public List<Phone> FindNumberPhoneWithBee()
        {
            return _phoneService.GetPhones();
        }
    }
}
