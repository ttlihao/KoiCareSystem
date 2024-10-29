using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class CareScheduleRepository : ICareScheduleRepository
    {
        public async Task<bool> AddCareSchedule(CareSchedule CareSchedule)
        {
            return await Task.Run(() => CareScheduleDAO.Instance.AddCareScheduleAsync(CareSchedule));
        }

        public async Task<List<CareSchedule>> GetCareSchedules()
        {
            return await Task.Run(() => CareScheduleDAO.Instance.GetCareSchedulesAsync());
        }

        public async Task<CareSchedule> GetCareSchedule(int Id)
        {
            return await Task.Run(() => CareScheduleDAO.Instance.GetCareScheduleByIdAsync(Id));
        }

        public async Task<bool> RemoveCareSchedule(int Id)
        {
            return await Task.Run(() => CareScheduleDAO.Instance.DeleteCareScheduleAsync(Id));
        }

        public async Task<bool> UpdateCareSchedule(CareSchedule careSchedule)
        {
            return await Task.Run(() => CareScheduleDAO.Instance.UpdateCareScheduleAsync(careSchedule));
        }
    }
}
