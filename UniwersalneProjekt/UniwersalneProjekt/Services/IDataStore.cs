using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniwersalneProjekt.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddCategoryAsync(T category);
        Task<bool> UpdateCategoryAsync(T category);
        Task<bool> DeleteCategoryAsync(string id);
        Task<T> GetCategoryAsync(string id);
        Task<IEnumerable<T>> GetCategoriesAsync(bool forceRefresh = false);
    }
}
