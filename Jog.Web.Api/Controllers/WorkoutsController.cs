using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Jog.Data;
using Jog.Data.Abstract;
using Jog.Web.Api.Infrastructure;
using Jog.Web.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jog.Web.Api.Controllers
{
    [RoutePrefix("workouts")]
    [Authorize]
    [ValidationActionFilter]
    public class WorkoutsController : ApiController
    {
        private readonly IJogRepo _repo;

        public WorkoutsController(IJogRepo repo)
        {
            _repo = repo;
        }

        [Route("", Name = "AddWorkoutRoute")]
        [HttpPost]
        public object AddWorkout(Workout workout)
        {
            var newWorkout = _repo.AddWorkout(workout);
            return newWorkout;
        }

        [Route("")]
        [HttpGet]
        public object GetWorkouts(HttpRequestMessage requestMessage)
        {
            return _repo.Workouts.ToArray();
        }

        [Route("{id:long}")]
        [HttpPut]
        [HttpPatch]
        public object UpdateWorkout(long id, [FromBody]Workout workout)
        {
            var updatedWorkout = _repo.UpdateWorkout(id, workout);
            return updatedWorkout;
        }

        [Route("{workoutId:long}")]
        [HttpDelete]
        public object DeleteWorkout(long workoutId)
        {
            _repo.DeleteWorkout(workoutId);
            return Ok();
        }
    }
}