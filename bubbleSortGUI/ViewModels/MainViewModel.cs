using bubbleSortGUI.Commands;
using bubbleSortGUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace bubbleSortGUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private List<string> csv;
        private SorterModel sorterModel;
        public MainViewModel()
        {
            sorterModel = new SorterModel(this);
            _leftSelectCommand = new LeftSelectCommand(this);
            _rightSelectCommand = new RightSelectCommand(this);
            _openFileCommand = new OpenFileCommand
            {
                MainViewModel = this
            };
        }

        private string _openedFileName;

        public string OpenedFileName
        {
            get 
            { 
                return _openedFileName;
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



        private ICommand _leftSelectCommand;
        public ICommand LeftSelectCommand
        {
            get 
            { return _leftSelectCommand; }
        }
       

        private ICommand _rightSelectCommand;
        public ICommand RightSelectCommand
        {
            get
            { return _rightSelectCommand; }
        }


        private ICommand _openFileCommand;
        public ICommand OpenFileCommand
        {
            get
            { return _openFileCommand; }
            set { _openFileCommand = value; }
        }

        public async Task ReadCSV(string path)
        {
            CsvControllerModel CsvControllerModel = new CsvControllerModel();

            csv = CsvControllerModel.ReadCSV(path);


            await sorterModel.Sort(csv);

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
