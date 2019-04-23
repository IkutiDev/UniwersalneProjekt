using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;
using Xamarin.Forms;

namespace UniwersalneProjekt.ViewModels
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Question> Questions { get; set; }
        public Category Category { get; set; }
        public Command LoadQuestionsCommand { get; set; }
        public CategoryDetailViewModel(Category category = null)
        {
            Title = category?.Name;
            Category = category;
            Questions = new ObservableCollection<Question>();
            LoadQuestionsCommand = new Command(async () => await ExecuteLoadQuestionsCommand());
        }
        async Task ExecuteLoadQuestionsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Questions.Clear();
                var questions = await DataStore.GetQuestionsAsync(true,Category);
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
