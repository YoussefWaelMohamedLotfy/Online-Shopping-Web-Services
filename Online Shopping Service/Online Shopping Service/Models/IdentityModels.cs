using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
        // Add all tables here
        public DbSet<Card> Cards { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderCart> OrderCart { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasKey(c => c.CardNumber);

            // One to One
            modelBuilder.Entity<Item>()
                .HasRequired(c => c.CartItem)
                .WithRequiredPrincipal(c => c.Item);

            modelBuilder.Entity<CartItem>()
                .HasRequired(c => c.Item)
                .WithRequiredDependent(c => c.CartItem);

            // One to many
            modelBuilder.Entity<OrderCart>()
                .HasMany(c => c.Items)
                .WithRequired(c => c.Cart)
                .HasForeignKey(c => c.ItemID);

            base.OnModelCreating(modelBuilder);
        }
    }
}