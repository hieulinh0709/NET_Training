using CheckNumberPhone.Main.FileHandle;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Service;
using FindBeeNumbers.Service.Interface;
using Moq;
using NUnit.Framework;
using System.IO;

namespace UnitTestDemo
{
    [TestFixture]
    public class PhoneServiceTest
    {
        private IPhoneService _phoneService;
        private Bee _bee;
        private ReadOnlyJson _beeConfig;

        [SetUp]
        public void Setup()
        {
            var mockRepo = new Mock<IPhoneRepository>();

            _phoneService = new PhoneService(mockRepo.Object);


            string fileName = @"\Bee.json";

            // Gets the full path or UNC location of the loaded file that contains the manifest.
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + fileName;
            _beeConfig = new ReadOnlyJson();
            _bee = _beeConfig.ReadJson(path);
        }

        [Test]
        [TestCase("123456789")] // < 10
        [TestCase("12345678910")] // >10
        public void IsBeeNumber_InvalidLength_ShouldReturnFalse(string number)
        {
            var phone = new Phone
            {
                Number = number,
            };

            var result = _phoneService.IsBeeNumber(_bee, phone);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("0861975619", "Viettel")] // =10
        [TestCase("0894378337", "Mobi")] // =10
        public void IsBeeNumber_ValidLength_ShouldReturnTrue(string number, string provider)
        {
            var phone = new Phone
            {
                Number = number,
                Network = provider
            };

            var result = _phoneService.IsBeeNumber(_bee, phone);

            Assert.That(result, Is.True);
        }

    }
}