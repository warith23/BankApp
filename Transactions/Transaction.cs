using System;
using System.Collections.Generic;
using BankApp.Entities;
using BankApp.Repository;
using BankApp.Constant;

namespace BankApp.Transactions
{
    public class Transaction
    {
      private readonly IAccountRepository accountRepository;

      public Transaction()
      {
        accountRepository = new AccountRepository();
      }
      //public static List<string> transaction = new List<string>();

       
      public void Makedeposit(Account acc)
      {
        var accounts = accountRepository.GetAll();
        try
        {
          Console.WriteLine("Enter the amount to deposit");
          decimal amountdeposit = decimal.Parse(Console.ReadLine());
          if (amountdeposit <= 0)
          {
            Console.WriteLine("Transaction not successful");
          }
          else
         {
           acc.AccountBalance += amountdeposit;
           acc.AccountBalance -= 50;
           
            //  var dep = new Account
            //  {
            //   AccountBalance = acc.AccountBalance
            //  };
            //   accounts.Add(dep);
            accountRepository.RefreshFile();

           string value = $"Transaction successful.You have successfully deposited {amountdeposit} and charges of 50 Naira has been deducted";
           Console.WriteLine(value);
          }
        }
        catch (System.Exception)
        {
          Console.WriteLine("An error occurred");
        }
            
      }
      public void MakeWithdraw(Account account)
      {
        var accounts = accountRepository.GetAll();
        try
        {
          Console.WriteLine("Enter amount to be withdrawn");
          decimal amountWithdrawn = decimal.Parse(Console.ReadLine());
          if (amountWithdrawn >= (account.AccountBalance - 60))
          {
            Console.WriteLine("Transaction not successful.Insufficient funds"); 
          }
          else
          {
            account.AccountBalance -= amountWithdrawn;
            account.AccountBalance -= 50;
            // var w  = new Account
            // {
            //   AccountBalance = withdraw
            // };

            // accounts.Add(w);
            accountRepository.RefreshFile();

            Console.WriteLine($"Transaction Successful. You have successfully withdrawn {amountWithdrawn} and your account balance is {account.AccountBalance} and charges of 50 Naira has been deducted"); 
          }
        }
        catch (System.Exception)
        {
          Console.WriteLine("An error occurred");
        }
      } 
    }
}