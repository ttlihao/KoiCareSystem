using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository.Interfaces
{
    public interface IPondKoiFishRepository
    {
        List<PondKoiFish> GetAllPondKoiFish();
        PondKoiFish GetPondKoiFishById(int pondId, int koiFishId);
        void AddPondKoiFish(PondKoiFish pondKoiFish);
        void UpdatePondKoiFish(PondKoiFish pondKoiFish);
        void DeletePondKoiFish(int pondId, int koiFishId);
    }
}
