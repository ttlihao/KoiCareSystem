using KoiCareSystem.BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository.Interfaces
{
    public interface IFeedingRepos
    {
        public Feeding GetFeedingByPondID(int? PondId);

        public List<Feeding> GetListFeeding();

        public bool AddFeeding(Feeding feeding);

        public bool UpdateFeeding(Feeding feeding);

        public bool DeleteFeeding(Feeding feeding);

    }
}
