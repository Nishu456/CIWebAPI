using CI.BusinessLogic.Repository.Interface;
using CI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerRepository _volunteer;

        public VolunteerController(IVolunteerRepository volunteer)
        {
            _volunteer = volunteer;
        }

        [HttpGet]
        [Route("volunteerMission")]
        public async Task<IActionResult> volunteerMission(int pageIndex, int pageSize, string? filterValues, string? orderBy)
        {
            return Ok(await _volunteer.MissionList(pageIndex, pageSize, filterValues, orderBy, User.Identity.Name));
        }

        [HttpPost]
        [Route("upsertFavMissions")]
        public async Task<IActionResult> upsertFavMissions([FromBody]int MissionId)
        {
            return Ok(await _volunteer.UpsertFavoriteMissions(User.Identity.Name, MissionId));
        }

        [HttpDelete]
        [Route("removeFavMissions")]
        public async Task<IActionResult> removeFavMissions(int missionId)
        {
            return Ok(await _volunteer.RemoveFavoriteMissions(User.Identity.Name, missionId));
        }

        [HttpPost]
        [Route("missionRating")]
        public async Task<IActionResult> missionRating([FromBody] MissionRatingModel rating)
        {
            //int missionId = rating[0].missionId
            return Ok(await _volunteer.MissionRating(User.Identity.Name, rating.MissionId, rating.Rate));
        }

        [HttpPost]
        [Route("missionVolunteering")]
        public async Task<IActionResult> missionVolunteering([FromBody]int missionId)
        {
            return Ok(await _volunteer.UpsertMissionVolunteer(missionId, User.Identity.Name));
        }

        [HttpPost]
        [Route("upsertVolunteerTime")]
        public async Task<IActionResult> upsertVolunteerTime([FromBody]VolunteerTimeModel volunteerTime, int? timeId)
        {
            return Ok(await _volunteer.UpsertVolunteerTime(volunteerTime, User.Identity.Name, timeId));
        }

        [HttpPost]
        [Route("upsertVolunteerGoal")]
        public async Task<IActionResult> upsertVolunteerGoal([FromBody]VolunteerGoalModel volunteerGoal, int? goalId)
        {
            return Ok(await _volunteer.UpsertVolunteerGoal(volunteerGoal, User.Identity.Name, goalId));
        }
    }
}
