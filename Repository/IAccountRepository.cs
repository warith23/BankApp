using System;
using System.Collections.Generic;
using System.Linq;
using BankApp.Entities;

namespace BankApp.Repository
{
    public interface IAccountRepository
    {
      Account GetAccount(string password);
      List<Account> GetAll();
      void WriteToFile(Account account);
      void RefreshFile();
    }
}