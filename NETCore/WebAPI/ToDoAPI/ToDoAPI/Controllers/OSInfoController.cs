using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    public class OSInfoController : Controller
    {
        // GET api/osinfo
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(System.Runtime.InteropServices.RuntimeInformation.OSDescription);
        }

    }
}
    