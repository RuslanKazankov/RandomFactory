﻿using Microsoft.Xaml.Behaviors.Input;
using Prism.Commands;
using Prism.Mvvm;
using RandomFactory.Models;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace RandomFactory.ViewModels
{
    public class RandomGeneratorVM : BindableBase
    {
        private RandomGenerator randomGenerator;
        public RandomGeneratorVM() {
            randomGenerator = new RandomGenerator();
        }

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

        private double minRange;
        public double MinRange
        {
            get
            {
                return minRange;
            }
            set
            {
                minRange = value;
                RaisePropertyChanged(nameof(MinRange));
            }
        }

        private double maxRange = 100;
        public double MaxRange
        {
            get
            {
                return maxRange;
            }
            set
            {
                maxRange = value;
                RaisePropertyChanged(nameof(MaxRange));
            }
        }

        private bool useRange = true;
        public bool UseRange
        {
            get
            {
                return useRange;
            }
            set
            {
                useRange = value;
                RaisePropertyChanged(nameof(UseRange));
            }
        }

        private DelegateCommand generateInt;
        public ICommand GenerateIntCommand
        {
            get
            {
                return generateInt ?? (generateInt = new DelegateCommand(() =>
                {
                    if (UseRange)
                    {
                        ResultOfGeneration = randomGenerator.GenerateInt(MinRange, MaxRange).ToString();
                    }
                    else ResultOfGeneration = randomGenerator.GenerateInt().ToString();
                }));
            }
        }

        private DelegateCommand generateDouble;
        public ICommand GenerateDoubleCommand
        {
            get
            {
                return generateDouble ?? (generateDouble = new DelegateCommand(() =>
                {
                    if (UseRange)
                    {
                        ResultOfGeneration = randomGenerator.GenerateDouble(MinRange, MaxRange).ToString();
                    }
                    else ResultOfGeneration = randomGenerator.GenerateDouble().ToString();
                }));
            }
        }

        private DelegateCommand generatePercent;
        public ICommand GeneratePercentCommand
        {
            get
            {
                return generatePercent ?? (generatePercent = new DelegateCommand(() =>
                {
                    if (UseRange)
                    {
                        ResultOfGeneration = randomGenerator.GeneratePercent(MinRange, MaxRange).ToString() + "%";
                    }
                    else ResultOfGeneration = randomGenerator.GeneratePercent().ToString() + "%";
                }));
            }
        }

        public int Seed
        {
            get { return randomGenerator.Seed; }
            set
            {
                randomGenerator.Seed = value;
                RaisePropertyChanged(nameof(Seed));
            }
        }

        private DelegateCommand randomSeedCommand;

        public ICommand RandomSeedCommand
        {
            get
            {
                if (randomSeedCommand == null)
                {
                    randomSeedCommand = new DelegateCommand(() => {
                        Seed = randomGenerator.GenerateInt();
                    });
                }

                return randomSeedCommand;
            }
        }

        private DelegateCommand copyResultCommand;

        public ICommand CopyResultCommand
        {
            get
            {
                if (copyResultCommand == null)
                {
                    copyResultCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            Clipboard.SetText(resultOfGeneration);
                        }
                        catch (COMException)
                        {

                            throw;
                        }
                    });
                }

                return copyResultCommand;
            }
        }

    }
}
