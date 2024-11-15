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
        public void ActivateAccount(string email) => AccountDAO.Instance.ActivateAccount(email);

        public Account? CheckLogin(string email, string password) => AccountDAO.Instance.CheckLogin(email, password);

        public void DeleteAccount(int accountId) => AccountDAO.Instance.DeleteAccount(accountId);


        public Account? GetAccountByEmail(string email) => AccountDAO.Instance.GetAccountByEmail(email);


        public Account GetAccountById(int id) => AccountDAO.Instance.GetAccountById(id);

        public Account? GetAccountByUsername(string username) => AccountDAO.Instance.GetAccountByUsername(username);

        public List<Account> GetAllAccounts() => AccountDAO.Instance.GetAllAccounts();


        public void Register(Account account) => AccountDAO.Instance.Register(account);

        public bool ResetPassword(int id, string newPassword) => AccountDAO.Instance.ResetPassword(id, newPassword);

        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
    }
}
