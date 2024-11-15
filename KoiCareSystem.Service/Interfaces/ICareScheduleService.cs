using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public interface ICareScheduleService
    {
        public Task<CareSchedule> GetCareSchedule(int id);
        public Task<List<CareSchedule>> GetCareSchedules();
        public Task<bool> AddCareSchedule(CareSchedule CareSchedule);
        public Task<bool> RemoveCareSchedule(int CareScheduleId);
        public Task<bool> UpdateCareSchedule(CareSchedule CareSchedule);
        List<CareSchedule> GetCareScheduleByAccountId(int accountId);
    }
}
