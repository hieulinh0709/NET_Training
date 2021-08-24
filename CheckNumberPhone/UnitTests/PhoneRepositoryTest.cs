using FindBeeNumbers.Core.Data;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Repository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class PhoneRepositoryTest
    {
        #region field
        private readonly PhoneContext _phoneContext;
        private readonly IPhoneRepository _phoneRepository;
        public static IConfiguration _configuration { get; set; }
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
    }
}
