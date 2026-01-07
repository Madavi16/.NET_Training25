using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefLib
{
   public interface ICalculator
    {
        int Add(int a, int b);
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name {  get; set; }
    }

    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
    }

    public class CustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)

        {
            _repo = repo;
        }

        public string GetCustomerName(int id)
        {
            var customer= _repo.GetCustomerById(id);
            return customer?.Name ?? "Unknown";
        }
    }
    
    public interface IParser
    {
        bool TryParse(string input, out int number);
    }


    public interface ILogger
    {
        void Log(string message);
    }

    public class Processor
    {
        private readonly ILogger _logger;
        public Processor(ILogger logger)
        {
            _logger = logger;
        }

        public void Process()
        {
            _logger.Log("Start");
            _logger.Log("Processing");
            _logger.Log("End");
        }
    }

    public interface ICongif
    {
        string Environment { get; set; }
    }

    public class EnvChecker
    {
        private readonly ICongif _config;
        public EnvChecker(ICongif config)
        {
            _config = config;
        }

        public bool IsProduction() => _config.Environment == "Production";
    }


    public interface INotifier
    {
        void Notify(string message);
    }

    public interface IDataReader
    {
        string ReadLine();
    }

    public class DataReaderConsumer
    {
        public List<string> ReadThreeLines(IDataReader reader)
        {
            var result = new List<string>();
            result.Add(reader.ReadLine());
            result.Add(reader.ReadLine());
            result.Add(reader.ReadLine());
            return result;
        }
    }

    public interface IDiscountService
    {
        decimal ApplyDiscount(decimal amount);
    }


}
