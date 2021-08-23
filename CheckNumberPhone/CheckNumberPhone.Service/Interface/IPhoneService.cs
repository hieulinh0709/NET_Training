using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Interface;
using System.Collections.Generic;

namespace FindBeeNumbers.Service.Interface
{
    public interface IPhoneService {
        List<Phone> GetPhones();
    }
}
