using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using UniwersalneProjekt.Models;
using UniwersalneProjekt.Services;
using UniwersalneProjekt.Validators;
using UniwersalneProjekt.Views;
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
        public ICommand AddCategoryCommand => new Command(AddCategory);
        private void AddCategory()
        {
            bool isValid = Validate();
            if (isValid)
            {
                Category newCategory = new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Name,
                    Questions = new List<Question>()
                };
                string fileName = newCategory.Id + ".xml";
                DependencyService.Get<IFileReadWrite>().WriteData(fileName, newCategory);
                ClearData();
            }
        }

        public void ClearData()
        {
            Name = "";
            //NameError = "";
        }

        public CategoryViewModel(Category category = null)
        {
            _name = category?.Name;
        }
    }
}
