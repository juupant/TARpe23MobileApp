using Constants;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Services
{
    public class CategoryService : BaseApiService
    {
        public CategoryService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        private IEnumerable<Category>? _categories;

        public async ValueTask<IEnumerable<Category>> GetCategoriesAsync()
        {
            if (_categories is null)
            {
                var response = await HttpClient.GetAsync("/masters/categories");
                var categories = await HandleApiResponseAsync<IEnumerable<Category>>(response, null);

                if (categories is null)
                    return Enumerable.Empty<Category>();

                _categories = categories;
            }
            return _categories;
        }
        public async Task<IEnumerable<Category>> GetSubCategories(short subCategoryId)
        {
            var allCategories = await GetCategoriesAsync();
            var currentCategory = allCategories.First(c => c.Id == subCategoryId);
            var mainCategoryId = currentCategory.IsMainCategory ? subCategoryId : currentCategory.ParentId;
            return allCategories.Where(c => c.ParentId == mainCategoryId).ToList();
        }
        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() =>
            (await GetCategoriesAsync()).Where(c => c.ParentId == 0);
    }
}