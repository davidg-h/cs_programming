using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AB_6_Aufgabe_1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student student = new Student("Toom", "B.Sc. Informatik", 23, 123456);
        public Student StudentProp { get => student; set => student = value; }

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = student;

            // --- Code Behind Binding ---
            //Binding nameBinding = new Binding("Name");
            //nameBinding.Source = student;
            //nameTxt.SetBinding(TextBox.TextProperty, nameBinding);

            //Binding matrNrBinding = new Binding("MatrNr");
            //matrNrBinding.Source = student;
            //matrNrTxt.SetBinding(TextBox.TextProperty, matrNrBinding);

            //Binding ageBinding = new Binding("Age");
            //ageBinding.Source = student;
            //ageTxt.SetBinding(TextBox.TextProperty, ageBinding);

            //Binding degreeBinding = new Binding("Degree");
            //degreeBinding.Source = student;
            //degreeTxt.SetBinding(TextBox.TextProperty, degreeBinding);
        }

        private void changeContent(object sender, RoutedEventArgs e)
        {
            student.Age = 21;
            student.MatrNr = 3485692;
            student.Name = "David";
            student.Degree = "B.Sc. Medieninformatik";
        }
    }

    public class Student : INotifyPropertyChanged
    {
        int matrNr, age;
        string name, degree;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }
        public string Degree { get => degree; set { degree = value; OnPropertyChanged("Degree"); } }
        public int MatrNr { get => matrNr; set { matrNr = value; OnPropertyChanged("MatrNr"); } }
        public int Age { get => age; set { age = value; OnPropertyChanged("Age"); } }

        public Student(string name, string degree, int age, int matrNr)
        {
            Name = name;
            Degree = degree;
            Age = age;
            MatrNr = matrNr;
        }

        protected void OnPropertyChanged(string pname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(pname));
            }
        }
    }
}
