using System;
using System.Collections;
namespace Übung_8__Schnittstellen_
{
    /// <summary>
    /// Aufgabe b) yield return iterator
    /// </summary>
    class RandomNumber : IEnumerable
    {
        int runs;
        public RandomNumber(int runs)
        {
            this.runs = runs;
        }

        public IEnumerator GetEnumerator()
        {
            Random rnd = new Random();
            for (int i = 0; i < runs; i++)
            {
                yield return rnd.Next(0, 10);
            }
        }
    }
}
