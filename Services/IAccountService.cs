using System;
using BankApp.Entities;

namespace BankApp.Services
{
    public interface IAccountService
    {
        void Create(Account request);
        void Update(UpdateAccount update, string password);
        void DeleteAccount(string password);
        void ChangePassword(string password, string oldPassword, string newPassword);
    }
}