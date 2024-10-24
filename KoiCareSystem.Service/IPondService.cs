﻿using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public interface IPondService
    {
        public void CreatePond(Pond pond);

        public void UpdatePond(Pond updatedPond);

        public void DeletePond(int pondId);

        public Pond GetPondById(int id);

        public List<Pond> GetAllPonds();
    }
}
