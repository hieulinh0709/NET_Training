using FindBeeNumbers.Core.Model;

namespace CheckNumberPhone.Main.Interface
{
    public interface IReadOnlyJson
    {
        Bee ReadJson(string path);
    }
}
