using bubbleSortGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace bubbleSortGUI.Commands
{
    public class OpenFileCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel MainViewModel;
        private bool _readingCsv;
        public bool CanExecute(object parameter)
        {
            return !_readingCsv;
        }

        public void Execute(object parameter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Downloads";
                openFileDialog.Filter = "csv files (.csv)|*.csv";
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    _readingCsv = true;
                    CanExecuteChanged.Invoke(this, EventArgs.Empty);
                    MainViewModel.ReadCSV(filePath);
                    

                }
            }

            _readingCsv = false;
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
