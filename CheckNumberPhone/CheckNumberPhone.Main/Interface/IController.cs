using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using System.Collections.Generic;

namespace CheckNumberPhone.Main.Interface
{
    public interface IController
    {
        List<Phone> FindNumberPhoneWithBee();
        List<Phone> ListNumberPhoneChecked(List<Phone> phones, Bee bee);
    }
}
