using bubbleSortGUI.Commands;
using bubbleSortGUI.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace bubbleSortGUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region fields
        private List<string> csv;
        private SorterModel sorterModel;
        private string fileNameRegex = @"[a-zA-Z0-9_\-\.\(\)]+(\.csv)";
        #endregion
        public MainViewModel()
        {
            sorterModel = new SorterModel(this);
            _leftSelectCommand = new LeftSelectCommand(this);
            _rightSelectCommand = new RightSelectCommand(this);
            _openFileCommand = new OpenFileCommand
            {
                MainViewModel = this
            };
            _saveFileCommand = new SaveFileCommand
            {
                MainViewModel = this
            };
        }

        #region properties
        private bool _sortCompleted;
        public bool SortCompleted
        {
            get 
            {
                return _sortCompleted;
            }
            internal set 
            { 
                _sortCompleted = value;
                OnPropertyChanged(nameof(SortCompleted));
            }
        }

        private List<string> _sortedValueList;
        public List<string> SortedValueList
        {
            get
            {
                return _sortedValueList;
            }
            set
            { 
                _sortedValueList = value;
            }
        }


        private string _initialValues;
        public string InitialValues
        {
            get 
            { 
                return _initialValues;
            }
            private set
            {
                _initialValues = value;
                OnPropertyChanged(nameof(InitialValues)); 
            }
        }

        private string _sortedValues;
        public string SortedValues
        {
            get
            {
                return _sortedValues;
            }
            internal set
            {
                _sortedValues = value;
                OnPropertyChanged(nameof(SortedValues));
            }
        }

        private string _currentTestValue;
        public string CurrentTestValue
        {
            get
            { 
                return _currentTestValue;
            }
            internal set
            {
                _currentTestValue = value;
                OnPropertyChanged(nameof(CurrentTestValue));
            }
        }

        private string _openedFileName;
        public string OpenedFileName
        {
            get 
            { 
                return _openedFileName;
            }
            private set
            {
                _openedFileName = value;
                OnPropertyChanged(nameof(OpenedFileName));
            }
        }

        public string LeftString
        {
            get
            {
                return sorterModel.LeftString;
            }
        }

        public string RightString
        {
            get
            {
                return sorterModel.RightString;
            }
        }

        private ICommand _saveFileCommand;
        public ICommand SaveFileCommand
        {
            get
            { 
                return _saveFileCommand;
            }
        }

        private ICommand _leftSelectCommand;
        public ICommand LeftSelectCommand
        {
            get 
            {
                return _leftSelectCommand;
            }
        }

        private ICommand _rightSelectCommand;
        public ICommand RightSelectCommand
        {
            get
            { 
                return _rightSelectCommand;
            }
        }

        private ICommand _openFileCommand;
        public ICommand OpenFileCommand
        {
            get
            { 
                return _openFileCommand;
            }
        }
        #endregion

        public async Task ReadCSV(string path)
        {
            CsvControllerModel CsvControllerModel = new CsvControllerModel();
            csv = CsvControllerModel.ReadCSV(path);
            InitialValues = string.Join(",",csv);
            OpenedFileName = Regex.Match(path, fileNameRegex).ToString();
            await sorterModel.Sort(csv);
        }

        public void WriteCSV(string fileName)
        {
            if (SortCompleted)
            {
                CsvControllerModel CsvControllerModel = new CsvControllerModel();
                CsvControllerModel.WriteCsv(SortedValueList, fileName);
            }
            else
            {
                throw new Exception("Sort Not Completed");
            }
        }
            
        public void ChooseLeft()
        {
            sorterModel.SetSelection(SorterModel.Selection.LEFT);
        }

        public void ChooseRight()
        {
            sorterModel.SetSelection(SorterModel.Selection.RIGHT);
        }

        public void UpdateStrings()
        {
            OnPropertyChanged(nameof(RightString));
            OnPropertyChanged(nameof(LeftString));
        }
    }
}
