using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystem.DAO
{
    public class PondKoiFishDAO
    {
        private readonly CarekoisystemContext _context;

        public PondKoiFishDAO(CarekoisystemContext context)
        {
            _context = context;
        }

        public List<PondKoiFish> GetAllPondKoiFish()
        {
            return _context.PondKoiFishes
                .Include(pk => pk.Pond)
                .Include(pk => pk.KoiFish)
                .ToList();
        }

        public PondKoiFish GetPondKoiFishById(int pondId, int koiFishId)
        {
            return _context.PondKoiFishes
                .Include(pk => pk.Pond)
                .Include(pk => pk.KoiFish)
                .FirstOrDefault(pk => pk.PondId == pondId && pk.KoifishId == koiFishId);
        }

        public void AddPondKoiFish(PondKoiFish pondKoiFish)
        {
            _context.PondKoiFishes.Add(pondKoiFish);
            _context.SaveChanges();
        }

        public void UpdatePondKoiFish(PondKoiFish pondKoiFish)
        {
            var existingPondKoiFish = _context.PondKoiFishes.Find(pondKoiFish.PondId, pondKoiFish.KoifishId);
            if (existingPondKoiFish != null)
            {
                _context.Entry(existingPondKoiFish).CurrentValues.SetValues(pondKoiFish);
                _context.SaveChanges();
            }
        }

        public void DeletePondKoiFish(int pondId, int koiFishId)
        {
            var pondKoiFish = _context.PondKoiFishes.Find(pondId, koiFishId);
            if (pondKoiFish != null)
            {
                _context.PondKoiFishes.Remove(pondKoiFish);
                _context.SaveChanges();
            }
        }
    }
}