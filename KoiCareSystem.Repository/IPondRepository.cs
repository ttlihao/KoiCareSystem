
using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public interface IPondRepository
    {
        public void CreatePond(Pond pond);

        public void UpdatePond(Pond updatedPond);

        public void DeletePond(int pondId);

        public Pond GetPondById(int id);

        public List<Pond> GetAllPonds();

        public List<Pond> GetPondsByAccountId(int accountId);
        }
}
