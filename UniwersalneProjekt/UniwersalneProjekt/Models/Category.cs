using System;
using System.Collections.Generic;
using System.Text;

namespace UniwersalneProjekt.Models
{
    class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
