using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;

namespace KoiCareSystem.Service
{
    public class PondKoiFishService : IPondKoiFishService
    {
        private readonly IPondKoiFishRepository _pondKoiFishRepository;

        public PondKoiFishService(IPondKoiFishRepository pondKoiFishRepository)
        {
            _pondKoiFishRepository = pondKoiFishRepository;
        }

        public List<PondKoiFish> GetAllPondKoiFish() => _pondKoiFishRepository.GetAllPondKoiFish();
        public PondKoiFish GetPondKoiFishById(int pondId, int koiFishId) => _pondKoiFishRepository.GetPondKoiFishById(pondId, koiFishId);
        public void AddPondKoiFish(PondKoiFish pondKoiFish) => _pondKoiFishRepository.AddPondKoiFish(pondKoiFish);
        public void UpdatePondKoiFish(PondKoiFish pondKoiFish) => _pondKoiFishRepository.UpdatePondKoiFish(pondKoiFish);
        public void DeletePondKoiFish(int pondId, int koiFishId) => _pondKoiFishRepository.DeletePondKoiFish(pondId, koiFishId);
    }
}