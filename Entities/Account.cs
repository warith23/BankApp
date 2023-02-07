using System;
using BankApp.Enums;

namespace BankApp.Entities
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName {get; set;}
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance {get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
        return $"{FirstName}\t{LastName}\t{MiddleName}\t{FullName}\t{AccountNumber}\t{AccountBalance}\t{Gender}\t{Phone}\t{Email}\t{Password}";
        }

        public static Account ToAccount(string str)
        {
            var split = str.Split("\t");

            var account = new Account
            {
              FirstName = split[0],
              LastName = split[1],
              MiddleName = split[2],
              FullName = split[3],
              AccountNumber = split[4],
              AccountBalance = decimal.Parse(split[5]),
              Gender = Enum.Parse<Gender>(split[6]),
              Phone = split[7],
              Email = split[8],
              Password = split[9],
            };
            return account;
        }
    }

    
}