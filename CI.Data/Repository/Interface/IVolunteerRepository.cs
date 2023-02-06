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
        Task<VolunteerMissionVM> MissionList(int pageIndex, int pageSize, string? filters, string? orderBy, string currentUser);

        Task<FavMissionModel> UpsertFavoriteMissions(string email, int MissionId);

        Task<FavMissionModel> RemoveFavoriteMissions(string email, int MissionId);
    }
}
