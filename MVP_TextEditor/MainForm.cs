using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_TextEditor
{
    public interface IMainform
    {
        //Пробрасываем свойства из формы в презентер
        string Content { get; set; }
        string Path { get; }
        //Пробрасываем метод
        void SetSymbolCount();
        //Пробрасываем события
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }

    public partial class FormTextEditor : Form, IMainform
    {
        public FormTextEditor()
        {
            InitializeComponent();
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            contextBox.TextChanged += ContextBox_TextChanged;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to close the app?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) e.Cancel = true;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            contextBox.Font = new Font("Arial", (float)numericUpDown1.Value);
        }
        #region Проброс свойств
        public string Path { get => pathBox.Text;  }
        public string Content { get => contextBox.Text; set => contextBox.Text = value; }
        #endregion

        #region Проброс Событий
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
       
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "Text files(*.odt)|*.odt|(*.txt)|*.txt|All files(*.*)|*.*";
            openFile.Filter = "Text files (*.txt)|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pathBox.Text = openFile.FileName;
                FileOpenClick?.Invoke(sender, EventArgs.Empty); //Это называется проброс событий
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(contextBox.Text != string.Empty)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files(*.odt)|*.odt|(*.txt)|*.txt|All files(*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pathBox.Text = saveFileDialog.FileName;
                    FileSaveClick?.Invoke(sender, EventArgs.Empty);
                }
            }
            
        }


        private void ContextBox_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null)
            {
                ContentChanged(sender, EventArgs.Empty);
            }
        }

        #endregion
        public void SetSymbolCount()
        {
            NumberOfChatacters.Text = contextBox.Text.Length.ToString();
        }
    }
}
