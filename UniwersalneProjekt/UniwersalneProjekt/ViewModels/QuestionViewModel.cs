using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UniwersalneProjekt.Models;
using UniwersalneProjekt.Services;
using UniwersalneProjekt.Validators;
using Xamarin.Forms;

namespace UniwersalneProjekt.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public Category Category;
        private string _questionText;
        private string _questionTextError="";
        public List<string> AnswerTypeNames
        {
            get
            {
                return new List<string> {"PlainText","NumbersOnly","YearOnly","NameSurname","Date","Other"};
            }
        }
        private string _selectedAnswerType= "Other";
        public string SelectedAnswerType
        {
            get
            {
                return _selectedAnswerType;
            }
            set
            {
                _selectedAnswerType = value;
                OnPropertyChanged();
            }
        }
        public string QuestionText
        {
            get => _questionText;
            set
            {
                _questionText = value;
                OnPropertyChanged();
                _questionTextError = !ValidateQuestionText() ? "Kategoria nie może być pusta!" : "";
            }
        }
        public string QuestionTextError
        {
            get => _questionTextError;
            set
            {
                _questionTextError = value;
                OnPropertyChanged();
            }
        }
        private bool ValidateQuestionText()
        {
            return ValidatorRule.IsNotNullOrEmpty(QuestionText);
        }
        private bool Validate()
        {
            return ValidateQuestionText();
        }
        public ICommand AddQuestionCommand => new Command(AddQuestion);
        private void AddQuestion()
        {
            bool isValid = Validate();
            if (isValid)
            {
                AnswerType answerType;
                Enum.TryParse(SelectedAnswerType,out answerType);
                Question newQuestion = new Question
                {
                    Id = Guid.NewGuid().ToString(),
                    QuestionText = QuestionText,
                    Answers = new List<Answer>(),
                    AnswersType = answerType
                };
                string fileName = Category.Id + ".xml";
                Category.Questions.Add(newQuestion);
                DependencyService.Get<IFileReadWrite>().WriteData(fileName, Category);
                ClearData();
            }
        }
        public void ClearData()
        {
            QuestionText = "";
            //QuestionTextError = "";
        }
        public QuestionViewModel(Category category=null)
        {
            Category = category;
        }
    }
}
