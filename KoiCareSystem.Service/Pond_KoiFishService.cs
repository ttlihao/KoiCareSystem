using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Service
{
    public class Pond_KoiFishService : IPondKoiFishService
    {
        private readonly IPond_KoiFishRepository _pond_KoiFishRepository;

        public Pond_KoiFishService(IPond_KoiFishRepository pond_KoiFishRepository)
        {
            _pond_KoiFishRepository = pond_KoiFishRepository;
        }

        public List<Pond_KoiFish> GetAllPond_KoiFish() => _pond_KoiFishRepository.GetAllPond_KoiFish();
        public Pond_KoiFish GetPond_KoiFishById(int pondId, int koiFishId) => _pond_KoiFishRepository.GetPond_KoiFishById(pondId, koiFishId);
        public void AddPond_KoiFish(Pond_KoiFish pond_KoiFish) => _pond_KoiFishRepository.AddPond_KoiFish(pond_KoiFish);
        public void UpdatePond_KoiFish(Pond_KoiFish pond_KoiFish) => _pond_KoiFishRepository.UpdatePond_KoiFish(pond_KoiFish);
        public void DeletePond_KoiFish(int pondId, int koiFishId) => _pond_KoiFishRepository.DeletePond_KoiFish(pondId, koiFishId);
    }
}
