using CheckNumberPhone.Main;
using CheckNumberPhone.Main.FileHandle;
using CheckNumberPhone.Main.Interface;
using FindBeeNumbers.Core.Data;
using FindBeeNumbers.Core.Model;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Repository.Repository;
using FindBeeNumbers.Service;
using FindBeeNumbers.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindBeeNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"\Bee.json";

            // Gets the full path or UNC location of the loaded file that contains the manifest.
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + fileName;

            ReadOnlyJson readOnlyJson = new ReadOnlyJson();
            Bee bee = readOnlyJson.ReadJson(path);

            var twoLastNumberTaboo = bee.TabooNumbers;
            var twoLastNumberNice = bee.NiceNumbers;

            using IHost host = CreateHostBuilder(args).Build();

            var scoping = ExemplifyScoping<MyController>(host.Services);

            var phones = scoping.FindNumberPhoneWithBee();

            if (phones == null)
            {
                Console.WriteLine("danh sach phone number is null");
            }
            else
            {

                foreach (var phone in phones)
                {

                    var twoLastNumber = phone.Number.Substring(phone.Number.Length - 2);

                    // The last 2 num chars is taboo
                    if (Array.Exists(twoLastNumberTaboo, element => element.Equals(twoLastNumber)))
                    {
                        Console.WriteLine("number phone: {0} - {1} rule is violated,", phone.Number, phone.Network);
                    }
                    else
                    {
                        // Total first 5 nums / Total last 5 nums: matches 1 in n conditions configuratin into Bee.json
                        if (CheckTotal5NumberFirstAndLast(phone.Number, bee.SumOfNumbers) && 
                            Array.Exists(twoLastNumberNice, element => element.Equals(twoLastNumber)))
                        {
                            Console.WriteLine("Good Bee => number phone: {0} - {1} rule is violated,", phone.Number, phone.Network);
                        };
                    }

                }
            }


            Console.ReadKey();

        }

        static bool CheckTotal5NumberFirstAndLast(string numberPhone, List<SumOfNumbers> sumOfNumbers)
        {
            int total5NumberFirst = 0;
            int total5NumberLast = 0;

            total5NumberFirst = numberPhone.Substring(0, 5).Select(x => Int32.Parse(x.ToString())).Sum();

            total5NumberLast = numberPhone.Substring(5, 5).Select(x => Int32.Parse(x.ToString())).Sum();

            foreach( var pair in sumOfNumbers)
            {
                if (total5NumberFirst == Convert.ToInt16(pair.FromFirst) && total5NumberLast == Convert.ToInt16(pair.FromLast))
                    return true;
            }
            return false;
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, servicesCollection) =>
                    servicesCollection.AddSingleton<PhoneContext>()
                        .AddTransient<MyController>()
                        .AddScoped<IPhoneService, PhoneService>()
                        .AddScoped<IPhoneRepository, PhoneRepository>()
                );


        static IController ExemplifyScoping<T>(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            IController controller = (IController)provider.GetRequiredService<T>();

            return controller;
        }

    }
}
