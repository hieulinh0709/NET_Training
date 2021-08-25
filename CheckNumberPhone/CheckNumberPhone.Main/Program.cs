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
    public static class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"\Bee.json";

            // Gets the full path or UNC location of the loaded file that contains the manifest.
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + fileName;
            Bee bee = new Bee();

            if (!string.IsNullOrEmpty(path))
            {
                ReadOnlyJson readOnlyJson = new ReadOnlyJson();
                bee = readOnlyJson.ReadJson(path);
            }

            using IHost host = CreateHostBuilder(args).Build();

            var scoping = ExemplifyScoping<MyController>(host.Services);

            var phones = scoping.FindNumberPhoneWithBee();

            var listNumberPhoneChecked = scoping.ListNumberPhoneChecked(phones, bee);


            Console.WriteLine("*************** number phone match Bee ***************");
            foreach (var phone in listNumberPhoneChecked)
            {
                Console.WriteLine("{0} - {1}", phone.Number, phone.Network);
            }

            Console.ReadKey();

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
