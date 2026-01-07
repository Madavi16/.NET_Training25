using NUnit.Framework;
using RefLib;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;


namespace UnitTesting_Assignment
{
    public class Tests
    {
        [Test]
        [Category("SquareOperation")]
        public void Square_ShouldReturnCorrectSum()
        {
            var calc=new Calculator();
            int res=calc.Square(2);
            Assert.That(res, Is.EqualTo(4));
        }

        [Test]
        [Category("StringOperations")]
        public void ToUpper_ShouldReturnExpectedResults()
        {
            var str = new StringHelper();
            var res = str.ToUpper("hello");

            Assert.That(res.Length, Is.EqualTo(5));
            Assert.That(res[0], Is.EqualTo('H'));
            Assert.That(res, Is.EqualTo("HELLO"));

        }


        [TestFixture]
        public class MultiplyTest
        {
            [Test]
            [TestCaseSource(nameof(GetData))]
            public void Multiply_ShouldReturnExpected(int a , int b, int c)
            {
                var mul = new MathOperations();
                int res=mul.Multiply(a, b);
                Assert.That(res, Is.EqualTo(c));
            }

            static IEnumerable<object[]> GetData()
            {
                foreach (var line in File.ReadAllLines("C:\\Users\\Public\\RawData.csv"))
                {
                    var parts = line.Split(',');
                    yield return new object[]
                    {
                        int.Parse(parts[0]),
                        int.Parse(parts[1]),
                        int.Parse(parts[2])
                    };
                }
            }

        }

        public class StudentServiceTests
        {
            [Test]
            public void ValidateAge_Negative_ThrowsArgumentException()
            {
                var service=new StudentService();

                //Assert.Catch(()=> service.ValidateAge(-1));
                Assert.Throws<ArgumentException>(() => service.ValidateAge(-1));

            }
        }

        
        public class SetupTearDownTests
        {
            [SetUp]
            public void Init()
            {
                var res = File.AppendText("C:\\.NET Training_(P)\\DummyTestFile.txt");
                res.WriteLine("Setup Running before each test");
                res.Dispose();
                
            }

            [TearDown]
            public void Cleanup()
            {
                var res = File.AppendText("C:\\.NET Training_(P)\\DummyTestFile.txt");
                res.WriteLine("TearDown running after each test");
                res.Dispose();
               
            }

            [Test]
            public void DummyTest1()
            {

                var res = File.AppendText("C:\\.NET Training_(P)\\DummyTestFile.txt");
                res.WriteLine("DummyTest1 is called");
                res.Dispose();
                Assert.Pass();

            }

            [Test]
            public void DummyTest2()
            {
                var res = File.AppendText("C:\\.NET Training_(P)\\DummyTestFile.txt");
                res.WriteLine("Dummy2 Called");
                res.Dispose();
                Assert.Pass();
            }

        }

        public class CollectionsTests
        {
            [Test]
            public void EvenNumbersAssertions()
            {
                var provider = new CollectionProvider();
                var list = provider.GetEvenNumbers();

                Assert.That(list.Count, Is.EqualTo(7));

                bool isSort = false;
                for(int i=0;i<list.Count-1;i++)
                {
                    if (list[i] < list[i+1])
                    {
                        isSort = true;
                        break;
                    }
                }

                if(isSort) Assert.Pass();

                bool isEven = false;
                foreach (var num in list)
                {
                    if (num % 2 == 0)
                    {
                        isEven = true;
                        break;
                    }
                }

                if (isEven) Assert.Pass();


                Assert.Fail();
              
            }
        }

        public class StringConstraintsTest
        {
            [Test]
            public void NUnitFrameworkConstraints()
            {
                var str = "NUnitFramework";
                Assert.That(str, Does.StartWith("NUni"));
                Assert.That(str, Does.EndWith("work"));
                Assert.That(str, Does.Contain("Frame"));
                Assert.That(str.Length, Is.GreaterThan(7));

            }
        }

