using CheckNumberPhone.Main.FileHandle;
using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Service;
using FindBeeNumbers.Service.Interface;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace UnitTestDemo
{
    [TestFixture]
    public class PhoneServiceTest
    {
        private IPhoneService _phoneService;
        private Bee _bee;
        private ReadOnlyJson _beeConfig;

        [SetUp]
        public void SetUp()
        {
            string fileName = @"\Bee.json";
            // Gets the full path or UNC location of the loaded file that contains the manifest.
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + fileName;

            var mockRepo = new Mock<IPhoneRepository>();

            _phoneService = new PhoneService(mockRepo.Object);

            _beeConfig = new ReadOnlyJson();
            _bee = _beeConfig.ReadJson(path);
        }

        [Test]
        [TestCase("123456789", "Viettel")]
        [TestCase("12345678910", "Viettel")] 
        [TestCase("xxxxxxxxxx", "")] 
        [TestCase("", "")] 
        public void IsBeeNumber_InvalidNumberPhone_ShouldReturnFalse(string number, string provider)
        {
            var phone = new Phone
            {
                Number = number,
                Network = provider
            };

            var result = _phoneService.IsBeeNumber(_bee, phone);

            // Trả về mà không quăng ra ngoại lệ
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("0861975619", "Viettel")]
        [TestCase("0894378337", "Mobix")]
        public void IsBeeNumber_ValidNumberPhone_ShouldReturnTrue(string number, string provider)
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