using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class PondFeedingService : IPondFeedingService
    {

        private IPondFeedingRepos pondFeedingRepos;

        public PondFeedingService()
        {
            pondFeedingRepos = new PondFeedingRepos();
        }

        public bool AddPondFeeding(int FeedingID, int PondID)
        {
            return pondFeedingRepos.AddPondFeeding(FeedingID, PondID);
        }

        public List<PondFeeding> GetListPondFeeding()
        {
            return pondFeedingRepos.GetListPondFeeding();
        }

        public PondFeeding GetPondFeedingId(int Id)
        {
            return pondFeedingRepos.GetPondFeedingId(Id);
        }
    }
}
