using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public interface IAccountService
    {

        public Account GetAccountById(int id);
        public Account? GetAccountByUsername(string username);
        public Account? GetAccountByEmail(string email);

        public void StoreVerificationToken(string email, string token);

        public bool ValidateVerificationToken(string email, string token);
        public void ActivateAccount(string email);
        public Account? CheckLogin(string email, string password);
        public List<Account> GetAllAccounts();
        public void Register(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(int accountId);
    }
}
