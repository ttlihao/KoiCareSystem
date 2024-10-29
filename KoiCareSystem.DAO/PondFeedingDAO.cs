using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class PondFeedingDAO
    {
        private CarekoisystemContext dbContext;

        private static PondFeedingDAO instance;

        public static PondFeedingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PondFeedingDAO();
                }
                return instance;
            }
        }

        public PondFeedingDAO()
        {
            dbContext = new CarekoisystemContext();
        }

        public PondFeeding GetPondFeedingId(int? id)
        {
            return dbContext.PondFeedings.SingleOrDefault(m => m.Id.Equals(id));
        }

        public List<PondFeeding> GetListPondFeeding() {
            return dbContext.PondFeedings.ToList();
        }

    }
}
