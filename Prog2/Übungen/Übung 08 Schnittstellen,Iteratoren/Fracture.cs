using System;

namespace Übung_8__Schnittstellen_
{
    /// <summary>
    /// Aufgabe a)
    /// </summary>
    class Fracture : IComparable
    {
        double fractureValue;
        public Fracture(double value)
        {
            fractureValue = value;
        }

        public double FractureOut => fractureValue;

        public int CompareTo(object obj)
        {
            Fracture f = obj as Fracture;

            if (this.FractureOut == f.FractureOut)
            {
                return 0;
            }
            if (this.FractureOut > f.FractureOut)
            {
                return 1;
            }
            return -1;
        }

        public override string ToString()
        {
            return $"{FractureOut}";
        }
    }
}
