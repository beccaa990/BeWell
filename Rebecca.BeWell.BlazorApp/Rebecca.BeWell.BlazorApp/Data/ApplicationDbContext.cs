using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rebecca.BeWell.BlazorApp.Data.Models;

namespace Rebecca.BeWell.BlazorApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<Activity> Activities { get; set; }

        public virtual DbSet<ActivityType>ActivityTypes { get; set; }

        public virtual DbSet<Intensity> Intensities { get; set; }

        public virtual DbSet<Sleep> Sleeps { get; set; }

        public virtual DbSet<Nutrition> Nutritions { get; set;}

        public virtual DbSet<NutritionType> NutritionTypes { get; set;}

    }
}
