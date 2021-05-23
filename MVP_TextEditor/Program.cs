using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.BL;
using System.IO;

namespace MVP_TextEditor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormTextEditor formTextEditor = new FormTextEditor();
            FileManager fileManager = new FileManager();
            IMessageService messageService = new ServiceMessage();

            Presenter presenter = new Presenter(formTextEditor, fileManager, messageService);
            Application.Run(formTextEditor);

           
        }
    }
}
