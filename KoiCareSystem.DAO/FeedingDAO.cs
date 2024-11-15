﻿using KoiCareSystem.BussinessObject;
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

  

        public FeedingDAO(PondDAO pondDAO, PondFeedingDAO PondFeedingDAO)
        {
            this.pondDAO = pondDAO;
            dbContext = new CarekoisystemContext();
            this.PondFeedingDAO = PondFeedingDAO;
        }

        public Feeding GetFeedingByPondID(int? PondId)
        {
            return dbContext.Feedings.SingleOrDefault(m => m.PondFeedingId.Equals(PondId));
        }




        public bool AddFeeding(Feeding feeding)
        {
            bool isSuccess = false;
            
          
            Feeding feed = GetFeedingByPondID(feeding.Id);
            try
            {
                
                if (feed == null)
                {
                    dbContext.Feedings.Add(feeding);
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

        public bool DeleteWaterParameter(Feeding feeding)
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
    }
}
