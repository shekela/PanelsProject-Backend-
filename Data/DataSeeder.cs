using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.Entities;

namespace PanelsProject_Backend
{
    public static class DataSeeder
    {
        public static void SeedProductsSliderCatalog(DataContext context)
        {
            // Check if the table is already populated
            if (context.ProductsSliderCatalog.Any())
            {
                return; // Skip seeding if data already exists
            }

            // Load JSON data
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "seedData.json");
            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException($"Seed data file not found at {jsonFilePath}");
            }

            var jsonData = File.ReadAllText(jsonFilePath);
            var sliderCatalogs = JsonSerializer.Deserialize<List<ProductsSliderCatalog>>(jsonData);

            if (sliderCatalogs != null)
            {
                // Add data to the DbContext
                context.ProductsSliderCatalog.AddRange(sliderCatalogs);
                context.SaveChanges();
            }
        }
    }
}
