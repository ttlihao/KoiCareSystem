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
    public class WaterParameterService : IWaterParameterService
    {
        private IWaterParameterRepos waterParameterRepos;

        public WaterParameterService()
        {
            waterParameterRepos = new WaterParameterRepos();
        }
        public bool AddWaterParameter(WaterParameter waterParameter)
        {
            return waterParameterRepos.AddWaterParameter(waterParameter);
        }

        public bool DeleteWaterParameter(WaterParameter waterParameter)
        {
            return waterParameterRepos.DeleteWaterParameter(waterParameter);
        }

        public List<WaterParameter> GetListWaterParameters()
        {
   
                List<WaterParameter> waterParameters = waterParameterRepos.GetListWaterParameters();
                List<WaterParameter> listWater = new List<WaterParameter>();

                foreach (WaterParameter water in waterParameters)
                {
                    if (water.IsDeleted != false)
                    {
                        listWater.Add(water);
                    }
                }

                return listWater;
    
        }

        public List<WaterParameter> GetListWaterParametersByPond(int pondId)
        {
            return waterParameterRepos.GetListWaterParametersByPond(pondId);
        }

        public WaterParameter GetWaterParameterByID(int PondID)
        {
            return waterParameterRepos.GetWaterParameterByID(PondID);
        }

        public bool UpdateWaterParameter(WaterParameter waterParameter)
        {
            return waterParameterRepos.UpdateWaterParameter(waterParameter);
        }
    }
}
