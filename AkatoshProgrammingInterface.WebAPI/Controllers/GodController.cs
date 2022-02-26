using AkatoshProgrammingInterface.Models.GodModels;
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
        [HttpGet]
        public IHttpActionResult Get()
        {
            GodService godService = new GodService();
            var gods = godService.GetGods();
            return Ok(gods);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            GodService godService = new GodService();
            var god = godService.GetGodByID(id);
            return Ok(god);
        }

        [HttpPost]
        public IHttpActionResult Post(GodCreate god)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new GodService();

            if (!service.CreateGod(god))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = new GodService();

            if (!service.DeleteGod(id))
                return InternalServerError();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(GodEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new GodService();

            if (!service.UpdateGod(model))
                return InternalServerError();

            return Ok();
        }
    }
}
