using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;

namespace KoiCareSystem.Repository
{
    public class PondKoiFishRepository : IPondKoiFishRepository
    {
        private readonly PondKoiFishDAO _pondKoiFishDAO;

        public PondKoiFishRepository(PondKoiFishDAO pondKoiFishDAO)
        {
            _pondKoiFishDAO = pondKoiFishDAO;
        }

        public List<PondKoiFish> GetAllPondKoiFish() => _pondKoiFishDAO.GetAllPondKoiFish();
        public PondKoiFish GetPondKoiFishById(int pondId, int koiFishId) => _pondKoiFishDAO.GetPondKoiFishById(pondId, koiFishId);
        public void AddPondKoiFish(PondKoiFish pondKoiFish) => _pondKoiFishDAO.AddPondKoiFish(pondKoiFish);
        public void UpdatePondKoiFish(PondKoiFish pondKoiFish) => _pondKoiFishDAO.UpdatePondKoiFish(pondKoiFish);
        public void DeletePondKoiFish(int pondId, int koiFishId) => _pondKoiFishDAO.DeletePondKoiFish(pondId, koiFishId);
    }
}