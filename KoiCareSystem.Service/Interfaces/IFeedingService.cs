﻿using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public interface IFeedingService
    {
        public Feeding GetFeedingByPondID(int? PondId);

        public List<Feeding> GetListFeeding();

        public Feeding AddFeeding(Feeding feeding);

        public bool UpdateFeeding(Feeding feeding);

        public bool DeleteFeeding(Feeding feeding);

        List<Feeding> GetFeedingsByAccount(int accountId);
    }
}
