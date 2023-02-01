# Y2K-on-MRZ

You can use the dll MrzDateValidator as a reference in your project and then initialize the class ValidateDate(int maxPassportValidity) or initialize it without parameter, ValidateDate(). the class has 2 methods:
1. DoB = date of birth, if the date of birth is future (compare with today's date), it will automatically change to 19XX
          return DateTime
2. DoE = date of expiry, if the date of expiry is more than the current year +10 (maxPassportValidity, it will change to 19XX
          return DateTime
          
    ValidateDate _validateDate = new ValidateDate(); // initialize with maxPassportValidity as 10(default) b;
    string date;
    date = Console.ReadLine();
    Console.WriteLine("MRZ date:" + date);
    Console.WriteLine("Date of Birth:" + _validateDate.DoB(date).ToString("dd-MMM-yyyy"));
    Console.WriteLine("Date of Expiry:" + _validateDate.DoE(date).ToString("dd-MMM-yyyy"));
    Console.ReadLine();
