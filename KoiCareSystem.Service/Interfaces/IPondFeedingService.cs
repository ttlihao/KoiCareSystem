using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public interface IPondFeedingService
    {
        public PondFeeding GetPondFeedingId(int Id);
        public List<PondFeeding> GetListPondFeeding();
    }
}
