using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class AddCategory : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        private CategoryViewModel viewModel;
        public AddCategory()
        {
            InitializeComponent();
            viewModel = new CategoryViewModel();
            BindingContext = viewModel;
;        }

        private async void  Button_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu((int)MenuItemType.Browse);
        }
    }
}