using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class WaterParameterRepos : IWaterParameterRepos
    {
        public bool AddWaterParameter(WaterParameter waterParameter) => WaterParameterDAO.Instance.AddWaterParameter(waterParameter);

        public bool DeleteWaterParameter(WaterParameter waterParameter) => WaterParameterDAO.Instance.DeleteWaterParameter(waterParameter);

        public WaterParameter GetWaterParameterByID(int PondID) => WaterParameterDAO.Instance.GetWaterParameterByID(PondID);

        public List<WaterParameter> GetListWaterParameters() => WaterParameterDAO.Instance.GetListWaterParameters();

        public bool UpdateWaterParameter(WaterParameter waterParameter) => WaterParameterDAO.Instance.UpdateWaterParameter(waterParameter);
    }
}