        public class AsyncTests
        {
            [Test]
            public async Task GetMarksAsync_Returns90()
            {
                var task = new AsyncMarksProvider();
                var res = await task.GetMarksAsync();
                Assert.That(res, Is.EqualTo(90));
            }
        }

        [TestFixture]
        public class TestCaseSourceTests
        {
           [Test]
           [TestCaseSource(typeof(MarksDataSource), nameof(MarksDataSource.GetMarksForTestCases))]
            [TestCaseSource(typeof(MarksDataSource),nameof(MarksDataSource.GetMarksForTestCases))]
            public void MarksShouldBeGreaterThan40(int mark)
            {
                Assert.That(mark, Is.GreaterThan(40));
            }

                
        }

        [TestFixture]
        public class BankAccountTests
        {
            [Test]
            public void OpeningBalance_IsStored()
            {
                
                var acc = new BankAccount(500m);
                Assert.That(acc.Balance, Is.EqualTo(500m));

            }

            [Test]
            public void Deposit_IncreasesBalance()
            {
                var acc = new BankAccount(1000m);
                acc.Deposit(200m);
                Assert.That(acc.Balance, Is.EqualTo(1200m));
            }

            [Test]

            public void WithDraw_DecreasesBalance()
            {
                var acc = new BankAccount(500);
                acc.WithDraw(300);
                Assert.That(acc.Balance, Is.EqualTo(200));
            }

            [Test]
            public void WithDraw_MoreThanBalance_throws()
            {
                var acc = new BankAccount(500m);
                Assert.Catch(() => acc.WithDraw(600m));
            }

            [Test]
            [TestCase(0,100, 100)]
            [TestCase(100,50,150)]
            [TestCase(1000,500,1500)]
            //the deposit should be <=0
           public void Parameterized_OpeningDeposit(decimal opening, decimal deposit, decimal expected)
            {
                var acc=new BankAccount(opening);
                acc.Deposit(deposit);
                Assert.That(acc.Balance,Is.EqualTo(expected));
            }


            [Test]
            public void History_count_afterTwoDeposits()
            {
                var acc = new BankAccount(0m);
                acc.Deposit(100m);
                acc.Deposit(200m);
                Assert.That(acc.History.Count, Is.EqualTo(2));
            }

            static IEnumerable<object[]> WithdrawalCases()
            {
                yield return new object[] { 1000m, 200m, 800m };
                yield return new object[] { 300m, 100m, 200m };
                yield return new object[] { 2500m, 500m, 2000m };
            }

            [Test]
            [TestCaseSource(nameof(WithdrawalCases))]
            public void Withdraw_cases(decimal opening, decimal withdraw,decimal expected)
            {
                var acc = new BankAccount(opening);
                acc.WithDraw(withdraw);
                Assert.That(acc.Balance, Is.EqualTo(expected));
            }

            [Test]
            public void NegativeDeposit_thrwosArgument ()
            {
                var acc = new BankAccount(0m);
                var ex = Assert.Catch(() => acc.Deposit(-10m));
                Assert.That(ex.Message, Is.EqualTo("Amount should be positive interger"));
            }

            [Test]
            public void ApplyInterest_CorrectBalance()
            {
                var acc = new BankAccount(1000m);
                acc.ApplyInterest(0.05m);
                Assert.That(acc.Balance, Is.EqualTo(1050m));
            }
            
        }

        //[TestFixture]
        //public class NotificationFactoryTests
        //{
        //    [Test]
        //    public void Factory_returnsCorrectInstances()
        //    {

        //        Assert.That(NotificationFactory.GetNotification("email"), Is.TypeOf<EmailNotification>());
        //        Assert.That(NotificationFactory.GetNotification("sms"), Is.TypeOf<SmsNotification>());
        //        Assert.That(NotificationFactory.GetNotification("push"), Is.TypeOf<PushNotification>());

        //    }

        //    [Test]
        //    public void Factory_returnsNull()
        //    {
        //        Assert.That(() => NotificationFactory.GetNotification("wrong"), Throws.TypeOf<ArgumentException>());
        //    }

        //}

    }
}
