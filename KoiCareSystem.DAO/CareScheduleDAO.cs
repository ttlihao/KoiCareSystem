﻿using KoiCareSystem.BussinessObject;
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
                    // Validate care_type
                    var validCareTypes = new List<string> { "CHANGE_WATER", "CLEAN", "FEED", "TREATMENT" };
                    if (!validCareTypes.Contains(careSchedule.CareType))
                    {
                        throw new Exception("Invalid care type.");
                    }

                    // Check if the care schedule already exists
                    var existingSchedule = await _context.CareSchedules
                        .FirstOrDefaultAsync(cs => cs.Id == careSchedule.Id);
                    if (_context.Ponds.Any(p => p.Id == careSchedule.PondId))
                    {
                        if (existingSchedule == null)
                        {
                            careSchedule.Pond = await _context.Ponds.FindAsync(careSchedule.PondId);
                            await _context.CareSchedules.AddAsync(careSchedule);
                            await _context.SaveChangesAsync();
                            isSuccess = true;
                        }
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
            if (id <= 0)
            {
                return null;
            }

            var careSchedule = await _context.CareSchedules
                .Include(cs => cs.CareProperties)
                .Include(cs => cs.Pond)
                .FirstOrDefaultAsync(c => c.Id == id);

            return careSchedule;
        }

        // Read all
        public async Task<List<CareSchedule>> GetCareSchedulesAsync()
        {
            return await _context.CareSchedules
                .Include(p => p.CareProperties)
                .Include(p => p.Pond)
                .ToListAsync();
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
        public List<CareSchedule> GetCareScheduleByAccountId(int accountId)
        {
            var careSchedules = _context.CareSchedules
                .Include(cs => cs.Pond)
                .Where(cs => cs.Pond != null && cs.Pond.AccountId == accountId)
                .ToList();

            if (!careSchedules.Any())
            {
                Console.WriteLine("No care schedules found for the specified account.");
            }
            else
            {
                Console.WriteLine($"Found {careSchedules.Count} care schedule(s) for the specified account.");
            }

            return careSchedules;
        }

    }
}

