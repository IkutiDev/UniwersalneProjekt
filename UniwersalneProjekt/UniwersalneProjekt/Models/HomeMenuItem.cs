using System;
using System.Collections.Generic;
using System.Text;

namespace UniwersalneProjekt.Models
{
    public enum MenuItemType
    {
        Add,
        Browse,
        DoQuiz,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
