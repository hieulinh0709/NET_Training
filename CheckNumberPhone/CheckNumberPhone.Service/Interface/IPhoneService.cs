using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Interface;
using FindBeeNumbers.Core.Model;
using System.Collections.Generic;

namespace FindBeeNumbers.Service.Interface
{
    public interface IPhoneService {
        List<Phone> GetPhones();
        List<Phone> ListNumberPhoneChecked(List<Phone> phones, Bee bee);
        bool IsProviderNetwork(Phone phone, List<Provider> providersBee);
        bool IsTotal5NumberFirstAndLast(string numberPhone, List<SumOfNumbers> sumOfNumbers);
    }
}
