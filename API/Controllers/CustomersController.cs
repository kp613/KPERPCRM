using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{  
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiVersion("2.0")]
    public class CustomersController : ControllerBase
    {

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
