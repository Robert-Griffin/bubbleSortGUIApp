using bubbleSortGUI.Commands;
using bubbleSortGUI.Models;
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
        private List<List<string>> csv;
        public MainViewModel()
        {
            _openFileCommand = new OpenFileCommand
            {
                MainViewModel = this
            };
        }

        private string _leftString = "test";
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

        private string _rightString = "test2";

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


        private ICommand _leftSelectCommand = new LeftSelectCommand();

        public ICommand LeftSelectCommand
        {
            get 
            { return _leftSelectCommand; }
            set { _leftSelectCommand = value; }
        }
       
        private ICommand _rightSelectCommand = new RightSelectCommand();

        public ICommand RightSelectCommand
        {
            get
            { return _rightSelectCommand; }
            set { _rightSelectCommand = value; }
        }

        private ICommand _openFileCommand;


        public ICommand OpenFileCommand
        {
            get
            { return _openFileCommand; }
            set { _openFileCommand = value; }
        }

        public void ReadCSV(string path)
        {
            CSVReaderModel csvReaderModel = new CSVReaderModel();

            csv = csvReaderModel.ReadCSV(path);

        }


    }
}
