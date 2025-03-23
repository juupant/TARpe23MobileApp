using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Constants;
using Models;
using System.Text.Json;
namespace Services
{
    public class CategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private IEnumerable<Category>? _categories;
        private readonly IHttpClientFactory _httpClientFactory;
        public async ValueTask<IEnumerable<Category>> GetCategories()
        {
            if (_categories is null)
            {
                var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
                var resp = await httpClient.GetAsync("/masters/categories");
                if (resp.IsSuccessStatusCode)
                {
                    var content = await resp.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        _categories = JsonSerializer.Deserialize<IEnumerable<Category>>(content, new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    }
                }
                else
                {
                    return Enumerable.Empty<Category>();
                }
                //var categories = new List<Category>();

                //var fruits = new List<Category>
                //{
                //    new (1, "Fruits", 0, "fruits.jpg", ""),
                //    new (2, "Seasonal Fruits", 1, "seasonal_fruits.png", ""),
                //    new (3, "Exotic Fruits", 1, "exotic_fruits.png", "")
                //};
                //categories.AddRange(fruits);

                //var vegetables = new List<Category>
                //{
                //    new (4, "Vegetables", 0, "vegetables.jpg", ""),
                //    new (5, "Green Vegetables", 4, "green_vegetables.png", ""),
                //    new (6, "Leafy Vegetables", 4, "leafy_vegetables.png", ""),
                //    new (7, "Salads", 4, "salads.png", ""),
                //};
                //categories.AddRange(vegetables);

                //var dairy = new List<Category>
                //{
                //    new (8, "Dairy", 0, "dairy.jpg", ""),
                //    new (9, "Milk, Curd & Yogurts", 8, "milk_curd_yogurt.png", ""),
                //    new (10, "Butter & Cheese", 8, "butter_cheese.png", ""),
                //};
                //categories.AddRange(dairy);

                //var eggsMeat = new List<Category>
                //{
                //    new (11, "Eggs & Meat", 0, "eggs_meat.jpg", ""),
                //    new (12, "Eggs", 11, "eggs.png", ""),
                //    new (13, "Meat", 11, "meat.png", ""),
                //    new (14, "Seafood", 11, "seafood.png", ""),
                //};
                //categories.AddRange(eggsMeat);
                //_categories = categories;
            }
            return _categories;
        }
        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() =>
            (await GetCategories()).Where(c => c.ParentId == 0);
    }
}