using Microsoft.EntityFrameworkCore;
using PatikaDev.Entity;

namespace PatikaDev.Context
{
    public class PatikaDevDbContext : DbContext
    {
        public PatikaDevDbContext(DbContextOptions<PatikaDevDbContext> options): base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<AttendenceStatus> AttendenceStatuses { get; set; }
        public DbSet<AchievementStatus> AchievementStatuses { get; set; }
    }
}
