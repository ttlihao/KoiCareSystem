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


        public Feeding AddFeeding(Feeding feeding) => FeedingDAO.Instance.AddFeeding(feeding);

        public bool DeleteFeeding(Feeding feeding) => FeedingDAO.Instance.DeleteFeeding(feeding);
        public Feeding GetFeedingByPondID(int? PondId) => FeedingDAO.Instance.GetFeedingByPondID(PondId);

        public List<Feeding> GetFeedingsByAccount(int accountId) => FeedingDAO.Instance.GetFeedingsByAccount(accountId);

        public List<Feeding> GetListFeeding() => FeedingDAO.Instance.GetListFeeding();

        public bool UpdateFeeding(Feeding feeding) => FeedingDAO.Instance.UpdateFeeding(feeding);
    }
}
