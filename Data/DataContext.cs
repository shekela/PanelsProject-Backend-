using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Entities;
using PanelsProject_BackRud.Rutities;

namespace PanelsProject_Backend.Data
{
    public class DataContext : DbContext
    {
        public DbSet<MarketingBanner> MarketingBanners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MainProductSection> MainProductSections { get; set; }
        public DbSet<VideoCatalog> VideoCatalog { get; set; }
        public DbSet<ProductsSliderCatalog> ProductsSliderCatalog { get; set; }
        public DbSet<VoiceComperator> VoiceComperator { get; set; }
        public DbSet<ColorAndCovers> ColorAndCovers { get; set; }
        public DbSet<GalleryPictures> GalleryPictures { get; set; }
        public DbSet<InformationBanner> InformationBanners { get; set; }
        public DbSet<GallerySectionTexts> GallerySectionTexts { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Admin> Admins { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique index definitions
            modelBuilder.Entity<MainProductSection>()
                .HasIndex(m => new { m.TitleEn, m.TitleTextEn, m.TitleKa, m.TitleTextKa, m.TitleRu, m.TitleTextRu })
                .IsUnique();

            modelBuilder.Entity<MarketingBanner>()
                .HasIndex(m => new { m.TitleEn, m.DescriptionEn, m.AimEn, m.TitleKa, m.DescriptionKa, m.AimKa, m.TitleRu, m.DescriptionRu, m.AimRu })
                .IsUnique();

            modelBuilder.Entity<VideoCatalog>()
                .HasIndex(m => new { m.TitleEn, m.DescriptionEn, m.ButtonTextEn,  m.TitleKa, m.DescriptionKa, m.ButtonTextKa, m.TitleRu, m.DescriptionRu, m.ButtonTextRu })
                .IsUnique();
        }

    }
}