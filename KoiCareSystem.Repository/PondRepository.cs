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
        public void CreatePond(Pond pond) => PondDAO.Instance.CreatePond(pond);


        public void DeletePond(int pondId) => PondDAO.Instance.DeletePond(pondId);

        public List<Pond> GetAllPonds() => PondDAO.Instance.GetAllPonds(); 


        public Pond GetPondById(int id) => PondDAO.Instance.GetPondById(id);

        public async Task<List<Pond>> GetPondsByAccountId(int accountId) => await PondDAO.Instance.GetPondsByAccountId(accountId);

        public void UpdatePond(Pond updatedPond) => PondDAO.Instance.UpdatePond(updatedPond);

    }
}
