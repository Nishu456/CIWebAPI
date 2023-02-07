using CI.BusinessLogic.Repository.Interface;
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
    }
}
