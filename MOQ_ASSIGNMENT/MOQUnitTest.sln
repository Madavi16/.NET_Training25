using Moq;
using RefLib;

namespace MOQ_Assignment
{
    [TestFixture]
   public class MOQAssignmentsTest
    {
        [Test]
        public void Calculator_Add_SetupAndVerify()
        {
            var mock = new Mock<ICalculator>();
            mock.Setup(m => m.Add(2, 3)).Returns(5);

            int res=mock.Object.Add(2, 3);
            Assert.That(res, Is.EqualTo(5));
            mock.Verify(m => m.Add(2, 3), Times.Once);

        }

        [Test]
        public void CustomerService_returns_John()
        {
            var m = new Mock<ICustomerRepository>();
            m.Setup(r => r.GetCustomerById(1)).Returns(new Customer { Id = 1, Name = "John" });

            var s = new CustomerService(m.Object);
            string name = s.GetCustomerName(1);

            Assert.That(name, Is.EqualTo("John"));
            m.Verify(r=>r.GetCustomerById(1),Times.Once);
        }


        [Test]
        public void CustomerService_GetCustomerByID_ThrowException()
        {
            var m=new Mock<ICustomerRepository>();
            m.Setup(r => r.GetCustomerById(-1)).Throws(new ArgumentException("Invalid ID"));

            var s=new CustomerService(m.Object);

            Assert.That(()=> s.GetCustomerName(-1),Throws.TypeOf<ArgumentException>());

            m.Verify(r=>r.GetCustomerById(-1),Times.Once);
        }

        [Test]
        public void Parser_TryPrase()
        {
            var m = new Mock<IParser>();
            int outValue = 123;

            m.Setup(p => p.TryParse("123", out outValue)).Returns(true);

            bool parsed = m.Object.TryParse("123", out int result);
            Assert.That(parsed, Is.True);
            Assert.That(result, Is.EqualTo(123));
            m.Verify(p=>p.TryParse("123", out outValue), Times.Once);
        }

        [Test]
        public void Processor_LogsTest()
        {
            var m = new Mock<ILogger>();
            var p = new Processor(m.Object);

            p.Process();

            m.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(3));
            m.Verify(l => l.Log("Start"), Times.Once);
            m.Verify(l => l.Log("Processing"), Times.Once);
            m.Verify(l => l.Log("End"), Times.Once);

        }

        [Test]
        public void Config_property_Used_Inchecker()
        {
            var m = new Mock<ICongif>();
            m.SetupProperty(c => c.Environment, "Production");

            var checker = new EnvChecker(m.Object);
            bool isProd = checker.IsProduction();

            Assert.That(isProd,Is.True);

            m.VerifyGet(c => c.Environment, Times.Once);

        }


        [Test]
        public void Notifier_CallBack_CapturesMessage()
        {
            var m = new Mock<INotifier>();
            string captured = null;
            m.Setup(n=>n.Notify(It.IsAny<string>())).Callback<string>(msg=>captured = msg);

            m.Object.Notify("Hello Mahe");

            Assert.That(captured, Is.EqualTo("Hello Mahe"));
            m.Verify(n => n.Notify(It.IsAny<string>()), Times.Once);


        }


        [Test]
        public void DataReader_ReadLine()
        {
            var m = new Mock<IDataReader>();
            m.SetupSequence(r => r.ReadLine())
                .Returns("First")
                .Returns("Second")
                .Returns("Third");

            var consumer = new DataReaderConsumer();
            var lines = consumer.ReadThreeLines(m.Object);

            Assert.That(lines, Is.EqualTo(new List<string>
            {
                "First",
                "Second",
                "Third"
            }));

            m.Verify(r => r.ReadLine(), Times.Exactly(3));
        }

        [Test]
        public void DiscountServices_returns_90Percentage()
        {
            var m = new Mock<IDiscountService>();
            m.Setup(d => d.ApplyDiscount(It.IsAny<decimal>()))
                .Returns((decimal amount) => amount * 0.9m);

            decimal result = m.Object.ApplyDiscount(100m);
            Assert.That(result, Is.EqualTo(90m));
            m.Verify(d=>d.ApplyDiscount(100m),Times.Once);
        }

        [Test]
        public void StrictMock_ThrwosOnUnExpectedCall()
        {
            var m=new Mock<ILogger>(MockBehavior.Strict);
            m.Setup(l => l.Log("Start"));

            m.Object.Log("Start");

            Assert.That(() => m.Object.Log("Unexpected"),
                Throws.TypeOf<MockException>());

            m.Verify(l=>l.Log("Start"),Times.Once);
        }

    }
}
