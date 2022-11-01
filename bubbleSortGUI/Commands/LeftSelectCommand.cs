using bubbleSortGUI.ViewModels;
using System;
using System.Windows.Input;

namespace bubbleSortGUI.Commands
{
    public class LeftSelectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public LeftSelectCommand(MainViewModel mainViewModel)
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("bing bong");
        }
    }
}
