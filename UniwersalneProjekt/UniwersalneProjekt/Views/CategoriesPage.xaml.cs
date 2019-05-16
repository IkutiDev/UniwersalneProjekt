using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UniwersalneProjekt.Models;
using UniwersalneProjekt.Views;
using UniwersalneProjekt.ViewModels;
using System.Diagnostics;

namespace UniwersalneProjekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel viewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoriesViewModel();
        }

        async void OnCategorySelected(object sender, SelectedItemChangedEventArgs args)
        {
            var category = args.SelectedItem as Category;
            if (category == null)
                return;
            Debug.WriteLine(category.Id);
            await Navigation.PushAsync(new CategoryDetailPage(new CategoryDetailViewModel(category)));

            // Manually deselect item.
            CategoriesListView.SelectedItem = null;
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