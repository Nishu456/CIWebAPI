using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Models
{
    public class MissionRequestModel
    {
        [Key]
        public int MissionId { get; set; }

        [Required]
        public string MissionTitle { get; set; }

        [Required]
        public string MissionDescription { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        [Required]
        public string OrganizationDetail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string TotalSeats { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistrationDeadline { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int ThemeId { get; set; }

        [Required]
        public string[] Skills { get; set; }

        [Required]
        public string Images { get; set; }

        [Required]
        public string Documents { get; set; }

        [Required]
        public string Availability { get; set; }

        [Required]
        public string MissionType { get; set; }
    }
}
