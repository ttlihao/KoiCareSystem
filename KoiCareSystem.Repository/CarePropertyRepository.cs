using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class CarePropertyRepository : ICarePropertyRepository
    {
        public async Task<bool> AddCareProperty(CareProperty careProperty)
        {
            return await Task.Run(() => CarePropertyDAO.Instance.AddCarePropertyAsync(careProperty));
        }

        public async Task<List<CareProperty>> GetCareProperties()
        {
            return await Task.Run(() => CarePropertyDAO.Instance.GetCarePropertiesAsync());
        }

        public async Task<CareProperty> GetCareProperty(int Id)
        {
            return await Task.Run(() => CarePropertyDAO.Instance.GetCarePropertyByIdAsync(Id));
        }

        public async Task<bool> RemoveCareProperty(int Id)
        {
            return await Task.Run(() => CarePropertyDAO.Instance.DeleteCarePropertyAsync(Id));
        }

        public async Task<bool> UpdateCareProperty(CareProperty careProperty)
        {
            return await Task.Run(() => CarePropertyDAO.Instance.UpdateCarePropertyAsync(careProperty));
        }
    }
}
