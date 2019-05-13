using System;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using UniwersalneProjekt.UWP;
using UniwersalneProjekt.Services;
using UniwersalneProjekt.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

[assembly: Dependency(typeof(FileHelper))]
namespace UniwersalneProjekt.UWP
{
    public class FileHelper : IFileReadWrite
    {
        public void WriteData(string filename, Category data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                writer.WriteStartElement("Category");
                writer.WriteAttributeString("Id", data.Id);
                writer.WriteAttributeString("Name", data.Name);
                foreach (Question q in data.Questions)
                {
                    writer.WriteStartElement("Question");
                    writer.WriteAttributeString("Id", q.Id);
                    writer.WriteAttributeString("QuestionText", q.QuestionText);
                    writer.WriteAttributeString("AnswersType",q.AnswersType.ToString());
                    foreach (Answer a in q.Answers)
                    {
                        writer.WriteStartElement("Answer");
                        writer.WriteAttributeString("Id", a.Id);
                        writer.WriteAttributeString("IsCorrect", a.IsCorrect.ToString());
                        writer.WriteString(a.AnswerText);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }

        }
        public Category ReadData(string filename)
        {
            Category newCategory = new Category();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            XmlTextReader reader = new XmlTextReader(filePath);
            reader.Read();
            reader.Read();
            reader.MoveToElement();
            reader.MoveToFirstAttribute();
            newCategory.Id=reader.Value;
            reader.MoveToNextAttribute();
            newCategory.Name = reader.Value;
            newCategory.Questions = new List<Question>();
            while (reader.Read())
            {
                reader.MoveToElement();
                if (reader.Name=="Question" && reader.AttributeCount>0)
                {
                    Question newQuestion = new Question();
                    reader.MoveToFirstAttribute();
                    newQuestion.Id= reader.Value;
                    reader.MoveToNextAttribute();
                    newQuestion.QuestionText = reader.Value;
                    reader.MoveToNextAttribute();
                    AnswerType answerType;
                    Enum.TryParse(reader.Value,out answerType);
                    newQuestion.AnswersType = answerType;
                    newQuestion.Answers = new List<Answer>();
                    newCategory.Questions.Add(newQuestion);
                }
                if (reader.Name == "Answer" && reader.AttributeCount > 0)
                {
                    Answer newAnswer = new Answer();
                    reader.MoveToFirstAttribute();
                    newAnswer.Id = reader.Value;
                    reader.MoveToNextAttribute();
                    newAnswer.IsCorrect = bool.Parse(reader.Value);
                    reader.Read();
                    newAnswer.AnswerText = reader.Value;
                    newCategory.Questions[newCategory.Questions.Count - 1].Answers.Add(newAnswer);
                }
            }
            reader.Close();
            return newCategory;
        }
        public void DeleteFile(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            File.Delete(filePath);
        }
        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var files = Directory.GetFiles(documentsPath);
            foreach (var file in files)
            {
                categories.Add(ReadData(file));
            }
            return categories;
        }
    }
}
