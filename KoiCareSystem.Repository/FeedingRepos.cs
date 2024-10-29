using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class FeedingRepos : IFeedingRepos
    {
        private readonly FeedingDAO feedingDAO;

        public FeedingRepos(FeedingDAO feedingDAO)
        {
            this.feedingDAO = feedingDAO;
        }

        public bool AddFeeding(Feeding feeding) => feedingDAO.AddFeeding(feeding);

        public bool DeleteFeeding(Feeding feeding) => feedingDAO.DeleteWaterParameter(feeding);
        public Feeding GetFeedingByPondID(int? PondId) => feedingDAO.GetFeedingByPondID(PondId);

        public List<Feeding> GetListFeeding() => feedingDAO.GetListFeeding();

        public bool UpdateFeeding(Feeding feeding) => feedingDAO.UpdateFeeding(feeding);
    }
}
