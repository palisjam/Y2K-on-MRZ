using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y2K
{
    internal class Program
    {
        static int MaxPassportValidity = 10; //Maximum passport validity = 10 years (data 2023)
        
        static void Main(string[] args)
        {
            string date;
            date = Console.ReadLine();
            Console.WriteLine("MRZ date:" + date);
            Console.WriteLine("Date of Birth:" + validateDoB(date).ToString("dd-MMM-yyyy"));
            Console.WriteLine("Date of Expiry:" + validateDoE(date).ToString("dd-MMM-yyyy"));
            Console.ReadLine();
        }

        static DateTime parseDate(string dateMRZ,string format)
        {
            DateTime convertedDate;
            DateTime.TryParseExact(dateMRZ, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out convertedDate);
            return convertedDate;
        }

        static DateTime validateDoB(string dateMRZ) //if date of birth is future, it will automatically change to 19XX
        {
            DateTime dateOfBirth= parseDate(dateMRZ,"yyMMdd");
            DateTime currentDate = DateTime.Now;
            if(currentDate.Date<dateOfBirth.Date)
            {
                dateOfBirth = parseDate("19" + dateMRZ, "yyyyMMdd");
            }
            return dateOfBirth;
        }

        static DateTime validateDoE(string dateMRZ) //if date of expiry is more than current year +10, it will change to 19XX
        {
            DateTime dateOfExpiry = parseDate(dateMRZ, "yyMMdd");
            DateTime currentDate = DateTime.Now;
            DateTime tenYearsLater = currentDate.AddYears(MaxPassportValidity); //current date +MaxPassport Validity (10)
            if (tenYearsLater.Date < dateOfExpiry.Date)
            {
                dateOfExpiry = parseDate("19" + dateMRZ, "yyyyMMdd");
            }
            return dateOfExpiry;
        }
    }
}
