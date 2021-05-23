using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_TextEditor
{
    public interface IMessageService
    {
        void ShowMessage(string msg);
        void ShowExclimation(string msg);
        void ShowError(string msg);
    }
    class ServiceMessage : IMessageService
    {
        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowExclimation(string msg)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
