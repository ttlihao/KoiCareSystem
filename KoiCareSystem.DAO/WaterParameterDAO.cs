using KoiCareSystem.BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class WaterParameterDAO
    {

        private CarekoisystemContext dbContext;

        private static WaterParameterDAO instance;

        public static WaterParameterDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WaterParameterDAO();
                }
                return instance;
            }
        }

        public WaterParameterDAO()
        {
            dbContext = new CarekoisystemContext();
        }

        public WaterParameter GetWaterParameterByID(int PondId)
        {
            return dbContext.WaterParameters.SingleOrDefault(m => m.PondId.Equals(PondId));
        }



        public bool AddWaterParameter(WaterParameter waterParameter)
        {
            bool isSuccess = false;
            WaterParameter water = GetWaterParameterByID(waterParameter.PondId);
            try
            {
                if (water == null)
                {
                    dbContext.WaterParameters.Add(waterParameter);
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

        public bool DeleteWaterParameter(WaterParameter waterParameter)
        {
            bool isSuccess = false;
            WaterParameter water = GetWaterParameterByID(waterParameter.PondId);
            try
            {
                if (water != null)
                {
                    water.IsDeleted = true;
                    dbContext.WaterParameters.Update(water);
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

        public bool UpdateWaterParameter(WaterParameter waterParameter)
        {
            bool isSuccess = false;
            WaterParameter water = GetWaterParameterByID(waterParameter.PondId);

            try
            {
                if (water != null)
                {
                    dbContext.Entry<WaterParameter>(waterParameter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public List<WaterParameter> GetListWaterParameters()
        {
            return dbContext.WaterParameters.ToList();
        }
    }
}
