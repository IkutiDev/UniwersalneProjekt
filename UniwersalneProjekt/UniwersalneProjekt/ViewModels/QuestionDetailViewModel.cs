using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;
using Xamarin.Forms;

namespace UniwersalneProjekt.ViewModels
{
    public class QuestionDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Answer> Answers { get; set; }
        public Question Question { get; set; }
        public Command LoadAnswersCommand { get; set; }
        public QuestionDetailViewModel(Question question = null)
        {
            Title = "Question";
            Question = question;
            Answers = new ObservableCollection<Answer>();
            LoadAnswersCommand = new Command(async () => await ExecuteLoadAnswersCommand());
        }
        async Task ExecuteLoadAnswersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Answers.Clear();
                var answers = await DataStore.GetAnswersAsync(true, Question);
                int asciiLetter = 65;
                foreach (var answer in answers)
                {
                    answer.AnswerLetter = (char)asciiLetter;
                    asciiLetter++;
                    Answers.Add(answer);
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
