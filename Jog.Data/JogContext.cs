using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Jog.Data
{
    public interface IJogContext
    {
        DbSet<Workout> Workouts { get; set; }
        int SaveChanges();
    }

    public class JogContext : DbContext, IJogContext
    {
        public JogContext()
            : base("name=JogContext")
        {
        }

        public virtual DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class JogInitializer : DropCreateDatabaseIfModelChanges<JogContext>
    {
        protected override void Seed(JogContext context)
        {
            var workoutsList = new List<Workout>
            {
                new Workout
                {
                    UserName = "tester",
                    Date = DateTime.Today,
                    Duration = 120,
                                        Distance = 2500,

                },
                new Workout
                {
                    UserName = "tester",
                    Date = DateTime.Today.AddDays(-1),
                    Duration = 300,
                                        Distance = 1000,

                },
                new Workout
                {
                    UserName = "tester",
                    Date = DateTime.Today.AddDays(-3),
                    Duration = 210,
                    Distance = 1500,
                }
            };
            workoutsList.ForEach(c => context.Workouts.Add(c));
            context.SaveChanges();
        }
    }
}