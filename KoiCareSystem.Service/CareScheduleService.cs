using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Services
{
    public class CareScheduleService : ICareScheduleService
    {
        private ICareScheduleRepository careScheduleRepository;

        public CareScheduleService()
        {
            careScheduleRepository = new CareScheduleRepository();
        }

        public async Task<bool> AddCareSchedule(CareSchedule careSchedule)
        {
            return await careScheduleRepository.AddCareSchedule(careSchedule);
        }

        public async Task<CareSchedule> GetCareSchedule(int id)
        {
            return await careScheduleRepository.GetCareSchedule(id);
        }

        public async Task<List<CareSchedule>> GetCareSchedules()
        {
            return await careScheduleRepository.GetCareSchedules();
        }

        public async Task<bool> RemoveCareSchedule(int careScheduleId)
        {
            return await careScheduleRepository.RemoveCareSchedule(careScheduleId);
        }

        public async Task<bool> UpdateCareSchedule(CareSchedule careSchedule)
        {
            return await careScheduleRepository.UpdateCareSchedule(careSchedule);
        }
    }
}
