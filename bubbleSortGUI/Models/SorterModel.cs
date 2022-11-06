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
        // TODO reset Selection to none
        // TODO reset LeftString and RightString so buttons go back to blank
        

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
            get { return _leftString; }
        }

        private string _rightString = "Select file";

        public string RightString
        {
            get { return _rightString; }
        }


        public async Task<List<string>> Sort(List<string> inputStrings)
        {

            int n = inputStrings.Count;
            for (int i = 1; i < n; ++i)
            {
                // TODO Why is left string initialized as the 1st position instead of 0th position?
                _rightString = inputStrings[i];
                _mainViewModel.UpdateStrings();


                int j = i - 1;

                // Move elements of inputStrings[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                // while (j >= 0 && arr[j] > key)
                while (j >= 0)
                {
                    _leftString = inputStrings[j];
                    _mainViewModel.UpdateStrings();


                    // Initialize button's content after file is loaded
                    //if (i == 1 && j == 0)
                    //{
                    //    _mainViewModel.UpdateStrings();
                    //}

                    // Loop until selection is made
                    while(_currentSelection == Selection.NONE)
                    {
                        await Task.Delay(100);
                    }

                    // 
                    if (_currentSelection == Selection.RIGHT)
                    {
                        inputStrings[j + 1] = _leftString;
                        j--;
                        _currentSelection = Selection.NONE;
                    }
                    else
                    {
                        _currentSelection = Selection.NONE;
                        break;
                    }
                    
                }
                inputStrings[j + 1] = _rightString;
            }

            return inputStrings;
        }

        public void SetSelection(Selection selection)
        {
            _currentSelection = selection;
        }


    }
}
