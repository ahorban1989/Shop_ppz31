using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shop_PPZ_31.views.helpers
{
    static class ConsoleImputHelpers
    {
        public static string ImputName()
        {
            // throw new NotImplementedException();
            const string pattern = "^[a-zA-Z ]+$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            string rightString = Console.ReadLine();
            while (!rgx.IsMatch(rightString))
            {
                if (!rgx.IsMatch(rightString))
                {
                    Console.WriteLine("Your input is incorrect. Please, try again: ");
                    rightString = Console.ReadLine();
                }
            };
            return rightString;
        }

        public static int ImputIntNumber()
        {
            int result = 0;
            while (!Int32.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Value you inputed is wrong, please give another: ");
            };
            return result;
        }

        public static decimal ImputDecimalNumber()
        {
            decimal result = 0;
            while (!Decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Value you inputed is wrong, please give another: ");
            };
            return result;
        }
    }
}
