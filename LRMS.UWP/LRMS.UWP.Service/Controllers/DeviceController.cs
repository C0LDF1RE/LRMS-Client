using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRMS.UWP.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DeviceController: ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await Task.Delay(3000);
            return new JsonResult("OK");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(3000);
            return new JsonResult("OK");
        }
    }
}
