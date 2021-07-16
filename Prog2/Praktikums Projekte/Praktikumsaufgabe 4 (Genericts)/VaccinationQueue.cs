using System;
using System.Collections;

enum VaccCat
{
    eighty,
    seventy,
    sixtyOrLower
}

namespace Praktikumsaufgabe_4__Generics_
{
    class VaccinationQueue<T1, T2> : IEnumerable where T2 : IComparable
    {
        /// <summary>
        /// Wrapper class pointing to the current Person and the next knode
        /// </summary>
        class QElem
        {
            public T2 Prio;
            public T1 currentPerson;
            public QElem nextElem;

            public QElem(T1 current, QElem next, T2 Cat)
            {
                Prio = Cat;
                nextElem = next;
                currentPerson = current;
            }
        }

        private QElem Head { get; set; }
        private QElem Run { get; set; }

        public void RegisterPerson(T1 newPerson, T2 vaccCat)
        {
            QElem newElem = new QElem(newPerson, null, vaccCat);
            // if the Head has a lower prio than the newElem --> Prepend
            if (Head == null || vaccCat.CompareTo(Head.Prio) < 0)
            {
                Prepend(newElem);
                return;
            }
            Append(newElem);
        }

        private void Prepend(QElem elem)
        {
            elem.nextElem = Head;
            Head = elem;
        }

        private void Append(QElem elem)
        {
            Run = Head;
            while (Run.nextElem != null && Run.nextElem.Prio.CompareTo(Head.Prio) == 0)
            {
                Run = Run.nextElem;
            }

            elem.nextElem = Run.nextElem;
            Run.nextElem = elem;
        }
        /// <summary>
        /// Gives Head of the list back und vaccinates him
        /// </summary>
        /// <returns></returns>
        public T1 Vaccinate()
        {
            T1 temp = Head.currentPerson;
            Head = Head.nextElem;
            return temp;
        }
        /// <summary>
        /// Gives an array of vaccinated people back
        /// </summary>
        /// <returns></returns>
        public T1[] VaccinateWholeCat()
        {
            T1[] catArray;
            int count = 0;
            Run = Head;
            // counting all persons in one category
            while (Run.Prio.CompareTo(Head.Prio) == 0 && Run != null)
            {
                count++;
                Run = Run.nextElem;
            }
            catArray = new T1[count];

            Run = Head;
            // adding the persons in the array
            for (int i = 0; i < catArray.Length; i++)
            {
                catArray[i] = Run.currentPerson;
                Run = Run.nextElem;
            }
            // erases the category
            Head = Run;

            return catArray;
        }
        // for iterating in foreach
        public IEnumerator GetEnumerator()
        {
            Run = Head;

            while (Run.nextElem != null)
            {
                yield return Run.currentPerson;
                Run = Run.nextElem;
            }
            yield return Run.currentPerson;
        }

        public override string ToString()
        {
            string allInfo = "";
            try
            {
                Run = Head;
                // if Run.nextElem = null than exeption
                while (Run.nextElem != null)
                {
                    allInfo += Run.currentPerson + "VaccCat: " + Run.Prio + " \n\n";
                    Run = Run.nextElem;
                }
                allInfo += Run.currentPerson + "VaccCat: " + Run.Prio + " \n\n";
            }
            catch (NullReferenceException)
            {
                throw new NoPersonException("No person in the list");
            }
            return allInfo;
        }
    }
    // class for exeption
    class NoPersonException : Exception { public NoPersonException(string message) : base(message) { } }
}
