using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO _accountDAO;

        public AccountRepository(AccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public Account? CheckLogin(string email, string password)
        {
           return _accountDAO.CheckLogin(email, password);
        }

        public void DeleteAccount(int accountId)
        {
            _accountDAO.DeleteAccount(accountId);   
        }

        public Account? GetAccountByEmail(string email) => _accountDAO.GetAccountByEmail(email);


        public Account? GetAccountById(int id) => _accountDAO.GetAccountById(id);

        public Account? GetAccountByUsername(string username) => _accountDAO.GetAccountByUsername(username);

        public List<Account> GetAllAccounts() => _accountDAO.GetAllAccounts();
        

        public void Register(Account account) => _accountDAO.Register(account); 

        public void UpdateAccount(Account account) =>_accountDAO.UpdateAccount(account);
    }
}
