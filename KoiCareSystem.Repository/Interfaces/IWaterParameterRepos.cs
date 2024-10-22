using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository.Interfaces
{
    public interface IWaterParameterRepos
    {
        public WaterParameter GetWaterParameterByID(int PondId);

        public List<WaterParameter> GetListWaterParameters();

        public bool AddWaterParameter(WaterParameter waterParameter);

        public bool UpdateWaterParameter(WaterParameter waterParameter);

        public bool DeleteWaterParameter(WaterParameter waterParameter);

    }
}
