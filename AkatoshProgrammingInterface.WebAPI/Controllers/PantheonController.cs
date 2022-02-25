using AkatoshProgrammingInterface.Models.PantheonModels;
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
    public class PantheonController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            PantheonService pantheonService = new PantheonService();
            var pantheons = pantheonService.GetPantheons();
            return Ok(pantheons);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            PantheonService pantheonService = new PantheonService();
            var pantheon = pantheonService.GetPantheonByID(id);
            return Ok(pantheon);
        }

        [HttpPost]
        public IHttpActionResult Post(PantheonCreate pantheon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new PantheonService();

            if (!service.CreatePantheon(pantheon))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = new PantheonService();

            if (!service.DeletePantheon(id))
                return InternalServerError();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(PantheonEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new PantheonService();

            if (!service.UpdatePantheon(model))
                return InternalServerError();

            return Ok();
        }
    }
}
