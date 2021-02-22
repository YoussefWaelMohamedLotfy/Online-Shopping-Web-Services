using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using Online_Shopping_Service.Models.Store;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Online_Shopping_Service.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Messages = new HashSet<Message>();
        }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Area { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

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
        public DbSet<OrderCart> OrderCarts { get; set; }
        public DbSet<Message> Messages { get; set; }

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
            modelBuilder.Entity<Card>()
                .HasKey(c => c.CardNumber);

            modelBuilder.Entity<OrderCart>()
                .HasKey(c => c.CartID);

            modelBuilder.Entity<CartItem>()
                .HasRequired(c => c.Item)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.ItemID);
            
            modelBuilder.Entity<OrderCart>()
                .HasMany(c => c.CartItems)
                .WithRequired(c => c.OrderCart)
                .HasForeignKey(c => c.CartID);

            modelBuilder.Entity<Message>()
                .HasRequired(c => c.User)
                .WithMany(c => c.Messages)
                .HasForeignKey(c => c.UserID);

            base.OnModelCreating(modelBuilder);
        }
    }
}