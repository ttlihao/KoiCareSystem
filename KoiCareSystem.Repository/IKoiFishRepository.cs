using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public interface IKoiFishRepository
    {
        public KoiFish GetKoiFishById(int id);

        public List<KoiFish> GetAllKoiFish();

        public void CreateKoiFish(KoiFish koiFish);

        public void UpdateKoiFish(KoiFish updatedKoiFish);

        public void DeleteKoiFish(int koiFishId);

        public List<KoiFish> GetKoiFishByAccountId(int accountId);

    }
}
