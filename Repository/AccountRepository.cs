using System;
using System.Collections.Generic;
using BankApp.Entities;
using BankApp.Shared;
using BankApp.Constant;
using System.IO;

namespace BankApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public static List<Account> accounts;
        public AccountRepository()
        {
          accounts  = new List<Account>();
          ReadFromFile();
        }

        public void WriteToFile(Account account)
        {
            try
            {
                using(StreamWriter write = new StreamWriter(Constants.filePath, true))
                {
                  write.WriteLine(account.ToString());
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message); 
            }
        }

        public void RefreshFile()
        {
            try
        {
            using(StreamWriter write = new StreamWriter(Constants.filePath, true))
            {
                foreach (var acc in accounts)
                {
                write.WriteLine(acc.ToString()); 
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); 
        }
        }

        public void ReadFromFile()
        {
            try
            {
               if (File.Exists(Constants.filePath))
               {
                var lines = File.ReadAllLines(Constants.filePath);
                foreach (var line in lines)
                {
                    var account = Account.ToAccount(line);
                    accounts.Add(account);
                }
               }
               else
               {
                 var dir =  Constants.dir;
                 Directory.CreateDirectory(dir);
                 var fileName = Constants.fileName;
                 var filePath = Path.Combine(dir, fileName);
                 using (File.Create(filePath))
                 {
                 }
               }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Account GetAccount(string password)
        {
            return accounts.Find(i => i.Password == password);
        }

        public List<Account> GetAll()
        {
            return accounts;
        }
    }
}