using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class PondRepository : IPondRepository
    {
        private readonly PondDAO _pondDAO;

        public PondRepository(PondDAO pondDAO)
        {
            _pondDAO = pondDAO;
        }
        public void CreatePond(Pond pond) => _pondDAO.CreatePond(pond);


        public void DeletePond(int pondId) => _pondDAO.DeletePond(pondId);

        public List<Pond> GetAllPonds() => _pondDAO.GetAllPonds();  


        public Pond GetPondById(int id) => _pondDAO.GetPondById(id);

        public void UpdatePond(Pond updatedPond) => _pondDAO.UpdatePond(updatedPond);

    }
}
