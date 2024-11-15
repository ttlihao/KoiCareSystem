using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class KoiFishDAO
    {
        private CarekoisystemContext _context;
        private static KoiFishDAO instance;

        public KoiFishDAO()
        {
            _context = new CarekoisystemContext();
        }

        public static KoiFishDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiFishDAO();
                }

                return instance;
            }
        }


        public KoiFish GetKoiFishById(int id)
        {
            var koiFish = _context.KoiFishes.FirstOrDefault(k => k.Id == id && k.Deleted == false);

            if (koiFish == null)
            {
                throw new ArgumentException("Koi fish not found.");
            }

            return koiFish;
        }

       
        public List<KoiFish> GetAllKoiFish()
        {
            return _context.KoiFishes.Where(k => k.Deleted == false).ToList();
        }

        public void CreateKoiFish(KoiFish koiFish, int pondId)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish));
            }

            var pond = _context.Ponds.FirstOrDefault(p => p.Id == pondId && p.Deleted == false);

            if (pond == null)
            {
                throw new ArgumentException($"Pond with ID {pondId} not found or is marked as deleted.");
            }

            // Set the creation time and default deleted status
            koiFish.CreatedTime = DateTime.Now;
            koiFish.Deleted = false;

            // Create relationship entry and add koi fish to context
            var pondKoiFish = new PondKoiFish
            {
                Koifish = koiFish,
                Pond = pond
            };

            _context.KoiFishes.Add(koiFish);
            _context.PondKoiFishes.Add(pondKoiFish); // Add to linking table if you have one

            // Save changes to database
            _context.SaveChanges();
        }

        public void UpdateKoiFish(KoiFish updatedKoiFish)
        {
            var existingKoiFish = _context.KoiFishes.FirstOrDefault(k => k.Id == updatedKoiFish.Id);

            if (existingKoiFish == null)
            {
                throw new ArgumentException("Koi fish not found.");
            }

            // Cập nhật các thuộc tính
            existingKoiFish.FishName = updatedKoiFish.FishName;
            existingKoiFish.ImagePath = updatedKoiFish.ImagePath;
            existingKoiFish.Age = updatedKoiFish.Age;
            existingKoiFish.Species = updatedKoiFish.Species;
            existingKoiFish.Gender = updatedKoiFish.Gender;
            existingKoiFish.HealthStatus = updatedKoiFish.HealthStatus;
            existingKoiFish.Origin = updatedKoiFish.Origin;
            existingKoiFish.Note = updatedKoiFish.Note;

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
        }

        public void DeleteKoiFish(int koiFishId)
        {
            var koiFish = _context.KoiFishes.FirstOrDefault(k => k.Id == koiFishId);

            if (koiFish == null)
            {
                throw new ArgumentException("Koi fish not found.");
            }

            // Đánh dấu là đã xóa
            koiFish.Deleted = true;

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
        }

        public List<KoiFish> GetKoiFishByAccountId(int accountId)
        {
            var koiFishes = _context.PondKoiFishes
                .Include(c => c.Pond)
                .Include(c => c.Koifish)
                .Where(pkf => pkf.Pond != null && pkf.Pond.AccountId == accountId) // Đảm bảo Pond không null trước khi lấy AccountId
                .Select(pkf => pkf.Koifish)
                .Where(kf => kf != null && kf.Deleted == false) // Đảm bảo KoiFish không null và chưa bị xóa
                .ToList();

            if (!koiFishes.Any())
            {
                Console.WriteLine("No koi fish found for the specified account.");
            }
            else
            {
                Console.WriteLine($"Found {koiFishes.Count} koi fish(es) for the specified account.");
            }

            return koiFishes;
        }


    }
}
