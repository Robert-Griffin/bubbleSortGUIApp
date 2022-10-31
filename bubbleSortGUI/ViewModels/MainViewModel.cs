using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace bubbleSortGUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _leftString;
        public string LeftString
        {
            get
            {
                return _leftString;
            }
            set
            {
                LeftString = value;
                OnPropertyChanged(nameof(LeftString));
            }
        }

        private string _rightString;

        public string RightString
        {
            get 
            {
                return _rightString;
            }
            set
            {
                _rightString = value;
                OnPropertyChanged(nameof(RightString));
            }
        }

        public ICommand LeftSelectCommand { get; }
        public ICommand RightSelectCommand { get; }
    }
}
