using System;
using System.Collections.Generic;

namespace Delegator
{
    delegate double Calculator(double a, double b);
    
    class Program
    {
        static Dictionary<string, Calculator> operations;

        static void Main(string[] args)
        {
            var printing = new Printing();
            printing.PrintFancyText("μια φορά και ένα καιρό...");
            printing.PrintFancyText("μια φορά και ένα καιρό...", Printing.PrintingStyle.PlainText);
            printing.PrintFancyText("μια φορά και ένα καιρό...", Printing.PrintingStyle.ColoredText, Printing.PrintingStyle.FramedText);

            printing.PrintFancyText("μια φορά και ένα καιρό...", Printing.PrintingStyle.ColoredText, Printing.PrintingStyle.PlainText, Printing.PrintingStyle.ColoredText, Printing.PrintingStyle.FramedText, Printing.PrintingStyle.ColoredText, Printing.PrintingStyle.PlainText);



            Console.Read();

            operations = new Dictionary<string, Calculator>();

            operations.Add("+", Add);
            operations.Add("add", Add);
            operations.Add("-", Subtract);
            operations.Add("*", Multiply);
            
            double a = 5.0;
            double b = 12.33;

            Calculator calculator = Add;
            var result = calculator(a, b);
            //calculator = Subtract;
            //result = calculator(a, b);

            var op = "*";
            result = operations[op](a, b);
            Console.WriteLine(result);

            Calculator multicast = Add;
            multicast += Subtract;
            multicast += Multiply;
            multicast -= Subtract;
            multicast += Multiply;

            var final = multicast(5, 5);
            Console.WriteLine(multicast);


            Callbacks.ProcessFile("test.txt", Callbacks.PrintLine);
            Callbacks.ProcessFile("test.txt", Callbacks.PrintCharCount);
            Callbacks.ProcessFile("test.txt", Console.WriteLine);


            var blog = new Blog();

            var reader1 = new Reader(blog);
            var reader2 = new Reader(blog);

            blog.Post("test", "test content");

        }

        static double Add(double x, double y)
        {
            return x + y;
        }

        static double Subtract(double x, double y)
        {
            return x - y;
        }

        static double Multiply(double x, double y)
        {
            return x * y;
        }
    }
}
