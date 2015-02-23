using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using Jog.Common;
using Jog.Common.Security;
using Jog.Data.Abstract;

namespace Jog.Data.Concrete
{
    public class JogRepo : IJogRepo
    {
        private readonly IDateTimeProvider _dateTime;
        private readonly IUserSession _userSession;
        private readonly IJogContext _context;

        public JogRepo(IDateTimeProvider dateTime, IUserSession userSession, IJogContext context)
        {
            _dateTime = dateTime;
            _userSession = userSession;
            _context = context;
        }

        public Workout AddWorkout(Workout workout)
        {
            workout.UserName = _userSession.Username;
            workout.Date = workout.Date.ToUniversalTime();
            var newWorkout = _context.Workouts.Add(workout);
            _context.SaveChanges();
            return newWorkout;
        }

        public Workout UpdateWorkout(long id, Workout workout)
        {
            var entityInDb = _context.Workouts.SingleOrDefault(x => x.Id == id);
            if (entityInDb == null) 
                throw new ObjectNotFoundException("Cant find workout in DB: " + workout);

            entityInDb.Date = workout.Date;
            entityInDb.Distance = workout.Distance;
            entityInDb.Duration = workout.Duration;
            _context.SaveChanges();
            return entityInDb;
        }

        public void DeleteWorkout(long workoutId)
        {
            var entityIdDb = _context.Workouts.SingleOrDefault(x => x.Id == workoutId);
            if (entityIdDb == null)
                return;
            _context.Workouts.Remove(entityIdDb);
            _context.SaveChanges();
        }

        public IEnumerable<Workout> Workouts
        {
            get { return _context.Workouts.Where(x=>x.UserName == _userSession.Username); }
        }
    }
}
