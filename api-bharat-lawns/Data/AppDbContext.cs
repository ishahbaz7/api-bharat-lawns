using System;
using api_bharat_lawns.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api_bharat_lawns.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FunctionType> FunctionTypes { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<BookedProgram> BookedPrograms { get; set; }
        public DbSet<BookedFeature> BookedFeatures { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PaymentReceipt> PaymentReceipts { get; set; }


        // Roles seeding
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }
        private readonly string superUserId = "ef20c48e-3b60-44d7-bc9f-3b5973679bfb";
        private readonly string superUserRoleId = "69365cb4-4e73-451c-afa0-ab4052246ab3";
        private readonly string guestRoleId = "09ecccf8-35d3-431d-bdf2-0d491f3aa87c";

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = superUserRoleId,
                    Name = "super_user",
                    NormalizedName = "SUPERS_USER",
                    ConcurrencyStamp = "ab4052246ab3"
                },
                new IdentityRole
                {
                    Id = guestRoleId,
                    Name = "guest",
                    NormalizedName = "GUEST",
                    ConcurrencyStamp = "0d491f3aa87c"
                }
            );
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = superUserId,
                    UserName = "super_user",
                    NormalizedUserName = "SUPER_USER",
                    Name = "Super User",
                    PasswordHash = hasher.HashPassword(null, "Ids@1234")
                });
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            var userRoles = new List<IdentityUserRole<string>>()
            {
                //super user roles
                new IdentityUserRole<string>() { RoleId = superUserRoleId, UserId = superUserId },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}

