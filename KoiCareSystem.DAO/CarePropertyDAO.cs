using KoiCareSystem.BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class CarePropertyDAO
    {
        private CarekoisystemContext _context;
        private static CarePropertyDAO instance;

        public CarePropertyDAO()
        {
            _context = new CarekoisystemContext();
        }

        public static CarePropertyDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CarePropertyDAO();
                }
                return instance;
            }
        }

        // Create
        public async Task<bool> AddCarePropertyAsync(CareProperty careProperty)
        {
            bool isSuccess = false;
            try
            {
                if (careProperty != null)
                {
                    // Check if the care property already exists
                    var existingProperty = await _context.CareProperties
                        .FirstOrDefaultAsync(cp => cp.Id == careProperty.Id);
                    if (existingProperty == null)
                    {
                        await _context.CareProperties.AddAsync(careProperty);
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
        public async Task<CareProperty> GetCarePropertyByIdAsync(int id)
        {
            if (id > 0)
            {
                return await _context.CareProperties.FirstOrDefaultAsync(c => c.Id == id);
            }
            return null;
        }

        // Read all
        public async Task<List<CareProperty>> GetCarePropertiesAsync()
        {
            return await _context.CareProperties.ToListAsync();
        }

        // Update
        public async Task<bool> UpdateCarePropertyAsync(CareProperty careProperty)
        {
            bool isSuccess = false;
            var existingEntity = _context.CareProperties.Local.FirstOrDefault(e => e.Id == careProperty.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.CareProperties.Attach(careProperty);
            try
            {
                if (careProperty != null)
                {
                    _context.Entry(careProperty).State = EntityState.Modified;
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
        public async Task<bool> DeleteCarePropertyAsync(int id)
        {
            bool isSuccess = false;
            try
            {
                var careProperty = await _context.CareProperties.FirstOrDefaultAsync(c => c.Id == id);
                if (careProperty != null)
                {
                    _context.CareProperties.Remove(careProperty);
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
