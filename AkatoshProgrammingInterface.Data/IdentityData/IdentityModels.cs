using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

using System.Security.Claims;
using System.Threading.Tasks;
using AkatoshProgrammingInterface.Data.RaceData;
using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity;
using AkatoshProgrammingInterface.Data.GodData;
using AkatoshProgrammingInterface.Data.PantheonData;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AkatoshProgrammingInterface.Data.IdentityData
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Insert DbContext Here 
        public DbSet<Race> Race { get; set; }
        public DbSet<Province> Provinces {  get; set; }
        public DbSet<Pantheon> Pantheons { get; set; }
        public DbSet<God> Gods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}