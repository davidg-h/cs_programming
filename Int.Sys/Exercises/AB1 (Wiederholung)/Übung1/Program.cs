using System;

namespace Übung1
{
    public delegate int StudentEvent(string s);
    // Aufgabe 1:
    public delegate void arithmDel(double x, double y);
    class Program
    {
        static void Main(string[] args)
        {
            // arithmDel addDel = Add;
            // arithmDel multDel = Mult;
            // ArithOperation();
            Student s1 = Register("123456");
            System.Console.WriteLine(s1.MatrNr);
            s1.MatrNr = Int32.Parse(Console.ReadLine());
        }

        // Aufgabe 2:
        public static void ArithOperation()
        {
            System.Console.Write("x = ");
            double x = Int32.Parse(Console.ReadLine());
            Console.Write("y = ");
            double y = Int32.Parse(Console.ReadLine());

            // Operatoren
            Console.WriteLine("Operatoren");
            arithmDel operations = Add;
            operations += Mult;
            operations(x, y);

            // Methoden der Klasse Delegate
            Console.WriteLine("Delegate.Combine");
            arithmDel addDel = Add;
            arithmDel multDel = Mult;
            arithmDel combined = (arithmDel)Delegate.Combine(addDel, multDel);
            combined(x, y);

            // Lambda/anonyme Methoden
            Console.WriteLine("Lambda");
            arithmDel operate = (double x, double y) => System.Console.WriteLine(x + y);
            operate += (double x, double y) => System.Console.WriteLine(x * y);
            operate(x, y);
        }
        static void Add(double x, double y) { Console.WriteLine(x + y); }
        static void Mult(double x, double y) { Console.WriteLine(x * y); }

        //  Aufgabe 3:
        public static event StudentEvent Study;

        public static Student Register(string num)
        {
            Study += Student.CheckID;
            return new Student(Study(num));
        }

        internal static int Trigger(string s)
        {
            return Study(s);
        }
    }

    // Aufgabe 3

    public class Student
    {
        private int matrNr;
        public int MatrNr
        {
            set
            {
                if (matrNr == 0)
                {
                    matrNr = value;
                    return;
                }
                matrNr = Program.Trigger(Convert.ToString(value));
            }
            get => matrNr;
        }

        public Student(int nr) { this.MatrNr = nr; }

        internal static int CheckID(string nr)
        {
            while (nr.Length != 6)
            {
                System.Console.WriteLine("MatrNr. has not six digits. Try again!");
                nr = Console.ReadLine();
            }
            return Int32.Parse(nr);
        }
    }
}

