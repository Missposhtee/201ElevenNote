using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ElevenNote.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ElevenNoteUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ElevenNoteUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ElevenNoteDBContext : IdentityDbContext<ElevenNoteUser>
    {
        //line 26 and 27 are our constructor,27 connection strings telling us how to connect to the data base
        public ElevenNoteDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ElevenNoteDBContext Create()
        {
            return new ElevenNoteDBContext();
        }

        //newly added from daves slack(2) overide of the onModelCreating context;makes sure tables are created in singular formed and mathches

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                    .Add(new IdentityUserLoginConfiguration())
                    .Add(new IdentityUserRoleConfiguration());
        }

    }
    //newly added from daves slack(1) two class defination 
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
            HasKey(iur => iur.RoleId);
        }
    }
}