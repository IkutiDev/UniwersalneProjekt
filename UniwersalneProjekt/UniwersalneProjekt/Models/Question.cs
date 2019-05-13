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
    public class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public AnswerType AnswersType { get; set; } = AnswerType.Other;
        public List<Answer> Answers { get; set; }

    }
}
