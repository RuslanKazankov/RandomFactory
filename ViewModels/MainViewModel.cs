using Prism.Commands;
using Prism.Mvvm;
using RandomFactory.Models;
using System.Windows.Input;

namespace RandomFactory.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private RandomGenerator randomGenerator = new RandomGenerator();

        private string _resultOfGeneration = "0";
        public string ResultOfGeneration
        {
            get 
            {
                return _resultOfGeneration; 
            }
            set
            {
                _resultOfGeneration = value;
                RaisePropertyChanged("ResultOfGeneration");
            }
        }

        public ICommand GenerateIntCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ResultOfGeneration = randomGenerator.GenerateInt().ToString();
                });
            }
        }
        public ICommand GenerateDoubleCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ResultOfGeneration = randomGenerator.GenerateDouble().ToString();
                });
            }
        }
        public ICommand GeneratePercentCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ResultOfGeneration = randomGenerator.GeneratePercent().ToString() + "%";
                });
            }
        }


    }
}
