using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Shared
{
    public class Helper
    {
        public static string AccNumber()
        {
          Random random = new Random();
          return random.Next(999999999).ToString();
        }

         public static string Fullname(string firstName, string middleName, string lastName)
        {
          string Initial = middleName[0] + ".";

          return $"{firstName.ToUpper()} {Initial.ToUpper()} {lastName.ToUpper()}";
        }

        public static bool IsValid(int outValue, int start, int end)
        {
            return outValue >= start && outValue <= end;
        }

        public static int SelectGender(string screenMessage, int validStart, int validEnd)
        {
          int outValue;
          do
          {
            Console.WriteLine(screenMessage); 
          } while (!(int.TryParse(Console.ReadLine(), out outValue) && IsValid(outValue, validStart, validEnd)));
          
          return outValue;
        }

        public static string  CheckEmail(string message)
        {
          var flag = true;
          while (flag)
          {
            Console.WriteLine(message);
            string email = Console.ReadLine();
            if (email.Contains("@") && email.Contains(".com"))
            {
              flag = false;
              return email;
            } 
            else
            {
              Console.WriteLine("Invalid email.Please enter a valid email.");
            }
          }
          return null;
        }

        public static string CheckPhoneNumber(string message)
        {
          var flag = true;
          
          while (flag)
          {
            Console.WriteLine(message);
            string phone = Console.ReadLine();
            if (Regex.Match(phone, @"(^[0-9]{11}$)").Success)
            {
              flag =false;
              return phone;
            }
            else
            {
              Console.WriteLine("Input a valid phone number");
            }
          }
          return null;
        }  
    }
}