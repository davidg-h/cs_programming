using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aufgabe_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int number;
        string input = "N.I.";

        public int Number { get => number; set => number = value; }
        public string Input { get => input; set => input = value; }

        public Test t { get => new Test(); }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }

    public class NumberInRangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                int number = Int32.Parse((string)value);
                if (number < 0 || number > 360)
                {
                    return new ValidationResult(false, "Zahl nicht zulässig");
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Zahl eingeben.");
            }

            return ValidationResult.ValidResult;
        }
    }

    public class CorrectStringInput : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (input != null)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (Int32.TryParse($"{input[i]}", out int result))
                    {
                        return new ValidationResult(false, "");
                    }
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "");
        }
    }

    public class Test
    {
        public Test()
        {
        }

        public string Name { get => "Number:"; set { Name = value; } }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
