using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                new Category { Id = Guid.NewGuid().ToString(), Name = "Quiz One", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Quiz Two", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Quiz Three", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Quiz Four", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Quiz Five", Questions=new List<Question>() },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Quiz Six", Questions=new List<Question>() },
            };
            foreach (var category in mockCategories)
            {
                categories.Add(category);
            }
            foreach (var category in categories)
            {
                var mockQuestions = new List<Question> {
                new Question { Id = Guid.NewGuid().ToString(), QuestionText = "Test Question One", Answers = new List<Answer>() },
                new Question { Id = Guid.NewGuid().ToString(), QuestionText = "Test Question Two", Answers = new List<Answer>() },
                new Question { Id = Guid.NewGuid().ToString(), QuestionText = "Test Question Three", Answers = new List<Answer>() },
                new Question { Id = Guid.NewGuid().ToString(), QuestionText = "Test Question Four", Answers = new List<Answer>() },
            };
                category.Questions = mockQuestions;
            }
            foreach(var category in categories)
            {
                foreach(var question in category.Questions)
                {
                    var MockAnswers = new List<Answer>
                    {
                        new Answer { Id=Guid.NewGuid().ToString(),AnswerText="Answer One",IsCorrect=true},
                        new Answer { Id=Guid.NewGuid().ToString(),AnswerText="Answer Two"},
                        new Answer { Id=Guid.NewGuid().ToString(),AnswerText="Answer Three"},
                        new Answer { Id=Guid.NewGuid().ToString(),AnswerText="Answer Four"}
                    };
                    question.Answers = MockAnswers;
                }
            }
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            categories.Add(category);
            foreach(var categoryy in categories)
            {
                Debug.WriteLine(categoryy.Name);
            }
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
        public async Task<IEnumerable<Question>> GetQuestionsAsync (bool forceRefresh = false, Category category = null)
        {
            return await Task.FromResult(category.Questions);
        }
        public async Task<IEnumerable<Answer>> GetAnswersAsync(bool forceRefresh = false, Question question = null)
        {
            return await Task.FromResult(question.Answers);
        }
        public async Task<Question> GetQuestionAsync(string id, Category category)
        {
            return await Task.FromResult(category.Questions.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Answer> GetAnswerAsync(string id, Question question)
        {
            return await Task.FromResult(question.Answers.FirstOrDefault(s => s.Id == id));
        }
    }
}