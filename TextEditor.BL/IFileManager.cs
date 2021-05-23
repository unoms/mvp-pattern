using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.BL
{
    public interface IFileManager
    {
        string GetContent(string path, Encoding encoding);
        string GetContent(string path); //overloaded method with default Encoding 1251
        void SaveContent(string content, string path, Encoding encoding);
        void SaveContent(string content, string path);
        bool IsExist(string path);

    }
}
