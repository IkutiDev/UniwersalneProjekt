using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using UniwersalneProjekt.Models;
using UniwersalneProjekt.Validators;
using Xamarin.Forms;

namespace UniwersalneProjekt.ViewModels
{
    class CategoryViewModel : BaseViewModel
    {
        private string _name;

        private string _nameError = "";
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                _nameError = !ValidateName() ? "Kategoria nie może być pusta!" : "";
            }
        }
        public string NameError
        {
            get => _nameError;
            set
            {
                _nameError = value;
                OnPropertyChanged();
            }
        }
        private bool ValidateName()
        {
            return ValidatorRule.IsNotNullOrEmpty(Name);
        }
        private bool Validate()
        {
            return ValidateName();
        }
        public ICommand AddCategoryCommand => new Command(AddCategoryAsync);
        private async void AddCategoryAsync()
        {
            Debug.WriteLine("Test");
            bool isValid = Validate();
            if (isValid)
            {
                Category category = new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Name,
                    Questions=null
                };
                var test =await DataStore.AddCategoryAsync(category);
                Debug.WriteLine(test);
                var categories = await DataStore.GetCategoriesAsync(true);
                foreach (var categoryy in categories)
                {
                    Debug.WriteLine(categoryy.Name);
                }
                ClearData();
            }
        }

        private void ClearData()
        {
            Name = "";
            NameError = "";
        }

        public CategoryViewModel(Category category = null)
        {
            _name = category?.Name;
        }
    }
}
