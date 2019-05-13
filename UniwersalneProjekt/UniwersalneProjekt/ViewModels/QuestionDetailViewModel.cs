using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;
using UniwersalneProjekt.Services;
using Xamarin.Forms;

namespace UniwersalneProjekt.ViewModels
{
    public class QuestionDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Answer> Answers { get; set; }
        public Question Question { get; set; }
        public Category Category { get; set; }
        public Command LoadAnswersCommand { get; set; }
        public QuestionDetailViewModel(Question question = null,Category category=null)
        {
            Title = question?.QuestionText;
            Question = question;
            Category = category;
            Answers = new ObservableCollection<Answer>();
            if (question.Answers != null)
            {
                foreach (Answer a in question.Answers)
                {
                    Answers.Add(a);
                }
            }
            LoadAnswersCommand = new Command(() => ExecuteLoadAnswersCommand());
        }
        public Command<Answer> DeleteAnswerCommand
        {
            get
            {
                return new Command<Answer>((answer) =>
                {
                    Category.Questions.Find(x => x.Id == Question.Id).Answers.Remove(answer);
                    Debug.WriteLine(answer.Id);
                    string fileName = Category.Id + ".xml";
                    DependencyService.Get<IFileReadWrite>().WriteData(fileName, Category);

                });
            }
        }
        void ExecuteLoadAnswersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Answers.Clear();
                var answers = Question.Answers;
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
