using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace task1_c
{
    public class RealNumberViewModel : INotifyPropertyChanged
    {
        private RealNumber _firstRealNumber;
        private RealNumber _secondRealNumber;
        private RealNumber _result;
        private string _compareResult;

        public RealNumber FirstRealNumber
        {
            get { return _firstRealNumber; }
            set
            {
                _firstRealNumber = value;
                OnPropertyChanged(nameof(FirstRealNumber));
            }
        }

        public RealNumber SecondRealNumber
        {
            get { return _secondRealNumber; }
            set
            {
                _secondRealNumber = value;
                OnPropertyChanged(nameof(SecondRealNumber));
            }
        }

        public RealNumber Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public string CompareResult
        {
            get { return _compareResult; }
            set
            {
                _compareResult = value;
                OnPropertyChanged(nameof(CompareResult));
            }
        }

        public ICommand CompareCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SubtractCommand { get; private set; }
        public ICommand MultiplyCommand { get; private set; }
        public ICommand DivideCommand { get; private set; }

        public RealNumberViewModel()
        {
            _firstRealNumber = new RealNumber(0, 0, 0);
            _secondRealNumber = new RealNumber(0, 0, 0);
            _result = new RealNumber(0, 0, 0);

            CompareCommand = new RelayCommand(Compare);
            AddCommand = new RelayCommand(Add);
            SubtractCommand = new RelayCommand(Subtract);
            MultiplyCommand = new RelayCommand(Multiply);
            DivideCommand = new RelayCommand(Divide);
        }

        private void Compare()
        {
            int comparisonResult = RealNumber.Compare(FirstRealNumber, SecondRealNumber);
            CompareResult = GetComparisonResultString(comparisonResult);
        }

        private string GetComparisonResultString(int comparisonResult)
        {
            switch (comparisonResult)
            {
                case -1:
                    return "First number is less than the second number.";
                case 0:
                    return "Both numbers are equal.";
                case 1:
                    return "First number is greater than the second number.";
                default:
                    return "Comparison result is invalid.";
            }
        }

        private void Add()
        {
            Result = RealNumber.Add(FirstRealNumber, SecondRealNumber);
        }

        private void Subtract()
        {
            Result = RealNumber.Subtract(FirstRealNumber, SecondRealNumber);
        }

        private void Multiply()
        {
            Result = RealNumber.Multiply(FirstRealNumber, SecondRealNumber);
        }

        private void Divide()
        {
            Result = RealNumber.Divide(FirstRealNumber, SecondRealNumber);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
