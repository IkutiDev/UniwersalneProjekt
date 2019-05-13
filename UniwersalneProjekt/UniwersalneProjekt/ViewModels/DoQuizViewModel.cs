using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;
using UniwersalneProjekt.Services;
using Xamarin.Forms;
namespace UniwersalneProjekt.ViewModels
{
    public class DoQuizViewModel : BaseViewModel
    {
        public ObservableCollection<Question> Questions { get; set; }
        public Category Category { get; set; }
        public Command LoadQuestionsCommand { get; set; }
        public DoQuizViewModel(Category category)
        {
            Title = category?.Name;
            Category = category;
            Questions = new ObservableCollection<Question>();
            if (category.Questions != null)
            {
                foreach (Question q in category.Questions)
                {
                    Questions.Add(q);
                }
            }
            LoadQuestionsCommand = new Command(() => ExecuteLoadQuestionsCommand());
        }
        void ExecuteLoadQuestionsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Questions.Clear();
                var questions = Category.Questions;
                foreach (var question in questions)
                {
                    Questions.Add(question);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
