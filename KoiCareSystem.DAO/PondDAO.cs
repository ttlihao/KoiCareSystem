using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class PondDAO
    {

        private CarekoisystemContext _context;
        private static PondDAO instance;

        public PondDAO()
        {
            _context = new CarekoisystemContext();
        }

        public static PondDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PondDAO();
                }

                return instance;
            }
        }

        public void CreatePond(Pond pond)
        {
            if (pond == null)
            {
                throw new ArgumentNullException(nameof(pond));
            }

            pond.Deleted = false;
            var account = _context.Accounts.FirstOrDefault(c => c.Id == pond.AccountId);
            if (account == null)
            {
                throw new ArgumentException("Account not found.");
            }
            pond.Account = account;
            
            // Thêm pond vào cơ sở dữ liệu
            _context.Ponds.Add(pond);

            _context.SaveChanges();

            //Tạo PondFeeding cùng với Pond

            PondFeeding pondFeeding = new PondFeeding();
            
            pondFeeding.PondId = pond.Id;

            _context.PondFeedings.Add(pondFeeding);

            _context.SaveChanges();
            
           
        }


        public void UpdatePond(Pond updatedPond)
        {
            var existingPond = _context.Ponds.FirstOrDefault(p => p.Id == updatedPond.Id);

            if (existingPond == null)
            {
                throw new ArgumentException("Pond not found.");
            }

            // Cập nhật các thuộc tính
            existingPond.Name = updatedPond.Name;
            existingPond.Description = updatedPond.Description;
            existingPond.Location = updatedPond.Location;
            existingPond.Status = updatedPond.Status;

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
        }

        public void DeletePond(int pondId)
        {
            var pond = _context.Ponds.FirstOrDefault(p => p.Id == pondId);

            if (pond == null)
            {
                throw new ArgumentException("Pond not found.");
            }

            // Đánh dấu pond là đã xóa (soft delete)
            pond.Deleted = true;

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
        }

        public Pond GetPondById(int id)
        {
            var pond = _context.Ponds.FirstOrDefault(p => p.Id == id && p.Deleted == false);

            if (pond == null)
            {
                throw new ArgumentException("Pond not found.");
            }

            return pond;
        }

        public List<Pond> GetAllPonds()
        {
            return _context.Ponds
                .Where(p => p.Deleted == false)
                .Include(p => p.Account) // Include the related Account
                                         // Add more includes if needed, e.g., .Include(p => p.OtherRelatedEntities)
                .ToList();
        }

        public Task<List<Pond>> GetPondsByAccountId(int accountId)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null)
            {
                throw new ArgumentException("Account not found.");
            }

            return _context.Ponds
                .Where(p => p.AccountId == accountId && p.Deleted == false)
                .Include(p => p.Account) // Include related Account if needed
                .ToListAsync();
        }


    }
}
