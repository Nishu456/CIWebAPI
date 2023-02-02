using CI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Data.Repository.Interface
{
    public interface IVolunteerRepository
    {
        Task<VolunteerMissionVM> MissionList(int pageIndex, int pageSize);
    }
}
