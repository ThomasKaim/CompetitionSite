using LightNap.Core.Competitions.Dto.Response;
using LightNap.Core.Competitions.Entities;
using LightNap.Core.Data.Converters;
using LightNap.Core.Data.Entities;
using LightNap.Core.Profile.Dto.Response;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LightNap.Core.Data
{
    /// <summary>
    /// Represents the application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Competition> Competitions { get; set; } = null!;
        /// <summary>
        /// Notifications in the DB.
        /// </summary>
        public DbSet<Notification> Notifications { get; set; } = null!;

        /// <summary>
        /// Refresh tokens in the DB.
        /// </summary>
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The DbContext options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext() { }

        ///// <inheritdoc />
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseLazyLoadingProxies();
        //    }
        //}

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Notification>()
                .Property(n => n.Data)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
                        v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, null as JsonSerializerOptions) ?? new Dictionary<string, object>()
                    );

            builder.Entity<Notification>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(rt => rt.UserId)
                .IsRequired();

            builder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .IsRequired();
        }

        /// <inheritdoc />
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Make sure all DateTime properties are stored as UTC.
            configurationBuilder.Properties<DateTime>().HaveConversion<UtcValueConverter>();

            // Storing this as a JSON string.
            configurationBuilder.Properties<BrowserSettingsDto>().HaveConversion<BrowserSettingsValueConverter>();
        }
    }
}
