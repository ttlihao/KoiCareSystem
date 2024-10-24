using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public class FeedingService : IFeedingService
    {
        private FeedingRepos feedingRepos;

        public FeedingService()
        {
            feedingRepos = new FeedingRepos();
        }
        public bool AddFeeding(Feeding feeding)
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
