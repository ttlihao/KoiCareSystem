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
    public class FeedingService : IFeedingService
    {
        private IFeedingRepos feedingRepos;

        public FeedingService(IFeedingRepos feedingRepos)
        {
            this.feedingRepos = feedingRepos;
        }
        public Feeding AddFeeding(Feeding feeding)
        {
            return feedingRepos.AddFeeding(feeding);
        }

        public bool DeleteFeeding(Feeding feeding)
        {
            return feedingRepos.DeleteFeeding(feeding);
        }

        public Feeding GetFeedingByPondID(int? PondId)
        {
            return feedingRepos.GetFeedingByPondID(PondId);
        }

        public List<Feeding> GetFeedingsByAccount(int accountId)
        {
            return feedingRepos.GetFeedingsByAccount(accountId);
        }

        public List<Feeding> GetListFeeding()
        {
            return feedingRepos.GetListFeeding();
        }

        public bool UpdateFeeding(Feeding feeding)
        {
            return feedingRepos.UpdateFeeding(feeding);
        }
    }
}
