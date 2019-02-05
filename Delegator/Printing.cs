using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegator
{
    public class Printing
    {
        public enum PrintingStyle
        {
            PlainText,
            ColoredText,
            FramedText
        }

        delegate void Print(string text);

        private Dictionary<PrintingStyle, Print> _printers =
            new Dictionary<PrintingStyle, Print>();

        public Printing()
        {
            _printers[PrintingStyle.PlainText] = PrintToConsole;
            _printers[PrintingStyle.ColoredText] = PrintTextToConsoleWithColor;
            _printers[PrintingStyle.FramedText] = PrintWithFrame;
        }

        public void PrintFancyText(string text, params PrintingStyle[] styles)
        {
            Print printer = null;
            foreach (var style in styles)
            {
                if (printer == null)
                    printer = _printers[style];
                else
                    printer += _printers[style];
            }

            printer?.Invoke(text);
        }

        private void PrintToConsole(string text)
        {
            Console.WriteLine(text);
        }

        private void PrintTextToConsoleWithColor(string text)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        private void PrintWithFrame(string text)
        {
            //text?.Length ?? 0;
            var length = string.IsNullOrEmpty(text) ? 0 : text.Length;

            for (int i = 0; i < length + 4; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            Console.WriteLine($"| {text} |");
            for (int i = 0; i < length + 4; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

    }
}
