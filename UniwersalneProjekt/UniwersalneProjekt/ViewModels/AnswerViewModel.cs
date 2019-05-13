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
    public class AnswerViewModel : BaseViewModel
    {
        public Category Category;
        public Question Question;
        private string _answerText;
        private string _answerTextError = "";
        private bool _isCorect;
        public bool IsCorrect
        {
            get => _isCorect;
            set
            {
                _isCorect = value;
                OnPropertyChanged();
            }
        }
        public string AnswerText
        {
            get => _answerText;
            set
            {
                _answerText = value;
                OnPropertyChanged();
                _answerTextError = !ValidateAnswerText(Question.AnswersType) ? "Odpowiedz nie jest poprawnie napisana" : "";
            }
        }
        public string AnswerTextError
        {
            get => _answerTextError;
            set
            {
                _answerTextError = value;
                OnPropertyChanged();
            }
        }
        private bool ValidateAnswerText(AnswerType answerType)
        {
            switch (answerType)
            {
                case AnswerType.Other:
                    return ValidatorRule.IsNotNullOrEmpty(AnswerText);
                case AnswerType.PlainText:
                    return ValidatorRule.IsOnlyPlainText(AnswerText);
                case AnswerType.NumbersOnly:
                    return ValidatorRule.IsNumbersOnly(AnswerText);
                case AnswerType.Date:
                    return ValidatorRule.IsDateOnly(AnswerText);
                case AnswerType.YearOnly:
                    return ValidatorRule.IsYearOnly(AnswerText);
                case AnswerType.NameSurname:
                    return ValidatorRule.IsNameAndSurameOnly(AnswerText);
                default:
                    return ValidatorRule.IsNotNullOrEmpty(AnswerText);
            }
        }
        private bool Validate()
        {
            return ValidateAnswerText(Question.AnswersType);
        }
        public ICommand AddAnswerCommand => new Command(AddAnswer);
        private void AddAnswer()
        {
            bool isValid = Validate();
            if (isValid)
            {
                Answer newAnswer = new Answer
                {
                    Id= Guid.NewGuid().ToString(),
                    AnswerText=AnswerText,
                    IsCorrect=IsCorrect
                };
                string fileName = Category.Id + ".xml";
                Category.Questions.Find(x => x.Id==Question.Id).Answers.Add(newAnswer);
                DependencyService.Get<IFileReadWrite>().WriteData(fileName, Category);
                ClearData();
            }
        }
        public void ClearData()
        {
            AnswerText = "";
            //AnswerTextError = "";
        }
        public AnswerViewModel(Category category = null, Question question=null)
        {
            Category = category;
            Question = question;
        }
    }
}
