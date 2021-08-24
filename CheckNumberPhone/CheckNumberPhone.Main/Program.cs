using CheckNumberPhone.Main;
using CheckNumberPhone.Main.FileHandle;
using CheckNumberPhone.Main.Interface;
using FindBeeNumbers.Core.Data;
using FindBeeNumbers.Core.Entities;
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
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"\Bee.json";

            // Gets the full path or UNC location of the loaded file that contains the manifest.
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + fileName;

            ReadOnlyJson readOnlyJson = new ReadOnlyJson();
            Bee bee = readOnlyJson.ReadJson(path);

            var providerNetworkFromBee = bee.Providers;
            var twoLastNumberTabooFromBee = bee.TabooNumbers;
            var twoLastNumberNiceFromBee = bee.NiceNumbers;

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

                    // Check provider network
                    if (CheckProviderNetwork(phone, providerNetworkFromBee))
                    {
                        // The last 2 num chars is taboo
                        if (Array.Exists(twoLastNumberTabooFromBee, element => element.Equals(twoLastNumber)))
                        {
                            // rule is violated
                            Console.WriteLine("rule is violated => number phone: {0} - {1} rule is violated,", phone.Number, phone.Network);
                        }
                        else
                        {
                            // Total first 5 nums / Total last 5 nums: matches 1 in n conditions configuratin into Bee.json
                            if (CheckTotal5NumberFirstAndLast(phone.Number, bee.SumOfNumbers) &&
                                Array.Exists(twoLastNumberNiceFromBee, element => element.Equals(twoLastNumber)))
                            {
                                Console.WriteLine("number phone match Bee: {0} - {1},", phone.Number, phone.Network);
                            };
                        }
                    }


                }
            }


            Console.ReadKey();

        }

        /// <summary>
        /// Check Provider Network
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="providersBee"></param>
        /// <returns></returns>
        static bool CheckProviderNetwork(Phone phone, List<Provider> providersBee)
        {
            var providerNetwork = phone.Network;
            var threeFirstNumber = phone.Number.Substring(0, 3);

            foreach (var provider in providersBee)
            {
                if (provider.Name.Equals(providerNetwork))
                {
                    return Array.Exists(provider.Prefixes, element => element.Equals(threeFirstNumber));
                }
            }

            return false;
        }

        /// <summary>
        /// Check Total 5 Number First And Last
        /// </summary>
        /// <param name="numberPhone"></param>
        /// <param name="sumOfNumbers"></param>
        /// <returns></returns>
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

        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, servicesCollection) =>
                    servicesCollection.AddSingleton<PhoneContext>()
                        .AddTransient<MyController>()
                        .AddScoped<IPhoneService, PhoneService>()
                        .AddScoped<IPhoneRepository, PhoneRepository>()
                );


        /// <summary>
        /// ExemplifyScoping
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        static IController ExemplifyScoping<T>(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            IController controller = (IController)provider.GetRequiredService<T>();

            return controller;
        }

    }
}
