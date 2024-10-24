
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiFishDAO _koiFishDAO;

        public KoiFishRepository(KoiFishDAO koiFishDAO)
        {
            _koiFishDAO = koiFishDAO;
        }
        public void CreateKoiFish(KoiFish koiFish) => _koiFishDAO.CreateKoiFish(koiFish);

        public void DeleteKoiFish(int koiFishId) => _koiFishDAO.DeleteKoiFish(koiFishId);


        public List<KoiFish> GetAllKoiFish() => _koiFishDAO.GetAllKoiFish();


        public KoiFish GetKoiFishById(int id) => _koiFishDAO.GetKoiFishById(id);

        public void UpdateKoiFish(KoiFish updatedKoiFish) => _koiFishDAO.UpdateKoiFish(updatedKoiFish);
    }
}
