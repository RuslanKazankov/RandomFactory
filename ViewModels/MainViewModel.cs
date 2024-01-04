using Prism.Commands;
using Prism.Mvvm;
using RandomFactory.Models;
using System.Windows.Input;

namespace RandomFactory.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private RandomGenerator randomGenerator = new RandomGenerator();

        private string resultOfGeneration = "0";
        public string ResultOfGeneration
        {
            get 
            {
                return resultOfGeneration; 
            }
            set
            {
                resultOfGeneration = value;
                RaisePropertyChanged(nameof(ResultOfGeneration));
            }
        }
        public double MinRange
        {
            get
            {
                return randomGenerator.MinRange;
            }
            set
            {
                randomGenerator.MinRange = value;
                RaisePropertyChanged(nameof(MinRange));
            }
        }
        public double MaxRange
        {
            get
            {
                return randomGenerator.MaxRange;
            }
            set
            {
                randomGenerator.MaxRange = value;
                RaisePropertyChanged(nameof(MaxRange));
            }
        }
        public bool UseRange
        {
            get
            {
                return randomGenerator.UseRange;
            }
            set
            {
                randomGenerator.UseRange = value;
                RaisePropertyChanged(nameof(UseRange));
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
