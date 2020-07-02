﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BIED_research_suite.Controllers
{
    [Authorize(Roles = "Onderzoeker")]
    public class OnderzoekerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}