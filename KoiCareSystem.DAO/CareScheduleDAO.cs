using KoiCareSystem.BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class CareScheduleDAO
    {
        private CarekoisystemContext _context;
        private static CareScheduleDAO instance;

        public CareScheduleDAO()
        {
            _context = new CarekoisystemContext();
        }

        public static CareScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CareScheduleDAO();
                }
                return instance;
            }
        }

        // Create
        public async Task<bool> AddCareScheduleAsync(CareSchedule careSchedule)
        {
            bool isSuccess = false;
            try
            {
                if (careSchedule != null)
                {
                    // Check if the care schedule already exists
                    var existingSchedule = await _context.CareSchedules
                        .FirstOrDefaultAsync(cs => cs.Id == careSchedule.Id);
                    if (existingSchedule == null)
                    {
                        await _context.CareSchedules.AddAsync(careSchedule);
                        await _context.SaveChangesAsync();
                        isSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }

        // Read by Id
        public async Task<CareSchedule> GetCareScheduleByIdAsync(int id)
        {
            if (id > 0)
            {
                return await _context.CareSchedules.FirstOrDefaultAsync(c => c.Id == id);
            }
            return null;
        }

        // Read all
        public async Task<List<CareSchedule>> GetCareSchedulesAsync()
        {
            return await _context.CareSchedules.ToListAsync();
        }

        // Update
        public async Task<bool> UpdateCareScheduleAsync(CareSchedule careSchedule)
        {
            bool isSuccess = false;
            var existingEntity = _context.CareSchedules.Local.FirstOrDefault(e => e.Id == careSchedule.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.CareSchedules.Attach(careSchedule);
            try
            {
                if (careSchedule != null)
                {
                    _context.Entry(careSchedule).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }

        // Delete
        public async Task<bool> DeleteCareScheduleAsync(int id)
        {
            bool isSuccess = false;
            try
            {
                var careSchedule = await _context.CareSchedules.FirstOrDefaultAsync(c => c.Id == id);
                if (careSchedule != null)
                {
                    _context.CareSchedules.Remove(careSchedule);
                    await _context.SaveChangesAsync();
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }
    }
}

