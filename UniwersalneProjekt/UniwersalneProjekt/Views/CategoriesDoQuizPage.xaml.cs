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
	public partial class CategoriesDoQuizPage : ContentPage
	{
        CategoriesViewModel viewModel;

        public CategoriesDoQuizPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoriesViewModel();
        }
        async void OnCategorySelected(object sender, SelectedItemChangedEventArgs args)
        {
            var category = args.SelectedItem as Category;
            if (category == null)
                return;

            await Navigation.PushAsync(new DoQuizPage(new DoQuizViewModel(category)));

            // Manually deselect item.
            CategoriesDoQuizListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCategoriesCommand.Execute(null);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var category = button?.BindingContext as Category;
            var vm = BindingContext as CategoriesViewModel;
            vm?.DeleteCategoryCommand.Execute(category);
        }
    }
}