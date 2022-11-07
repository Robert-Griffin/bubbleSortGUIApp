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
    public class SaveFileCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel MainViewModel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\Downloads";
                saveFileDialog.Filter = "csv files (.csv)|*.csv";
                saveFileDialog.RestoreDirectory = false;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    if (fileName != null)
                    {
                        MainViewModel.WriteCSV(fileName);
                    }
                }
            }
        }
    }
}
