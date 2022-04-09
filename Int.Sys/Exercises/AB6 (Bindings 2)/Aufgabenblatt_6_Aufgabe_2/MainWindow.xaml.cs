using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataBinding
{
    /// <summary>
    /// Code behind of MainWindow.xaml
    /// 
    /// The code of this particular project is intentionally left incomplete (code-behind as well as XAML).
    /// Missing pieces of code are indicated by markes such as ___1___. The number of comments has been
    /// intentionally reduced.
    /// 
    /// As an exercise, the missing pieces of code should be identified and inserted. Do not add additional
    /// code.
    /// 
    /// The full program should use data bindings in order to display 9876543 in each Label once the button
    /// Change is clicked.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create an instance of class student, whose data will become source of several bindings
        protected MyClass myObject = new MyClass();
        public MyClass MyObject
        {
            get { return myObject; }
            set { myObject = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            Binding myBinding = new Binding("MyField");
            myBinding.Source = MyObject;
            A.SetBinding(Label.ContentProperty, myBinding);

            D.DataContext = this;
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            // Update data, followed by explicit update of binding to the user interface 
            myObject.MyField = 9876543;
        }
    }

    /// <summary>
    /// A primitive representation of a student's properties. Employed in order to illustrate
    /// various approaches to data bindings.
    /// </summary>
    public class MyClass : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor, creates an empty object.
        /// </summary>
        public MyClass()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Translates informations concerning a property values' change into an event.
        /// </summary>
        /// <param name="pname">A string describing the name of the property that has changed.</param>
        protected void RaisePropertyChanged(string pname)
        {
            Console.WriteLine("RAISE " + pname);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pname));
            }
        }

        int _MyField = 708312;
        public int MyField
        {
            set
            {
                _MyField = value;
                RaisePropertyChanged("MyField");
            }
            get
            {
                return _MyField;
            }
        }
    }
}