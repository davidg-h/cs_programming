using System;
using System.Collections;

namespace Übung_8__Schnittstellen_
{
    /// <summary>
    /// Aufgabe c)
    /// </summary>
    class RandomNumber2 : IEnumerable
    {
        int runs;
        public RandomNumber2(int runs)
        {
            this.runs = runs;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enum(runs);
        }

        class Enum : IEnumerator
        {
            private int currentRun = 0;
            private int runs;

            // the item / object that gets returned
            public object Current
            {
                get 
                {
                    Random rnd = new Random();
                    return rnd.Next(0, 10);
                }
            }

            public Enum(int runs)
            {
                this.runs = runs;
            }

            public bool MoveNext()
            {
                if (currentRun < runs)
                {
                    currentRun++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                currentRun = 0;
            }
        }
    }
}
