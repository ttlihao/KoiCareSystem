using KoiCareSystem.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository.Interfaces
{
    public interface IPondFeedingRepos
    {
        public PondFeeding GetPondFeedingId(int Id);
        public List<PondFeeding> GetListPondFeeding();

        public bool AddPondFeeding(int FeedingID, int PondID);

    }
}
