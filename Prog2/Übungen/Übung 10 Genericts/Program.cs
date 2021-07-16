using System;
using System.Collections;
using System.Collections.Generic;

namespace Übung_10__Genericts_
{
    class Stack<T>
    {
        List<T> internalList = new List<T>();
        public void Push(T data)
        {
            internalList.Add(data);
        }

        public T Pop()
        {
            T data = internalList[internalList.Count - 1];
            internalList.Remove(data);
            return data;
        }

        public T Peek()
        {
            return internalList[internalList.Count - 1];
        }

        public void Print()
        {
            for (int i = internalList.Count - 1; !(i < 0); i--)
            {
                Console.WriteLine(internalList[i]);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*int[] a1 = { 1, 2, 1, 3, 5 };
            string[] a2 = { "Auto", "Zeppelin", "Baum", "Zzapelin" };

            int max = Maximum<int, int[]>(a1);
            Console.WriteLine(max);

            string max2 = Maximum<string, string[]>(a2);
            Console.WriteLine(max2);

            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            l.Add(-5);
            l.Add(10);
            Console.WriteLine(Maximum<int, List<int>>(l));*/

            Stack<int> s1 = new Stack<int>();
            s1.Push(3);
            s1.Push(2);
            s1.Push(1);
            s1.Print();
            Console.WriteLine();
            Console.WriteLine(s1.Pop());
            Console.WriteLine();
            s1.Print();
        }

        static T1 Maximum<T1, T2>(T2 structure) where T1 : IComparable where T2 : IEnumerable
        {
            T1 maximum = default;

            foreach (T1 item in structure)
            {
                if (maximum == null)
                {
                    maximum = item;
                }

                if (maximum.CompareTo(item) < 0)
                {
                    maximum = item;
                }
            }
            return maximum;
        }

        /*static T Maximum<T>(params IEnumerable[] list) where T : IComparable
        {
            T maximum = default;

            for (int i = 0; i < list.Length; i++)
            {
                if (maximum.CompareTo((T)list[i]) < 0)
                {
                    maximum = (T)list[i];
                }
            }
            return maximum;
        }*/
    }
}
