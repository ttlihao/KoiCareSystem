using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public interface IAccountService
    {

        public Account? GetAccountById(int id);
        public Account? GetAccountByUsername(string username);
        public List<Account> GetAllAccounts();
        public void Register(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(int accountId);
    }
}
