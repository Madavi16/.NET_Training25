using System;

namespace FirstPrj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello..");

            Program program = new Program();
            int c = program.add(5, 6);
            Console.WriteLine(c);

            Program program1 = new Program();
            int d = program1.add(31, 32);
            Console.WriteLine(d);

            Greet();

            NewClass.Message("Infinite");

            NewClass newClass = new NewClass();
            Console.WriteLine(newClass.Hello("Madhavi"));

            DisplayTypes dt = new DisplayTypes();
            dt.Display();

            Console.ReadLine();
        }

        int add(int x, int y)
        {
            Console.WriteLine("Hii reached");
            return x + y;
        }

        static void Greet()
        {
            Console.WriteLine("Hii");
        }
    }

    class NewClass
    {
        public static void Message(String name)
        {
            Console.WriteLine(name);
        }

        public string Hello(String name)
        {
            return "Hi " + name;
        }
    }
    
}

