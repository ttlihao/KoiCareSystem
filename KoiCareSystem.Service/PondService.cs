using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository;
using KoiCareSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class PondService : IPondService
    {
        private readonly IPondRepository pondRepository;

        public PondService (IPondRepository pondRepository)
        {
            this.pondRepository = pondRepository;
        }
        public void CreatePond(Pond pond)
        {
            pondRepository.CreatePond(pond);
        }

        public void DeletePond(int pondId)
        {
            pondRepository.DeletePond(pondId);
        }

        public List<Pond> GetAllPonds()
        {
            return pondRepository.GetAllPonds();
        }

        public Pond GetPondById(int id)
        {
            return pondRepository.GetPondById(id);
        }

        public void UpdatePond(Pond updatedPond)
        {
             pondRepository.UpdatePond(updatedPond);
        }
    }
}
