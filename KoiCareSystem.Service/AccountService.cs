using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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

        private readonly IMemoryCache _cache;

        public AccountService(IAccountRepository accountRepository, IMemoryCache cache)
        {
            _accountRepository = accountRepository;
            _cache = cache;
        }

        public void StoreVerificationToken(string email, string token)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) // Thời gian hết hạn của token
            };
            _cache.Set(email, token, cacheEntryOptions);
        }

        public bool ValidateVerificationToken(string email, string token)
        {
            if (_cache.TryGetValue(email, out string? cachedToken) && cachedToken == token)
            {
                _cache.Remove(email); // Xóa token sau khi xác minh thành công
                return true;
            }
            return false;
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

        public Account GetAccountById(int id) => _accountRepository.GetAccountById(id);

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

        public void ActivateAccount(string email)
        {
            _accountRepository.ActivateAccount(email);
        }
    }
}
