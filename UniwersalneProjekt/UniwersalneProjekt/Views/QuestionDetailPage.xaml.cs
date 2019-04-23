using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UniwersalneProjekt.Models;
using UniwersalneProjekt.ViewModels;

namespace UniwersalneProjekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionDetailPage : ContentPage
    {
        QuestionDetailViewModel viewModel;

        public QuestionDetailPage(QuestionDetailViewModel questionDetailViewModel)
        {
            InitializeComponent();

            BindingContext = viewModel = questionDetailViewModel;
        }

        public QuestionDetailPage()
        {
            InitializeComponent();

            var question = new Question
            {
                QuestionText="Test",
                Answers=null
            };

            viewModel = new QuestionDetailViewModel(question);
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Answers.Count == 0)
                viewModel.LoadAnswersCommand.Execute(null);
        }
    }
}