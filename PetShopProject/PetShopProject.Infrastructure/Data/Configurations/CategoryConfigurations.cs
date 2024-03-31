using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopProject.Infrastructure.Data.Models;

namespace PetShopProject.Infrastructure.Data.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        // Configure category entity
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategoriesToDb());
        }

        // Seed categories
        private List<Category> SeedCategoriesToDb()
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Суха храна",
                    Description = "Висококачествена суха храна за кучета от различни породи и възрасти.",
                    AnimalType = "Куче",
                },
                new Category
                {
                    Id = 2,
                    Name = "Консервирана храна",
                    Description = "Висококачествена консервирана храна за кучета, богата на месо и протеини.",
                    AnimalType = "Куче",
                },
                new Category
                {
                    Id = 3,
                    Name = "Лакомства за награда",
                    Description = "Вкусни и здравословни лакомства за награждаване и обучение на кучета.",
                    AnimalType = "Куче",
                },
                new Category
                {
                    Id = 4,
                    Name = "Хранителни добавки и витамини",
                    Description = "Висококачествени хранителни добавки и витамини за подобряване на здравето на кучетата.",
                    AnimalType = "Куче",
                },
                new Category
                {
                    Id = 5,
                    Name = "Аксесоари",
                    Description = "Разнообразни аксесоари за кучета, включително играчки, легла, нашийници и каишки.",
                    AnimalType = "Куче",
                }
            };

            return categories;
        }
    }
}
