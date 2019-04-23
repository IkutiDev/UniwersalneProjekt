using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniwersalneProjekt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniwersalneProjekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategory : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        private CategoryViewModel viewModel;
        public AddCategory()
        {
            InitializeComponent();
            viewModel = new CategoryViewModel();
            BindingContext = viewModel;
        }
    }
}