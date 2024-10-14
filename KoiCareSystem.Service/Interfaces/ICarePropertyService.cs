﻿using KoiCareSystem.BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public interface ICarePropertyService
    {
        public Task<CareProperty> GetCareProperty(int Id);
        public Task<List<CareProperty>> GetCareProperties();
        public Task<bool> AddCareProperty(CareProperty careProperty);
        public Task<bool> RemoveCareProperty(int Id);
        public Task<bool> UpdateCareProperty(CareProperty careProperty);
    }
}
