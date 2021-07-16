using System;
namespace Übung_3
{
    class Vektor
    {
        int x, y, z;

        public Vektor(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vektor operator +(Vektor one, Vektor two)
        {
            return new Vektor(one.x + two.x, one.y + two.y, one.z + two.z);
        }

        public static int operator *(Vektor one, Vektor two)
        {
            return one.x * two.x + one.y * two.y + one.z * two.z;
        }

        public static Vektor operator |(Vektor one, Vektor two)
        {
            int x = one.y * two.z - one.z * two.y;
            int y = one.z * two.x - one.x * two.z;
            int z = one.x * two.y - one.y * two.x;

            return new Vektor(x, y, z);
        }

        public static double operator -(Vektor a)
        {
            return Math.Sqrt(Math.Pow(a.x, 2) + Math.Pow(a.y, 2) + Math.Pow(a.z, 2));
        }

        public void Print()
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
        }
    }
}
