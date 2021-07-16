using System;

namespace Übung_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /// in place doppelt verkette listen
            /*List l1 = new List();

            l1.Append(2); //Head
            l1.Append(1);
            l1.Append(4);
            l1.Append(3); //Last    
            l1.Append(1);

            l1.Print();

            l1.Sort();
            Console.WriteLine();
            l1.Print();

            l1.ReverseList();
            Console.WriteLine();
            l1.Print();*/

            /// Stapel für int
            /*Stack s1 = new Stack();

            s1.Push(1);
            s1.Push(2);
            s1.Push(3);

            s1.Peek();
            Console.WriteLine();
            int x = s1.Pop();
            s1.Peek();
            Console.WriteLine();
            int y = s1.Pop();
            s1.Peek();*/

            /// Warteschlange für int
            Queue q1 = new Queue();

            q1.Enqueue(5);
            q1.Enqueue(3);
            q1.Enqueue(2);
            q1.Enqueue(1);

            q1.Peek();

            q1.Dequeue();
            Console.WriteLine();
            q1.Peek();
        }
    }
}
