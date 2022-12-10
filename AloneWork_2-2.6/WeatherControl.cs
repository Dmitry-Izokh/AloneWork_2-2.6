using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AloneWork_2_2._6
{ 
enum Precipitation
{ 
    sunny,
    cloudy,
    rain,
    snow
}

    class WeatherControl : DependencyObject 
    {
        private string wind_direction;
        private double wind_speed;
        private Precipitation precipitation;        
        
        public string WindDirection { get; set; }

        public double WindSpeed { get; set; }

        public WeatherControl(string winddir, double windspeed, Precipitation precipitation)
        {
            this.WindDirection = winddir;
            this.WindSpeed = windspeed;
            this.precipitation = precipitation;
        }

        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));            
        }

        private static object CoerceTemp(DependencyObject d,object basevalue)
        {
            int v = (int)basevalue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return null;
            }
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if(v>=-50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
