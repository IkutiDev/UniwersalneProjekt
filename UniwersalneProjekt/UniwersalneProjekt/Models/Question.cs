using System;
using System.Collections.Generic;
using System.Text;

namespace UniwersalneProjekt.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }

        public List<Answer> Answers { get; set; }

    }
}
