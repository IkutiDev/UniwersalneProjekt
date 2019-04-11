using System;

using UniwersalneProjekt.Models;

namespace UniwersalneProjekt.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Handle;
            Item = item;
        }
    }
}
