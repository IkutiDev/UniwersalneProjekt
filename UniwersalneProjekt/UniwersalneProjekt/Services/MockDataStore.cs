using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;

namespace UniwersalneProjekt.Services
{
    public class MockDataStore : IDataStore<Category>
    {
        List<Category> categories;

        public MockDataStore()
        {
            categories = new List<Category>();
            var mockCategories = new List<Category>
            {
                new Category { Id = Guid.NewGuid().ToString(), Name = "First item", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Second item", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Third item", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Questions=new List<Question>() },
            };

            foreach (var category in mockCategories)
            {
                categories.Add(category);
            }
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var oldCategory = categories.Where((Category arg) => arg.Id == category.Id).FirstOrDefault();
            categories.Remove(oldCategory);
            categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCategoryAsync(string id)
        {
            var oldCategory = categories.Where((Category arg) => arg.Id == id).FirstOrDefault();
            categories.Remove(oldCategory);

            return await Task.FromResult(true);
        }

        public async Task<Category> GetCategoryAsync(string id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categories);
        }
    }
}