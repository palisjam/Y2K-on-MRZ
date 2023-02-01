// This Class dll contributed by Palis Luckananurug

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrzDateValidator
{
    public class ValidateDate
    {

        private int MaxPassportValidity;
        public ValidateDate(int maxPassportValidity) {
            MaxPassportValidity = maxPassportValidity; 
        }

        static DateTime parseDate(string dateMRZ, string format)
        {
            DateTime convertedDate;
            DateTime.TryParseExact(dateMRZ, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out convertedDate);
            return convertedDate;
        }

        public DateTime DoB(string dateMRZ) //if date of birth is future, it will automatically change to 19XX
        {
            DateTime dateOfBirth = parseDate(dateMRZ, "yyMMdd");
            DateTime currentDate = DateTime.Now;
            if (currentDate.Date < dateOfBirth.Date)
            {
                dateOfBirth = parseDate("19" + dateMRZ, "yyyyMMdd");
            }
            return dateOfBirth;
        }

        public DateTime DoE(string dateMRZ) //if date of expiry is more than current year +10, it will change to 19XX
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
