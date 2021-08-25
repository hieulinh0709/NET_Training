using CheckNumberPhone.Main.FileHandle;
using FindBeeNumbers.Core.Data;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Repository.Repository;
using FindBeeNumbers.Service;
using FindBeeNumbers.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class PhoneServiceTest
    {
        #region field
        private readonly PhoneContext _phoneContext;
        private readonly IPhoneService _phoneService;
        private readonly IPhoneRepository _phoneRepository;
        public static IConfiguration _configuration;
        #endregion field

        public PhoneServiceTest()
        {
            _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSettingsTest.json")
                    .Build();
            _phoneContext = new PhoneContext(_configuration);
            _phoneRepository = new PhoneRepository(_phoneContext);
            _phoneService = new PhoneService(_phoneRepository);
        }



        [TestMethod]
        public void ListNumberPhoneChecked()
        {
            List<Phone> phones = new List<Phone>();
            List<Phone> phonesChecked = new List<Phone>();
            Bee bee = new Bee();
            ReadOnlyJson readOnlyJson = new ReadOnlyJson();
            string fileName = @"\Bee.json";

            // Gets the full path or UNC location of the loaded file that contains the manifest.
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + fileName;

            phones = _phoneRepository.GetPhones();
            bee = readOnlyJson.ReadJson(path);
            var providerNetworkFromBee = bee.Providers;
            var twoLastNumberTabooFromBee = bee.TabooNumbers;
            var twoLastNumberNiceFromBee = bee.NiceNumbers;

            

        }
    }
}
