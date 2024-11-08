using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public interface IAccountRepository
    {
        public Account? GetAccountById(int id);
        public Account? GetAccountByUsername(string username);

        public Account? GetAccountByEmail(string email);

        public Account? CheckLogin(string email, string password);

        public List<Account> GetAllAccounts();
        public void Register(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(int accountId);
    }
}
