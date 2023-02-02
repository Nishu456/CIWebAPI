﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Models
{
    public class UserVM
    {
        public UserRequestModel UserRequest { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CityList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
}
