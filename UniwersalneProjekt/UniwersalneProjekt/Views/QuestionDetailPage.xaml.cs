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

            //if (viewModel.Answers.Count == 0)
                viewModel.LoadAnswersCommand.Execute(null);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAnswer(new AnswerViewModel(viewModel.Category,viewModel.Question)));
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var answer = button?.BindingContext as Answer;
            var vm = BindingContext as QuestionDetailViewModel;
            vm?.DeleteAnswerCommand.Execute(answer);
            vm?.LoadAnswersCommand.Execute(null);
        }
    }
}