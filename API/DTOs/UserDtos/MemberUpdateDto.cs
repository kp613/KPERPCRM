﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.UserDtos
{
    public class MemberUpdateDto
    {
        public string Introduction { get; set; }              

        public string Interests { get; set; }

        public string LookingFor { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string ProfilePicture { get; set; }
    }
}
