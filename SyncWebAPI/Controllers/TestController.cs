﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace YsWebAPI.Controllers
{
    [Route("Test")]
   
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Yishion()
        {
           // JsonResult re = new JsonResult();

            return "Yishion" ;
        }
    }
}