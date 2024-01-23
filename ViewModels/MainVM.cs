using Prism.Commands;
using Prism.Mvvm;
using RandomFactory.Models;
using RandomFactory.Models.DataAccess;
using RandomFactory.Models.ValueType;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace RandomFactory.ViewModels
{
    public class MainVM : BindableBase
    {
        private RandomGenerator randomGenerator = new RandomGenerator();
        private ValueDbContext valueDb;
        private ObservableCollection<ValueEntity> valueHistory;

        public MainVM(ValueDbContext db)
        {
            valueDb = db;
            valueDb.LoadAll();
            ValueHistory = new ObservableCollection<ValueEntity>(db.Values.ToList());
            CurrentValue = valueHistory.LastOrDefault();
        }

        public ObservableCollection<ValueEntity> ValueHistory
        {
            get { return valueHistory; }
            set
            {
                valueHistory = value;
                RaisePropertyChanged(nameof(ValueHistory));
            }
        }

        private ValueEntity currentValue;
        public ValueEntity CurrentValue
        {
            get { return currentValue; }
            set
            {
                currentValue = value;
                RaisePropertyChanged(nameof(CurrentStep));
                RaisePropertyChanged(nameof(ResultOfGeneration));
                RaisePropertyChanged(nameof(Seed));
                if (currentValue != null)
                {
                    randomGenerator.SetSeed(currentValue.Seed, currentValue.Step);
                    if (currentValue.Range != null)
                    {
                        MinRange = currentValue.Range.Min;
                        MaxRange = currentValue.Range.Max;
                    }
                }
            }
        }

        public string ResultOfGeneration => CurrentValue?.Value ?? "0";
        public int CurrentStep => CurrentValue?.Step ?? 0;

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

        public int Seed
        {
            get { return randomGenerator.Seed; }
            set
            {
                randomGenerator.SetSeed(value);
                RaisePropertyChanged(nameof(Seed));
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
                    string result;
                    if (UseRange)
                    {
                        result = randomGenerator.GenerateInt(MinRange, MaxRange).ToString();
                    }
                    else result = randomGenerator.GenerateInt().ToString();

                    if (!randomGenerator.Exception)
                        Generate(valueDb.ValueTypes.Find(1), result);
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
                    string result;
                    if (UseRange)
                    {
                        result = randomGenerator.GenerateDouble(MinRange, MaxRange).ToString();
                    }
                    else result = randomGenerator.GenerateDouble().ToString();

                    if (!randomGenerator.Exception)
                        Generate(valueDb.ValueTypes.Find(2), result);
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
                    string result;
                    if (UseRange)
                    {
                        result = randomGenerator.GeneratePercent(MinRange, MaxRange).ToString() + "%";
                    }
                    else result = randomGenerator.GeneratePercent().ToString() + "%";

                    if (!randomGenerator.Exception)
                        Generate(valueDb.ValueTypes.Find(3), result);
                }));
            }
        }

        private void Generate(ValueTypeEntity type, string result)
        {
            RangeEntity range = null;
            if (UseRange)
            {
                range = new RangeEntity { Min = MinRange, Max = MaxRange };
                valueDb.Ranges.Add(range);
            }
            CurrentValue = new ValueEntity { Value = result, Seed = Seed, Step = randomGenerator.Step, Type = type, Range = range };
            valueDb.Values.Add(currentValue);
            ValueHistory.Add(currentValue);
            valueDb.SaveChanges();
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
                            Clipboard.SetText(ResultOfGeneration);
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
