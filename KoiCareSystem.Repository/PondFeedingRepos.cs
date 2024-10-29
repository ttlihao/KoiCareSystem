﻿using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository
{
    public class PondFeedingRepos : IPondFeedingRepos
    {

        public List<PondFeeding> GetListPondFeeding() => PondFeedingDAO.Instance.GetListPondFeeding();

        public PondFeeding GetPondFeedingId(int Id) => PondFeedingDAO.Instance.GetPondFeedingId(Id);
    }
}