using System;
using System.Collections.Generic;
using BankApp.Entities;
using BankApp.Transactions;
using BankApp.Services;


namespace BankApp
{
    public class BankAccountMenu
    {
      private readonly Transaction transaction;
      private readonly Account account;
      private readonly AccountService accountService;
      private readonly UpdateAccount updateAccount;

      public BankAccountMenu()
      {
        transaction = new Transaction();
        account = new Account();
        accountService = new AccountService();
        updateAccount = new UpdateAccount();
      }
        public void MyBankAccountMenu()
        {
          var flag = true;
          while (flag)
          {
            Console.WriteLine("=========Welcome========");
            PrintMenu();
            string option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
              case "1":
              CreateAccountMenu();
              MainMenu(account);
              Console.Clear();
              break;

              case "2":
              System.Console.WriteLine("Enter Email");
              string email = Console.ReadLine(); 
              Console.WriteLine("Enter password");
              string password = Console.ReadLine();
              Console.Clear();
              var accounts = accountService.Login( password, email);
              if (accounts == null)
              {
                Console.WriteLine("Invalid email or password");
              }
              else
              {
                MainMenu(account);
                Console.Clear();
              }
              break;

              case "0":
              flag = false;
              Console.WriteLine("Thanks for using our app");
              break;
              default:
              ErrorMess();
              break;
            }
            Console.WriteLine();
          } 
        }

        public void MainMenu(Account account)
        {
          var flag = true;
          
          while (flag)
          {
            Console.WriteLine($"Account Name: {account.FullName}.\nAccount Number: {account.AccountNumber}\nAccount Balance = {account.AccountBalance}");
            PrintAccountMenu();
            string option = Console.ReadLine();
              switch (option)
              {
                case "1":
                Console.Clear();
                TransactionMenu();
                Console.Clear();
                break;
                case "2":
                Console.Clear();
                Settings();
                Console.Clear();
                break;
                case "0":
                flag = false;
                break;
                default:
                ErrorMess();
                break;
              } 
          }
        }

        public void TransactionMenu()
        {
          var flag = true;
          while (flag)
          {
           PrintTransactionMenu();
           string option = Console.ReadLine();           
            switch (option)
            {
              case "1":
              transaction.Makedeposit(account);
              break;
              
              case "2":
              transaction.MakeWithdraw(account);
              break;

              case "3":
              flag = false;
              Console.WriteLine();
              break;

              default:
              Console.WriteLine("Invalid input");
              break;
            }
          }
        }

        public void Settings()
        {
           var flag = true;
          while (flag)
          {
           System.Console.WriteLine("Press 1 to change password\nPress 2 to update\nPress 3 to delete your account\nPress 0 to exit settings");
           string option = Console.ReadLine();           
            switch (option)
            {
              case "1":
              Console.WriteLine("Input Old password");
              string oldpassword = Console.ReadLine();
              Console.WriteLine("Input new password");
              string newpassword = Console.ReadLine();
              accountService.ChangePassword(account.Password, oldpassword, newpassword);
              break;
              
              case "2":
              Console.WriteLine("");
              accountService.Update(updateAccount, account.Password);
              Console.WriteLine("");
              Console.Clear();
              break;

              case "3":
              Console.WriteLine("Enter password");
              string password = Console.ReadLine();
              accountService.DeleteAccount(password);
              Console.WriteLine("");
              break;

              case "0":
              flag = false;
              Console.WriteLine();
              break;

              default:
              Console.WriteLine("Invalid input");
              break;
            }
          }
        }
        public void CreateAccountMenu()
        {
          accountService.Create(account);
        } 

        public void PrintTransactionMenu()
        {
          Console.WriteLine("Welcome.\nPress 1 to Deposit\nPress 2 to withdraw\nPress 3 to exit transaction menu");
        }     
        
        public void PrintMenu()
        {
          Console.WriteLine("Press 1 to create new bank account\nPress 2 login\nPress 0 to exit");

        }

        public void PrintAccountMenu()
        {
          Console.WriteLine("Press 1 to make transactions\nPress 2 to go to settings\nPress 0 to exit"); 
        }
        public void ErrorMess()
        {
          Console.WriteLine("Invalid input");
        }

    }
}