using System;
using System.Collections.Generic;
using System.Text;

namespace UniwersalneProjekt.Models
{
    public enum AnswerType
    {
        PlainText,
        NumbersOnly,
        YearOnly,
        NameSurname,
        Date,
        Other
    }
    public class Answer
    {
        public string Id { get; set; }
        public char AnswerLetter { get; set; }
        public string AnswerText { get; set; }
        public AnswerType AnswerType { get; set; } = AnswerType.Other;
        public bool IsCorrect { get; set; } = false;
    }
}
