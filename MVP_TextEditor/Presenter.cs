using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.BL;//BLogic

namespace MVP_TextEditor
{
    class Presenter
    {
        private IMainform _view;
        private IFileManager _fileManager;
        private IMessageService _messageService;
        public Presenter(IMainform mainform, IFileManager fileManager, IMessageService messageService)
        {
            _view = mainform;
            _fileManager = fileManager;
            _messageService = messageService;
            _view.FileOpenClick += _view_FileOpenClick;
            _view.FileSaveClick += _view_FileSaveClick;
            _view.ContentChanged += _view_ContentChanged;
        }

        private void _view_ContentChanged(object sender, EventArgs e)
        {
            _view.SetSymbolCount();
        }

        private void _view_FileSaveClick(object sender, EventArgs e)
        {
            string path = _view.Path;
           
            try
            {
                _fileManager.SaveContent(_view.Content, path);
                _messageService.ShowMessage("File saved");
            }
            catch(Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _view_FileOpenClick(object sender, EventArgs e)
        {
            string path = _view.Path;
            if (_fileManager.IsExist(path))
            {
                
                try
                {
                    _view.Content = _fileManager.GetContent(path);
                   // _view.SetSymbolCount();
                }catch(Exception ex){
                    _messageService.ShowError("Cannot open file " + ex.Message);
                }
                
            }
            else
            {
                _messageService.ShowExclimation("File doesn't exist");
            }
        }
    }
}
