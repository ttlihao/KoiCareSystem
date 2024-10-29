using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class KoiFishDAO
    {
        private readonly CarekoisystemContext _context;

        public KoiFishDAO(CarekoisystemContext context)
        {
            _context = context;
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

        public void CreateKoiFish(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish));
            }

            // Đánh dấu thời gian tạo mới
            koiFish.CreatedTime = DateTime.Now;

            // Đặt giá trị Deleted mặc định là false
            koiFish.Deleted = false;

            // Thêm con cá vào cơ sở dữ liệu
            _context.KoiFishes.Add(koiFish);

            // Lưu thay đổi vào cơ sở dữ liệu
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
    }
}
