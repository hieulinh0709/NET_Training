using CheckNumberPhone.Main.Interface;
using FindBeeNumbers.Core.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace CheckNumberPhone.Main.FileHandle
{
    public class ReadOnlyJson : IReadOnlyJson
    {
        public Bee ReadJson(string path)
        {
            using (StreamReader Filejosn = new StreamReader(path))
            {
                try
                {
                    var json = Filejosn.ReadToEnd();
                    Bee bee = JsonConvert.DeserializeObject<Bee>(json);

                    return bee;
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file");

                    return null;
                }
            }

        }
    }
}
