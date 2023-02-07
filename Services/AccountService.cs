using System;
using BankApp.Constant;
using System.Collections.Generic;
using BankApp.Entities;
using BankApp.Shared; 
using BankApp.Enums;
using BankApp.Repository;

namespace BankApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        public AccountService()
        {
          accountRepository = new AccountRepository();
        }
        public void Create(Account request)
        {
          var accounts = accountRepository.GetAll();
          request.AccountNumber = Helper.AccNumber();
          request.AccountBalance = 0;

          Console.WriteLine("Enter first name");
          request.FirstName = Console.ReadLine();
          Console.WriteLine("Enter middle name");
          request.MiddleName = Console.ReadLine();
          Console.WriteLine("Enter last name");
          request.LastName = Console.ReadLine();

          request.FullName = Helper.Fullname(request.FirstName, request.MiddleName, request.LastName);
           
          request.Phone = Helper.CheckPhoneNumber("Enter phone number");


          request.Email = Helper.CheckEmail("Enter email");

          int gender = Helper.SelectGender("Enter 1 for male\nEnter 2 for female\nEnter 3 for RatherNotSay", 1, 3);
          request.Gender = (Gender)gender;

          Console.WriteLine("Create password for your account");
          request.Password = Console.ReadLine();

          

          var account = new Account
            {
                FullName = request.FullName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Phone = request.Phone,
                Password = request.Password,
                Gender = request.Gender,
                AccountBalance = request.AccountBalance,
                AccountNumber = request.AccountNumber
            };

            var findAccount = accountRepository.GetAccount(account.Password);
            if (findAccount == null)
            {
              accounts.Add(account);
              accountRepository.WriteToFile(account);
              Console.WriteLine("Account successfully created");
            }
            else
            {
              Console.WriteLine("An error occured");
            }


        }

        public void Update(UpdateAccount update, string password)
        {
          var account = accountRepository.GetAccount(password);
          Console.WriteLine("Enter first name");
          update.FirstName = Console.ReadLine();
          Console.WriteLine("Enter second name");
          update.MiddleName = Console.ReadLine();
          Console.WriteLine("Enter last name");
          update.LastName = Console.ReadLine();
          Console.WriteLine("Enter phone number");
          update.Phone = Console.ReadLine();
          Console.WriteLine("Enter email number");
          update.Email = Console.ReadLine();

          int gender = Helper.SelectGender("Enter 1 for male\nEnter 2 for female\nEnter 3 for RatherNotSay", 1, 3);
          update.Gender = (Gender)gender;

            if (account != null)
            {
                account.FirstName = update.FirstName;
                account.LastName = update.LastName;
                account.MiddleName = update.MiddleName;
                account.Email = update.Email;
                account.Phone = update.Phone;
                account.Gender = update.Gender;
                Console.WriteLine("Record updated successfully!");
                accountRepository.RefreshFile();
            }
            else
            {
             Console.WriteLine("A Error occurred"); 
            }
        }

        public Account Login(string password, string email)
        {
          var account = accountRepository.GetAccount(password);
          if (account != null && account.Password == password && account.Email == email)
          {
            return account;
          }
          return null;
        }

        public void DeleteAccount(string password)
        {
          try
          {
            var account = accountRepository.GetAccount(password);
            var accounts = accountRepository.GetAll();
            if (account == null)
            {
              Console.WriteLine("Account not found");
            }
            if (account.Password != password)
            {
              Console.WriteLine("Invalid password");
            }
            else
            {
              accounts.Remove(account);
              accountRepository.RefreshFile();
              Console.WriteLine(" Your bank account has been permanently deleted");
            }
          }
          catch (Exception ex)
          {
           Console.WriteLine(ex.Message);
          }
        }

        public void ChangePassword(string password, string oldPassword, string newPassword)
        {
          var account = accountRepository.GetAccount(password);
          if (account == null)
          {
           Console.WriteLine("Account not found");
           return; 
          }
          if (account.Password != oldPassword)
          {
            Console.WriteLine("Incorrect password");
            return;
          }

            account.Password = newPassword;
            accountRepository.RefreshFile();
            Console.WriteLine("Password succesfully changed");
        
          
        }
    }
}