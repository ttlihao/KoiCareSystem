﻿
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
        public void CreateKoiFish(KoiFish koiFish, int pondId) => KoiFishDAO.Instance.CreateKoiFish(koiFish, pondId);

        public void DeleteKoiFish(int koiFishId) => KoiFishDAO.Instance.DeleteKoiFish(koiFishId);


        public List<KoiFish> GetAllKoiFish() =>KoiFishDAO.Instance.GetAllKoiFish();

        public List<KoiFish> GetKoiFishByAccountId(int accountId) => KoiFishDAO.Instance.GetKoiFishByAccountId(accountId);


        public KoiFish GetKoiFishById(int id) => KoiFishDAO.Instance.GetKoiFishById(id);

        public void UpdateKoiFish(KoiFish updatedKoiFish) => KoiFishDAO.Instance.UpdateKoiFish(updatedKoiFish);
    }
}
