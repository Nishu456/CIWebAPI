using CI.Data.Repository.Interface;
using CI.Models;
using CI.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Data.Repository
{
    public class VolunteerRepository: IVolunteerRepository 
    {
        private readonly CIDBContext _cIDB;
        private readonly IConfiguration _config;

        public VolunteerRepository(CIDBContext cIDB, IConfiguration config)
        {
            _cIDB = cIDB;
            _config = config;
        }

        public async Task<VolunteerMissionVM> MissionList(int pageIndex, int pageSize)
        {
            List<VolnteerMissionModel> volnteerMission = await (from mission in _cIDB.Missions
                                                    join country in _cIDB.Countries on mission.CountryId equals country.CountryId
                                                    join city in _cIDB.Cities on mission.CityId equals city.CityId
                                                    join theme in _cIDB.MissionThemes on mission.ThemeId equals theme.ThemeId
                                                    select new VolnteerMissionModel()
                                                    {
                                                        MissionId = mission.MissionId,
                                                        MissionTitle = mission.MissionTitle,
                                                        MissionDescription = mission.MissionDescription,
                                                        MissionType = mission.MissionType,
                                                        Theme = theme.ThemeName,
                                                        Skills = mission.Skills,
                                                        StartDate = mission.StartDate,
                                                        EndDate = mission.EndDate,
                                                        OrganizationName = mission.OrganizationName,
                                                        OrganizationDetail = mission.OrganizationDetail,
                                                        City = city.CityName,
                                                        Country = country.CountryName,
                                                        TotalSeats = Convert.ToInt32(mission.TotalSeats),
                                                        RegistrationDeadline = mission.RegistrationDeadline,
                                                        Availability = mission.Availability,
                                                        Images = new Base64strConversion(_config).convertToBase64(mission.Images, "images", "Mission"),
                                                        Documnets = new Base64strConversion(_config).convertToBase64(mission.Documents, "docs", "Mission")
                                                    }).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            List<string> countrylst = await (from mission in _cIDB.Missions
                                          join country in _cIDB.Countries on mission.CountryId equals country.CountryId
                                          select country.CountryName).Distinct().ToListAsync();

            List<string> citylst = await (from mission in _cIDB.Missions
                                             join city in _cIDB.Cities on mission.CityId equals city.CityId
                                             select city.CityName).Distinct().ToListAsync();

            List<string> themelst = await (from mission in _cIDB.Missions
                                             join theme in _cIDB.MissionThemes on mission.ThemeId equals theme.ThemeId
                                             select theme.ThemeName).Distinct().ToListAsync();

            List<string> tempskilll = await (from mission in _cIDB.Missions
                                             select mission.Skills).Distinct().ToListAsync();

            List<string> skilllst = new List<string>();

            foreach (string s in tempskilll)
            {
                if (s.Contains(','))
                {
                    foreach(string str in s.Split(','))
                        skilllst.Add(str);
                }
                else
                    skilllst.Add(s);
            }

            skilllst = skilllst.Distinct().ToList();


            int totalCount = await _cIDB.Missions.CountAsync();

            VolunteerMissionVM volunteerMissionVM = new VolunteerMissionVM()
            {
                volnteerMissions = volnteerMission,
                country = countrylst,
                city = citylst,
                themes = themelst,
                skills = skilllst,
                totalCount = totalCount
            };

            return volunteerMissionVM;
        }
    }
}
