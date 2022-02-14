using AkatoshProgrammingInterface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AkatoshProgrammingInterface.WebAPI.Controllers
{
    [Authorize]
    public class GodController : ApiController
    {
        private GodService CreateGodService()
        {
            var godService = new GodService(/*godID?*/);
            return godService;
        }
    }
}
