using BbCenter.Constraints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


namespace BbCenter.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
                if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(u => u.StudentSeleced)
            .WithOne(u => u.Student)
            .HasForeignKey(u => u.StudentId)
            .HasPrincipalKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasMany(u => u.TeacherSelected)
            .WithOne(u => u.Teacher)
            .HasForeignKey(u => u.TeacherId)
            .HasPrincipalKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Subject)
            .WithMany(su => su!.Schedules)
            .HasForeignKey(s => s.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);



            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = new Guid("FAB0F92F-5342-4AD9-B704-298A9AACC21E"), Name = ERole.Administrator.ToString() },
                new Role { RoleId = new Guid("F8CDE125-1E72-4A26-B79F-709F671B290A"), Name = ERole.CenterManager.ToString() },
                new Role { RoleId = new Guid("3C907E92-1D0F-4BE3-A107-6581ADFF92B5"), Name = ERole.Teacher.ToString() },
                new Role { RoleId = new Guid("1FE4938D-D479-482B-AF22-C79EE4FFD447"), Name = ERole.Student.ToString() }
            );

            string adminPassword = "12345678";
            PasswordHasher<string> passwordHasher = new();
            string password = passwordHasher.HashPassword(null, adminPassword);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = new Guid("0c67b9de-ebd3-42d9-81ea-8242c8ae19aa"),
                    Email = "admin@gmail.com",
                    Password = password,
                    FirstName = "Admin",
                    LastName = "Admin",
                    DateOfBirth = new DateTime(2002, 8, 5),
                    Address = "Admin Address",
                    PhoneNumber = "1234567890",
                    Degree = "Admin",
                    RoleId = new Guid("FAB0F92F-5342-4AD9-B704-298A9AACC21E")
                }
            );
        }
    }
}
