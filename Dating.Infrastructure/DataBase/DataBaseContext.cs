using Dating.Domain.Interfaces;
using Dating.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dating.Infrastructure.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
                    : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<EyesColor> EyesColors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HairColor> HairColors { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<SexOrientation> SexOrientations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserImage> Images { get; set; }
        public DbSet<ZodiacSign> ZodiacSigns { get;set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies(true);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureSoftDeleteFilter(modelBuilder);

            //modelBuilder.Entity<ISoftDeletable>().HasQueryFilter(m => m.DeletedAt == null);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tags)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "UserTag",
                j => j
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.PartnerCities)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "UserPartnerCity",
                j => j
                    .HasOne<City>()
                    .WithMany()
                    .HasForeignKey("PartnerCityId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.PartnerEyesColors)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "UserPartnerEyesColor",
                j => j
                    .HasOne<EyesColor>()
                    .WithMany()
                    .HasForeignKey("PartnerEyesColorId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.PartnerHairColors)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "UserPartnerHairColor",
                j => j
                    .HasOne<HairColor>()
                    .WithMany()
                    .HasForeignKey("PartnerHairColorId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.PartnerZodiacSigns)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "UserPartnerZodiacSign",
                j => j
                    .HasOne<ZodiacSign>()
                    .WithMany()
                    .HasForeignKey("PartnerZodiacSignId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Languages)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "UserLanguage",
                j => j
                    .HasOne<Language>()
                    .WithMany()
                    .HasForeignKey("LanguageId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserImages)
                .WithOne(i => i.User);

            modelBuilder.Entity<User>()
                .HasMany(u => u.AsInitiatorRelationships)
                .WithOne(r => r.FirstUser);

            modelBuilder.Entity<User>()
                .HasMany(u => u.AsResponderRelationships)
                .WithOne(r => r.SecondUser);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.TelegramId)
                .IsUnique();

            var genders = new string[] { "Male", "Female" };
            modelBuilder.Entity<Gender>().HasData(genders.Select((el, index) => new Gender { Id = index + 1, Name = el }));

            var sexOrientations = new string[] { "Heterosexual", "Homosexual", "Bisexual" };
            modelBuilder.Entity<SexOrientation>().HasData(sexOrientations.Select((el, index) => new SexOrientation { Id = index + 1, Name = el }));

            var zodiavSigns = new string[] 
            {
                "Aquarius",
                "Pisces",
                "Aries",
                "Taurus",
                "Gemini",
                "Cancer",
                "Leo",
                "Virgo",
                "Libra",
                "Scorpio",
                "Sagittarius",
                "Capricorn"
            };
            modelBuilder.Entity<ZodiacSign>().HasData(zodiavSigns.Select((el, index) => new ZodiacSign { Id = index + 1, Name = el }));

            var eyesColors = new string[]
            {
                "Brown",
                "Blue",
                "Green",
                "Grey",
                "Another"
            };
            modelBuilder.Entity<EyesColor>().HasData(eyesColors.Select((el, index) => new EyesColor { Id = index + 1, Name = el }));

            var hairColors = new string[]
            {
                "Brunette",
                "BrownHaired",
                "Blond",
                "Redhead",
                "Another"
            };
            modelBuilder.Entity<HairColor>().HasData(hairColors.Select((el, index) => new HairColor { Id = index + 1, Name = el }));

            var languages = new string[]
            {
                "Russian",
                "English",
            };
            modelBuilder.Entity<Language>().HasData(languages.Select((el, index) => new Language { Id = index + 1, Name = el }));

            var tags = new string[]
            {
                "Sport",
                "Movie",
                "Serials",
                "Politics"
            };
            modelBuilder.Entity<Tag>().HasData(tags.Select((el, index) => new Tag { Id = index + 1, Name = el }));

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDeletable>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow.Date;
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDeletable>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow.Date;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private void ConfigureSoftDeleteFilter(ModelBuilder builder)
        {
            /*foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType).HasQueryFilter((dynamic e) => !e.IsDeleted);
                }
            }*/
            foreach (var softDeletableTypeBuilder in builder.Model.GetEntityTypes()
                .Where(x => typeof(ISoftDeletable).IsAssignableFrom(x.ClrType)))
            {
                var parameter = Expression.Parameter(softDeletableTypeBuilder.ClrType, "p");

                softDeletableTypeBuilder.SetQueryFilter(
                    Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(parameter, nameof(ISoftDeletable.DeletedAt)),
                            Expression.Constant(null)),
                        parameter)
                );
            }
        }

    }
}
