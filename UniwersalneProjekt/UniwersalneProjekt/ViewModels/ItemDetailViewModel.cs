using System;

using UniwersalneProjekt.Models;

namespace UniwersalneProjekt.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Category Category { get; set; }
        public ItemDetailViewModel(Category category = null)
        {
            Title = category?.Name;
            Category = category;
        }
    }
}
