using CheckNumberPhone.Main.Interface;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using FindBeeNumbers.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<Phone>> GetAllPhones()
        {
            var list = await _phoneService.GetAllPhones();
            var toList = list.ToList();
            return toList;
        }

        public List<Phone> ListNumberPhoneChecked(List<Phone> phones, Bee bee)
        {
            var list = _phoneService.ListNumberPhoneChecked(phones, bee);
            return list ;
        }
    }
}
