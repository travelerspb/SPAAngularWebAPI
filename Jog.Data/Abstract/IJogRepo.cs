using System;
using System.Collections.Generic;

namespace Jog.Data.Abstract
{
    public interface IJogRepo
    {
        Workout AddWorkout(Workout workout);
        Workout UpdateWorkout(long id, Workout workout);
        void DeleteWorkout(long workoutId);

        IEnumerable<Workout> Workouts { get; }
    }
}
