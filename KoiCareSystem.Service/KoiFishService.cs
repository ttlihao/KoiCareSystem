using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository _koiFishRepo;

        public KoiFishService (IKoiFishRepository koiFishRepo)
        {
            _koiFishRepo = koiFishRepo;
        }
        public void CreateKoiFish(KoiFish koiFish)
        {
            _koiFishRepo.CreateKoiFish(koiFish);
        }

        public void DeleteKoiFish(int koiFishId)
        {
            _koiFishRepo.DeleteKoiFish(koiFishId);
        }

        public List<KoiFish> GetAllKoiFish()
        {
           return _koiFishRepo.GetAllKoiFish();
        }

        public List<KoiFish> GetKoiFishByAccountId(int accountId)
        {
            return _koiFishRepo.GetKoiFishByAccountId(accountId);
        }

        public KoiFish GetKoiFishById(int id)
        {
           return _koiFishRepo.GetKoiFishById (id);
        }

        public void UpdateKoiFish(KoiFish updatedKoiFish)
        {
            _koiFishRepo.UpdateKoiFish (updatedKoiFish);
        }
    }
}
