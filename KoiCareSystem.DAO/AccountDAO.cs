using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class AccountDAO
    {
        private CarekoisystemContext _context;
        private static AccountDAO instance;

        public AccountDAO()
        {
            _context = new CarekoisystemContext();
        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }

                return instance;
            }
        }

        // Lấy tài khoản theo ID
        public Account GetAccountById(int id)
        {
            return _context.Accounts.Find(id);
        }


        // Lấy tài khoản theo tên người dùng
        public Account? GetAccountByUsername(string username)
        {
            return _context.Accounts.SingleOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        // Lấy tài khoản theo Email
        public Account? GetAccountByEmail(string email)
        {
            return _context.Accounts.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
        }


        // Lấy tất cả tài khoản
        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.Where(a => (bool)!a.Deleted).ToList();
        }


        // Hàm mã hóa mật khẩu 
        private string HashPassword(string password)
        {
            // Thay thế bằng thuật toán mã hóa thực tế (như SHA256 hoặc bcrypt)
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public Account? CheckLogin(string email, string password)
        {
            // Kiểm tra xem người dùng có tồn tại không
            var user = _context.Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);

            // Nếu tìm thấy người dùng, trả về dữ liệu (đăng nhập thành công)
            if (user != null)
            {
                return user;
            }

            // Nếu không tìm thấy người dùng, trả về null (đăng nhập thất bại)
            return null;
        }

        public void ActivateAccount(string email)
        {
            var account = GetAccountByEmail(email);
            if (account != null && account.Status == "INACTIVE")
            {
                account.Status = "ACTIVE";
                _context.SaveChanges();
            }
        }


        public void Register(Account account)
        {
            try
            {
                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrEmpty(account.Username))
                    throw new ArgumentException("Username is required.");
                if (string.IsNullOrEmpty(account.Password))
                    throw new ArgumentException("Password is required.");
                if (string.IsNullOrEmpty(account.Email))
                    throw new ArgumentException("Email is required.");

                // Kiểm tra xem email hoặc tên người dùng đã tồn tại chưa
                if (_context.Accounts.Any(a => a.Username == account.Username))
                    throw new InvalidOperationException("Username already exists.");
                if (_context.Accounts.Any(a => a.Email == account.Email))
                    throw new InvalidOperationException("Email already exists.");

                //// Mã hóa mật khẩu 
                //account.Password = HashPassword(account.Password);

                // Thêm tài khoản mới vào cơ sở dữ liệu
                _context.Accounts.Add(account);
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding account: {ex.Message}");
                throw;
            }
        }

        public void UpdateAccount(Account account)
        {
            try
            {
                var existingAccount = _context.Accounts.Find(account.Id);
                if (existingAccount != null)
                {
                    // Kiểm tra xem username và email có trùng với các tài khoản khác không
                    if (_context.Accounts.Any(a => a.Username == account.Username && a.Id != account.Id))
                        throw new InvalidOperationException("Username already exists.");
                    if (_context.Accounts.Any(a => a.Email == account.Email && a.Id != account.Id))
                        throw new InvalidOperationException("Email already exists.");

                    // Cập nhật thông tin tài khoản
                    existingAccount.Username = account.Username;
                    existingAccount.Password = account.Password;
                    existingAccount.Name = account.Name;
                    existingAccount.Email = account.Email;
                    existingAccount.Address = account.Address;
                    existingAccount.Avatar = account.Avatar;
                    existingAccount.Role = account.Role;
                    existingAccount.Status = account.Status;
                    existingAccount.Deleted = account.Deleted;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating account: {ex.Message}");
                throw;
            }
        }

        public void DeleteAccount(int id)
        {
            try
            {
                var account = _context.Accounts.Find(id);
                if (account != null)
                {
                    account.Deleted = true;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting account: {ex.Message}");
                throw;
            }
        }

    }
}
