using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyLibrary.DBContext;

namespace MyLibrary.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookStatus> BookStatuses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CoverType> CoverTypies { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Edition> Editions { get; set; }
        public virtual DbSet<FileExtension> FileExtensions { get; set; }
        public virtual DbSet<ISBN> ISBNs { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageList> LanguageLists { get; set; }
        public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}