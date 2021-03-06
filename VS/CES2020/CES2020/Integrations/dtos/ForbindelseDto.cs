﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CES2020.Models;
using CES2020.Models.Enums;

namespace CES2020.Integrs.dto
{
    public class ForbindelseDto
    {
        public String To { get; set; }
        public String From { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public Enums.Forbindelsestype Type { get; set; }
    }
}