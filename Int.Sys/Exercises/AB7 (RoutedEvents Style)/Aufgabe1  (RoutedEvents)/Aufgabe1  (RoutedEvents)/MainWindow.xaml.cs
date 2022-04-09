using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Aufgabe1___RoutedEvents_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyHandler(object sender, MouseButtonEventArgs e)
        {
            if (sender is Ellipse) Console.WriteLine($"1.{((Ellipse)sender).Name}");
            else if (sender is Rectangle) Console.WriteLine($"1.{((Rectangle)sender).Name}");
            else if (sender is Grid) Console.WriteLine("2.Grid");
            else if (sender is Window) Console.WriteLine("3.Window BubblingEvent");
        }

        private void PreviewMouseWheelHandler(object sender, MouseWheelEventArgs e)
        {
            if (sender is Ellipse) Console.WriteLine($"{((Ellipse)sender).Name} 1");
            else if (sender is Rectangle) Console.WriteLine($"{((Rectangle)sender).Name} 1");
            else if (sender is Grid) Console.WriteLine("Grid ");
            else if (sender is Window) Console.WriteLine("Window TunnelingEvent 3");
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Ellipse) Console.WriteLine($"1.{((Ellipse)sender).Name}");
            else if (sender is Rectangle) Console.WriteLine($"1.{((Rectangle)sender).Name}");
            else if (sender is Grid) Console.WriteLine("2.Grid");
            else if (sender is Window) Console.WriteLine("3.Window BubblingEvent");
        }
    }
}
