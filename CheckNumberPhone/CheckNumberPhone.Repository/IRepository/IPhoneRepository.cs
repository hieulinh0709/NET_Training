using FindBeeNumbers.Core.Entities;
using System.Collections.Generic;

namespace FindBeeNumbers.Repository.IRepository
{
    public interface IPhoneRepository
    {
        List<Phone> GetPhones();
    }
}
