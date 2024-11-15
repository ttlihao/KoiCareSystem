using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class FeedingDAO
    {
        private CarekoisystemContext dbContext;


        private readonly PondDAO pondDAO;

        private readonly PondFeedingDAO PondFeedingDAO;

        private static FeedingDAO instance;


        public FeedingDAO()
        {
            dbContext = new CarekoisystemContext();
        }
 


        public static FeedingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedingDAO();
                }

                return instance;
            }
        }

        public Feeding GetFeedingByPondID(int? PondId)
        {
            return dbContext.Feedings.SingleOrDefault(m => m.PondFeedingId.Equals(PondId));
        }

        public Feeding AddFeeding(Feeding feeding)
        {
            
            dbContext.Feedings.Add(feeding);
            dbContext.SaveChanges(); 
            return feeding;
        }

        public bool DeleteFeeding(Feeding feeding)
        {
            bool isSuccess = false;
            Feeding feed = GetFeedingByPondID(feeding.Id);
            try
            {
                if (feed != null)
                {
                    feed.IsDeleted = true;
                    dbContext.Feedings.Update(feed);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can not save");
            }
            return isSuccess;
        }

        public bool UpdateFeeding(Feeding feeding)
        {
            bool isSuccess = false;
            Feeding feed = GetFeedingByPondID(feeding.PondFeedingId);

            try
            {
                if (feed != null)
                {
                    dbContext.Entry<Feeding>(feed).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public List<Feeding> GetListFeeding()
        {
            return dbContext.Feedings
            .Where(f => f.IsDeleted == false)
            .ToList();
        }



        public List<Feeding> GetFeedingsByAccount(int accountId)
        {
    
                // Retrieve feedings along with Pond data
                var feedings = dbContext.Feedings
                    .Include(f => f.PondFeedings) // Include PondFeedings relationship
                    .ThenInclude(pf => pf.Pond)   // Include the Pond within each PondFeeding
                    .Where(f => f.PondFeedings.Any(pf => pf.Pond.AccountId == accountId))
                    .ToList();

              

                return feedings;
         
        }



    }
}
