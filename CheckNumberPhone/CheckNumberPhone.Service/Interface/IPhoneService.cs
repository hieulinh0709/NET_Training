using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindBeeNumbers.Service.Interface
{
    public interface IPhoneService {
        //List<Phone> GetAllPhones();
        Task<List<Phone>> GetAllPhones();
        List<Phone> ListNumberPhoneChecked(List<Phone> phones, Bee bee);
        bool IsProviderNetwork(Phone phone, List<Provider> providersBee);
        bool IsTotal5NumberFirstAndLast(string numberPhone, List<SumOfNumbers> sumOfNumbers);
        bool IsBeeNumber(Bee bee, Phone phone);
    }
}
