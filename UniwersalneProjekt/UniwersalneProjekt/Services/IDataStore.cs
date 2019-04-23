using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;

namespace UniwersalneProjekt.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddCategoryAsync(T category);
        Task<bool> UpdateCategoryAsync(T category);
        Task<bool> DeleteCategoryAsync(string id);
        Task<T> GetCategoryAsync(string id);
        Task<IEnumerable<T>> GetCategoriesAsync(bool forceRefresh = false);
        Task<IEnumerable<Question>> GetQuestionsAsync(bool forceRefresh = false, Category category = null);
        Task<Question> GetQuestionAsync(string id, Category category);
        Task<IEnumerable<Answer>> GetAnswersAsync(bool forceRefresh = false, Question question = null);
        Task<Answer> GetAnswerAsync(string id,Question question);
    }
}
