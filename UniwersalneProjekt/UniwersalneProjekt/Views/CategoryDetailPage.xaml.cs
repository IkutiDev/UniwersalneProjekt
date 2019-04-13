using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UniwersalneProjekt.Models;
using UniwersalneProjekt.ViewModels;

namespace UniwersalneProjekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailPage : ContentPage
    {
        CategoryDetailViewModel viewModel;

        public CategoryDetailPage(CategoryDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CategoryDetailPage()
        {
            InitializeComponent();

            var category = new Category
            {
                Name = "Category 1",
                Questions = null
            };

            viewModel = new CategoryDetailViewModel(category);
            BindingContext = viewModel;
        }
    }
}