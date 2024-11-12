using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account? CheckLogin(string email, string password)
        {
            return _accountRepository.CheckLogin(email, password);
        }

        public void DeleteAccount(int accountId)
        {
            _accountRepository.DeleteAccount(accountId);
        }

        public Account? GetAccountByEmail(string email)
        {
            return _accountRepository.GetAccountByEmail(email);
        }

        public Account GetAccountById(int id) => _accountRepository?.GetAccountById(id);

        public Account? GetAccountByUsername(string username)
        {
            return _accountRepository.GetAccountByUsername(username);
        }

        public List<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public void Register(Account account)
        {
            _accountRepository.Register(account);
        }

        public void UpdateAccount(Account account)
        {
            _accountRepository.UpdateAccount(account);
        }
    }
}
