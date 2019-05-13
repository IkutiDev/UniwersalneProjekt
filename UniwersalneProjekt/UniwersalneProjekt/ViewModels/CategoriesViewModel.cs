using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using UniwersalneProjekt.Models;
using UniwersalneProjekt.Views;
using UniwersalneProjekt.Services;

namespace UniwersalneProjekt.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public Command LoadCategoriesCommand { get; set; }

        public CategoriesViewModel()
        {
            Title = "Browse";
            Categories = new ObservableCollection<Category>();
            LoadCategoriesCommand = new Command(() => ExecuteLoadCategoriesCommand());
            
        }
        public Command<Category> DeleteCategoryCommand
        {
            get
            {
                return new Command<Category>((category) =>
                {
                    Categories.Remove(category);
                    Debug.WriteLine(category.Id);
                    DependencyService.Get<IFileReadWrite>().DeleteFile(category.Id + ".xml");

                });
            }
        }
        void ExecuteLoadCategoriesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Categories.Clear();
                var categories = DependencyService.Get<IFileReadWrite>().GetAll();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}