using CheckNumberPhone.Main.FileHandle;
using FindBeeNumbers;
using FindBeeNumbers.Core.Data;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Repository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class PhoneRepositoryTest
    {
        #region field
        private readonly PhoneContext _phoneContext;
        private readonly IPhoneRepository _phoneRepository;
        public static IConfiguration _configuration;
        #endregion field

        public PhoneRepositoryTest()
        {
            _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSettingsTest.json")
                    .Build();
            _phoneContext = new PhoneContext(_configuration);
            _phoneRepository = new PhoneRepository(_phoneContext);
        }

        [TestMethod]
        public void SelectPhone()
        {
            var phones = _phoneRepository.GetPhones();
            Assert.IsNotNull(phones);
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

            if (phones == null)
            {
                Assert.IsNull(phones);
            }
            else
            {
                Assert.IsNotNull(phones);
                foreach (var phone in phones)
                {
                    var twoLastNumber = phone.Number.Substring(phone.Number.Length - 2);

                    // Check provider network
                    bool checkProviderNetwork = Program.IsProviderNetwork(phone, providerNetworkFromBee);
                    if (checkProviderNetwork)
                    {
                        Assert.IsTrue(checkProviderNetwork);
                        // The last 2 num chars is taboo
                        bool isInTaboo = Array.Exists(twoLastNumberTabooFromBee, element => element.Equals(twoLastNumber));
                        if (isInTaboo)
                        {
                            Assert.IsTrue(isInTaboo);
                            // rule is violated
                            //Console.WriteLine("rule is violated => number phone: {0} - {1} rule is violated,", phone.Number, phone.Network);
                        }
                        else
                        {
                            Assert.IsFalse(isInTaboo);
                            // Total first 5 nums / Total last 5 nums: matches 1 in n conditions configuratin into Bee.json
                            bool checkTotal5NumberFirstAndLast = Program.IsTotal5NumberFirstAndLast(phone.Number, bee.SumOfNumbers);
                            if (checkTotal5NumberFirstAndLast &&
                                Array.Exists(twoLastNumberNiceFromBee, element => element.Equals(twoLastNumber)))
                            {
                                Assert.IsTrue(checkTotal5NumberFirstAndLast &&
                                    Array.Exists(twoLastNumberNiceFromBee, element => element.Equals(twoLastNumber)));

                                phonesChecked.Add(phone);
                            };
                        }
                    }
                    else
                    {
                        Assert.IsFalse(checkProviderNetwork);
                    }


                }
            }

        }

    }
}
