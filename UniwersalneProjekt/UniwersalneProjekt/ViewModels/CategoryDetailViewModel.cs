using System;
using System.Collections.ObjectModel;
using UniwersalneProjekt.Models;

namespace UniwersalneProjekt.ViewModels
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Question> Questions { get; set; }
        public ObservableCollection<Answer> Answers { get; set; }
        public Category Category { get; set; }
        public CategoryDetailViewModel(Category category = null)
        {
            Title = category?.Name;
            Category = category;
        }
    }
}
