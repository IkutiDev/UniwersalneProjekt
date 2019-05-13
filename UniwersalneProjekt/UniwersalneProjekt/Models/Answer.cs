using System;
using System.Collections.Generic;
using System.Text;

namespace UniwersalneProjekt.Models
{

    public class Answer
    {
        public string Id { get; set; }
        public char AnswerLetter { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; } = false;
    }
}
