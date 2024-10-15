using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository;
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
        private WaterParameterRepos waterParameterRepos;

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
            WaterParameter>waterParameter = waterParameterRepos.GetWaterParameterByID(0);
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
