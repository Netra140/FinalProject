using AkatoshProgrammingInterface.Models.RaceModels;
using AkatoshProgrammingInterface.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AkatoshProgrammingInterface.WebAPI.Controllers
{
    [Authorize]
    public class RaceController : ApiController
    {
        private RaceService CreateRaceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new RaceService(userId);
            return noteService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            RaceService raceService = CreateRaceService();
            var races = raceService.GetRaces();
            return Ok(races);
        }

        [HttpPost]
        public IHttpActionResult Post(RaceCreate race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateRaceService();
            if (!service.CreateRace(race))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            RaceService noteService = CreateRaceService();
            var note = noteService.GetRaceById(id);
            return Ok(note);
        }

        [HttpPut]
        public IHttpActionResult Put(RaceEdit race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateRaceService();

            if (!service.UpdateRace(race))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int ID)
        {
            var service = CreateRaceService();

            if (!service.DeleteRace(ID))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}

