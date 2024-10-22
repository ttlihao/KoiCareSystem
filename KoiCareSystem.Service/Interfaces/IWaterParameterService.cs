using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public interface IWaterParameterService
    {
        public bool AddWaterParameter(WaterParameter waterParameter);

        public bool DeleteWaterParameter(WaterParameter waterParameter);

        public WaterParameter GetWaterParameterByID(int PondID);

        public List<WaterParameter> GetListWaterParameters();

        public bool UpdateWaterParameter(WaterParameter waterParameter);

    }
}
