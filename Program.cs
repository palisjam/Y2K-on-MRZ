using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrzDateValidator;

namespace Y2K
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            ValidateDate _validateDate = new ValidateDate();

            /*
            string date;
            date = Console.ReadLine();
            Console.WriteLine("MRZ date:" + date);
            Console.WriteLine("Date of Birth:" + _validateDate.DoB(date).ToString("dd-MMM-yyyy"));
            Console.WriteLine("Date of Expiry:" + _validateDate.DoE(date).ToString("dd-MMM-yyyy"));
            Console.ReadLine();
            */

            string date;
            for (int i = 99; i >= 0; i--)
            {
                string result = i < 10 ? "0" + i.ToString() : i.ToString();
                date = result + "0101";
                Console.WriteLine("MRZ date:" + date);
                Console.WriteLine("Date of Birth:" + _validateDate.DoB(date).ToString("dd-MMM-yyyy"));
                Console.WriteLine("Date of Expiry:" + _validateDate.DoE(date).ToString("dd-MMM-yyyy")+"\n");
            }
            Console.ReadLine();
        }
    }
}
