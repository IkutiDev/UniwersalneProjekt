using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;
using UniwersalneProjekt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniwersalneProjekt.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAnswer : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        AnswerViewModel viewModel;
        public AddAnswer (AnswerViewModel answerViewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel = answerViewModel;
		}
        public AddAnswer()
        {
            InitializeComponent();
            var category = new Category
            {
                Name = "Category 1",
                Questions = null
            };
            var question = new Question
            {
                QuestionText = "Question 1",
                AnswersType = AnswerType.Other,
                Answers = null
            };

            viewModel = new AnswerViewModel(category,question);
            BindingContext = viewModel;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}