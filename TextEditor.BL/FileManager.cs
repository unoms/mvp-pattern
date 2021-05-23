using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.BL
{
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        public string GetContent(string path)//Try..catch block will be in Presenter
        {
            string content;
            using (var sr = new StreamReader(path, _defaultEncoding))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }
        //Overloaded method if we want to use not a default encoding
        public string GetContent(string path, Encoding encoding)
        {
            string content;
            using(var sr = new StreamReader(path, encoding))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }


        public bool IsExist(string path) //The real check will be in Presenter
        {
            if (File.Exists(path))
                return true;
            return false;
        }

        public void SaveContent(string content, string path, Encoding encoding)
        {
            File.WriteAllText(path, content, encoding);
        }

        public void SaveContent(string content, string path)
        {
            File.WriteAllText(path, content, _defaultEncoding);
        }
    }
}
