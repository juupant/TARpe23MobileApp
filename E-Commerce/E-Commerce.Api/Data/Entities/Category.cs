using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Api.Data.Entities
{
    [Table(nameof(Category))]
    public class Category
    {
        [Key]
        public short Id { get; set; }
        [Required,MaxLength(20)]
        public string Name { get; set; }
        [Required,MaxLength(150)]
        public string Image { get; set; }
        public short ParentId { get; set; }
        [MaxLength(150)]
        public string? Credit { get; set; }

        public Category(short id, string name, short parentId, string image, string credit) : this()
        {
            Id = id;
            Name = name;
            Image = image;
            ParentId = parentId;
            Credit = credit;
        }

        public Category()
        {
        }

        public static IEnumerable<Category> GetInitialData()
        {
            var categories = new List<Category>();

            var fruits = new List<Category>
            {
                new (1, "Fruits", 0, "fruits.jpg", ""),
                new (2, "Seasonal Fruits", 1, "seasonal_fruits.png", ""),
                new (3, "Exotic Fruits", 1, "exotic_fruits.png", "")
            };
            categories.AddRange(fruits);

            var vegetables = new List<Category>
            {
                new (4, "Vegetables", 0, "vegetables.jpg", ""),
                new (5, "Green Vegetables", 4, "green_vegetables.png", ""),
                new (6, "Leafy Vegetables", 4, "leafy_vegetables.png", ""),
                new (7, "Salads", 4, "salads.png", "")
            };
            categories.AddRange(vegetables);

            var dairy = new List<Category>
            {
                new (8, "Dairy", 0, "dairy.jpg", ""),
                new (9, "Milk, Curd & Yogurts", 8, "milk_curd_yogurt.png", ""),
                new (10, "Butter & Cheese", 8, "butter_cheese.png", "")
            };
            categories.AddRange(dairy);

            var eggsMeat = new List<Category>
            {
                new (11, "Eggs & Meat", 0, "eggs_meat.jpg", ""),
                new (12, "Eggs", 11, "eggs.png", ""),
                new (13, "Meat", 11, "meat.png", ""),
                new (14, "Seafood", 11, "seafood.png", "")
            };
            categories.AddRange(eggsMeat);
            return categories;
        }
    }
}
