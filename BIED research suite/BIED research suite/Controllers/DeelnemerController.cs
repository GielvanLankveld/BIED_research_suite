﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BIED_research_suite.Controllers
{
    [Authorize(Roles = "Deelnemer")]
    public class DeelnemerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
