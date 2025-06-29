using NUnit.Framework;
using Moq;
using CustomerCommLib;
namespace CustomerCommLibTest
{
    [TestFixture]
    public class CustomerCommTest
    {
        private Mock<IMailSender> mockMailSender;
        private CustomerComm customerComm;

        [OneTimeSetUp]
        public void Setup()
        {
            mockMailSender = new Mock<IMailSender>();


            mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            customerComm = new CustomerComm(mockMailSender.Object);
        }
        [TestCase]
        public void SendMail_Success()
        {
            bool result = customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
        }
    }
}
