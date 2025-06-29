using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLibTest
{
    [TestFixture]
    public class CustCommTest
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;
        [SetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();

        
            _mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
        public void Test1()
        {
            var result = _customerComm.SendMailToCustomer();
            Assert.That(result, Is.True);
            _mockMailSender.Verify(m => m.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}