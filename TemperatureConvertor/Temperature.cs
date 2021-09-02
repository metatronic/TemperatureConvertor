using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TemperatureConvertor
{
    internal class Temperature : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TemperatureCommand celciusToFarenhietCommand = null;
        public ICommand CelciusToFarenhietCommand
        {
            get { return celciusToFarenhietCommand; }
        }
        private TemperatureCommand farenhietToCelciusCommand = null;
        public ICommand FarenhietToCelciusCommand
        {
            get { return farenhietToCelciusCommand; }
        }
        public Temperature()
        {
            celciusToFarenhietCommand = new TemperatureCommand(CelciusToFarenhiet);
            farenhietToCelciusCommand = new TemperatureCommand(FarenhietToCelcius);
        }
        public double TemperatureValue { get; set; }
        private double convertedTemperatureValue;
        public double ConvertedTemperatureValue
        {
            get { return convertedTemperatureValue; }
            set { convertedTemperatureValue = value; PropertyChanged(this, new PropertyChangedEventArgs("ConvertedTemperatureValue")); }
        }
        public void CelciusToFarenhiet(object obj)
        {
            ConvertedTemperatureValue = (TemperatureValue * 9 / 5) + 32;
        }
        public void FarenhietToCelcius(object obj)
        {
            ConvertedTemperatureValue = (TemperatureValue - 32) * 5 / 9;
        }
    }
}
