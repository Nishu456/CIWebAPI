using CI.Data.Repository.Interface;
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
        public async Task<IActionResult> volunteerMission(int pageIndex, int pageSize, string? filterValues)
        {
            return Ok(await _volunteer.MissionList(pageIndex, pageSize, filterValues));
        }
    }
}
