using System;
using System.Collections.Generic;
using System.Text;
using UniwersalneProjekt.Models;

namespace UniwersalneProjekt.Services
{
    public interface IFileReadWrite
    {
        void WriteData(string fileName, string data);
        string ReadData(string filename);
        void DeleteFile(string filename);
        List<Category> GetAll();
    }
}
