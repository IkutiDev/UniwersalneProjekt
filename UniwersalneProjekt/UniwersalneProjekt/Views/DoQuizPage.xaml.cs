using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UniwersalneProjekt.Models;
using UniwersalneProjekt.ViewModels;
namespace UniwersalneProjekt.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoQuizPage : ContentPage
	{
        DoQuizViewModel viewModel;
		public DoQuizPage (DoQuizViewModel doQuizViewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel = doQuizViewModel;
            
        }
        public DoQuizPage()
        {
            InitializeComponent();

            var category = new Category
            {
                Name = "Category 1",
                Questions = null
            };

            viewModel = new DoQuizViewModel(category);
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadQuestionsCommand.Execute(null);
        }
    }
}