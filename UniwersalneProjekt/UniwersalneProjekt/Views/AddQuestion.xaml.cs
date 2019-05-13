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
	public partial class AddQuestion : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        QuestionViewModel viewModel;
        public AddQuestion (QuestionViewModel questionViewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel = questionViewModel;
		}
        public AddQuestion()
        {
            InitializeComponent();
            var category = new Category
            {
                Name = "Category 1",
                Questions = null
            };

            viewModel = new QuestionViewModel(category);
            BindingContext = viewModel;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}