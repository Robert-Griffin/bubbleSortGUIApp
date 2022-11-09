using bubbleSortGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bubbleSortGUI.Models
{
    public class SorterModel
    {
        public enum Selection { NONE, LEFT, RIGHT}

        private Selection _currentSelection = Selection.NONE;
        private MainViewModel _mainViewModel;

        public SorterModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private string _leftString = "Select file";
        public string LeftString
        {
            get 
            { 
                return _leftString;
            }
        }

        private string _rightString = "Select file";
        public string RightString
        {
            get 
            {
                return _rightString;
            }
        }

        public async Task<List<string>> Sort(List<string> inputStrings)
        {
            int n = inputStrings.Count;
            for (int i = 1; i < n; ++i)
            {
                _mainViewModel.CurrentTestValue = inputStrings[i];
                _mainViewModel.SortedValues = string.Join(",",inputStrings);
                _rightString = inputStrings[i];
                _mainViewModel.UpdateStrings();
                int j = i - 1;

                while (j >= 0)
                {
                    _leftString = inputStrings[j];
                    _mainViewModel.UpdateStrings();

                    while(_currentSelection == Selection.NONE)
                    {
                        await Task.Delay(100);
                    }

                    if (_currentSelection == Selection.RIGHT)
                    {
                        inputStrings[j + 1] = _leftString;
                        j--;
                        _mainViewModel.SortedValues = string.Join(",", inputStrings);
                        _currentSelection = Selection.NONE;
                    }
                    else
                    {
                        _currentSelection = Selection.NONE;
                        break;
                    }
                }
                inputStrings[j + 1] = _rightString;
                _mainViewModel.SortedValues = string.Join(",", inputStrings);
            }
            _mainViewModel.SortCompleted = true;
            _mainViewModel.CurrentTestValue = "Sort Completed";
            _mainViewModel.SortedValueList = inputStrings;
            _leftString = "";
            _rightString = "";
            _currentSelection = Selection.NONE;
            _mainViewModel.UpdateStrings();
            return inputStrings;
        }

        public void SetSelection(Selection selection)
        {
            _currentSelection = selection;
        }
    }
}
