using System;
using System.Collections.Generic;
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

namespace AB2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid myGrid = new Grid();
        Button b1 = new Button();
        Slider slider = new Slider();
        Label label = new Label();
        public MainWindow()
        {
            InitializeComponent();


            slider.Minimum = 0;
            slider.Maximum = 100;
            slider.IsSnapToTickEnabled = true;
            slider.Margin = new Thickness(50,10,50,0);
            slider.ValueChanged += slider_ValueChanged;

            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Top;
            label.Content = "0";
            label.Width = 75;
            label.Margin = new Thickness(50,30,0,0);

            b1.Content = "Reset";
            b1.Height = 100;
            b1.Width = 200;
            b1.IsEnabled = true;
            b1.ClickMode = ClickMode.Release;
            b1.Focusable = true;
            b1.Click += b1_Click;

            myGrid.Children.Add(label);
            myGrid.Children.Add(b1);
            myGrid.Children.Add(slider);
            this.AddChild(myGrid);
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            slider.Value = 0;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            label.Content = slider.Value.ToString();
        }
    }
}
