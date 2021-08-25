using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckNumberPhone.Main.Interface
{
    public interface IController
    {
        //List<Phone> GetAllPhones();
        Task<List<Phone>> GetAllPhones();
        List<Phone> ListNumberPhoneChecked(List<Phone> phones, Bee bee);
    }
}
