using bubbleSortGUI.ViewModels;
using System;
using System.Windows.Input;

namespace bubbleSortGUI.Commands
{
    public class LeftSelectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel _mainViewModel;

        public LeftSelectCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainViewModel.ChooseLeft();
        }
    }
}
