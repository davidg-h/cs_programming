using System;
using System.Collections.Generic;

namespace Übung_11__Delegates_
{

    class Program
    {
        delegate List<int> FilterCast(List<int> list);
        delegate void ArithmeticOperations(ref double[] array);

        static void Main(string[] args)
        {
            Console.WriteLine("11 a.a)");
            List<int> l1 = new List<int>();
            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
            l1.Add(20);
            l1.Add(-5);

            FilterCast cast = Filter;
            l1 = cast(l1);

            foreach (var item in l1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n11 a.b)");
            OwnMethod.MultiCast filter = new OwnMethod().Cast;

            l1 = filter(ref l1);

            foreach (var item in l1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n11 a.c)");
            double[] array = { 0.1, 2.5, -5.5 };

            ArithmeticOperations operations = AbsoluteValue;
            operations += MultwTwo;
            operations += AddOne;

            operations(ref array);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        // 11 a.a)
        public static List<int> Filter(List<int> list)
        {
            List<int> returnList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0 && list[i] % 2 == 0)
                {
                    returnList.Add(list[i]);
                }
            }
            return returnList;
        }

        // 11 a.c)
        public static void AbsoluteValue(ref double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = -array[i];
                }
            }
        }

        public static void MultwTwo(ref double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * 2;
            }
        }

        public static void AddOne(ref double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] + 1;
            }
        }
    }
    // 11 a.b)
    class OwnMethod
    {
        public delegate List<int> MultiCast(ref List<int> list);

        MultiCast multi = null;
        public MultiCast Cast
        {
            get
            {
                multi += Filter;
                multi += AddNull;
                multi += DoubleValues;
                return multi;
            }
        }

        public static List<int> Filter(ref List<int> list)
        {
            List<int> returnList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0 && list[i] % 2 == 0)
                {
                    returnList.Add(list[i]);
                }
            }

            list = returnList;
            return list;
        }

        public static List<int> AddNull(ref List<int> list)
        {
            List<int> returnList = list;

            returnList.Add(0);

            list = returnList;
            return list;
        }

        public static List<int> DoubleValues(ref List<int> list)
        {
            List<int> returnList = new List<int>();

            foreach (var item in list)
            {
                returnList.Add(item * 2);
            }
            list = returnList;
            return list;
        }
    }
}
