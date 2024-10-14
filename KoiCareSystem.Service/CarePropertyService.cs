using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Repository;
using KoiCareSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class CarePropertyService : ICarePropertyService
    {
        private ICarePropertyRepository CarePropertyRepository;

        public CarePropertyService()
        {
            CarePropertyRepository = new CarePropertyRepository();
        }

        public async Task<bool> AddCareProperty(CareProperty CareProperty)
        {
            return await CarePropertyRepository.AddCareProperty(CareProperty);
        }

        public async Task<CareProperty> GetCareProperty(int id)
        {
            return await CarePropertyRepository.GetCareProperty(id);
        }

        public async Task<List<CareProperty>> GetCareProperties()
        {
            return await CarePropertyRepository.GetCareProperties();
        }

        public async Task<bool> RemoveCareProperty(int CarePropertyId)
        {
            return await CarePropertyRepository.RemoveCareProperty(CarePropertyId);
        }

        public async Task<bool> UpdateCareProperty(CareProperty CareProperty)
        {
            return await CarePropertyRepository.UpdateCareProperty(CareProperty);
        }
    }
}
