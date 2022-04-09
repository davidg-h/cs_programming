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

namespace AB3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WrapPanel myPanel = new WrapPanel();
            this.AddChild(myPanel);
            TextBox b1 = new TextBox();
            TextBox b2 = new TextBox();
            TextBox b3 = new TextBox();
            TextBox b4 = new TextBox();
            myPanel.Children.Add(b1);
            myPanel.Children.Add(b2);
            myPanel.Children.Add(b3);
            myPanel.Children.Add(b4);
            Binding bind = new Binding("Text");
            bind.Mode = BindingMode.OneWay;
            bind.Source = b1;
            b2.SetBinding(TextBox.TextProperty, bind); 
            bind.Source = b2;
            b3.SetBinding(TextBox.TextProperty, bind);
            bind.Source = b3;
            b4.SetBinding(TextBox.TextProperty, bind);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            slider.Value = 0;
        }
    }
}
