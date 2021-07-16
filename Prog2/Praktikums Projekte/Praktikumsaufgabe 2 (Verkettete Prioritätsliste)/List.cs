using System;

namespace Praktikumsaufgabe_2__Verkettete_Prioritätsliste_
{
    class PrioListe
    {
        public class LElem
        {
            public string Data;
            public Prioritaet Prio;
            public LElem nextLElem;

            public LElem(string task, Prioritaet prio, LElem next = null)
            {
                Data = task;
                Prio = prio;
                nextLElem = next;
            }

            public void Print()
            {
                Console.WriteLine($"{Prio,7}: {Data}");
            }
        }
        // first element in the list
        private LElem Head { get; set; }
        // variable Run for going through the list
        LElem Run { get; set; }
        /// <summary>
        /// Adds a new LElem in the List
        /// </summary>
        /// <param name="task"></param>
        /// <param name="prio"></param>
        public void Einfuegen(string task, Prioritaet prio = Prioritaet.normal)
        {
            // PrioListe is empty
            if (Head == null)
            {
                Head = new LElem(task, prio);
                // return early pattern; dont have to write an else (link at the end of the .cs)
                return;
            }

            // cases if List not empty
            switch (prio)
            {
                case Prioritaet.top:
                    LElem newElement = new LElem(task, prio);
                    // Prepending the newElement
                    newElement.nextLElem = Head;
                    Head = newElement;
                    break;

                case Prioritaet.hoch:
                case Prioritaet.normal:
                    newElement = new LElem(task, prio);
                    ZwischenEinfuegen(newElement);
                    break;

                case Prioritaet.niedrig:
                    Run = Head;
                    while (Run.nextLElem != null)
                    {
                        Run = Run.nextLElem;
                    }
                    // Appending at the end of the list
                    newElement = new LElem(task, prio);
                    Run.nextLElem = newElement;
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// in case of Priority is high or normal, appending the element at the end of high/normal 
        /// </summary>
        /// <param name="newElement"></param>
        private void ZwischenEinfuegen(LElem newElement)
        {
            Run = Head;
            // conditioned operator: condition ? consequent : alternative
            // if condition is true -> run consequent (for false -> alternative)
            while (newElement.Prio < Prioritaet.normal ? Run.Prio < Prioritaet.normal : Run.Prio <= Prioritaet.normal)
            {
                Run = Run.nextLElem;
                // no normal & no niedrig elements
                if (Run == null)
                {
                    // gets last element in the list
                    Run = FindPrevious(Run);
                    // Appending to the end of the list
                    Run.nextLElem = newElement;
                    return;
                }
            }
            newElement.nextLElem = Run;
            LElem previous = FindPrevious(Run);
            // if Run is the Head element and Run.Prio > newElement.Prio
            if (previous == Run)
            {
                // new Head is assigned
                Head = newElement;
                return;
            }
            previous.nextLElem = newElement;
        }
        /// <summary>
        /// returns the predecessor of the given elem.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private LElem FindPrevious(LElem elem)
        {
            if (elem == Head)
            {
                // There is no predecessor to the first elem. The Head is returned
                return Head;
            }

            LElem previous = Head;

            while (previous.nextLElem != elem)
            {
                previous = previous.nextLElem;
            }
            return previous;
        }
        /// <summary>
        /// writes the task and removes the current one
        /// </summary>
        public void NaechsteAufgabe()
        {
            if (Head == null)
            {
                Console.WriteLine("Keine Aufgaben in der Liste.");
                return;
            }
            // Changing color for fun :D
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,32}", "Nächste Aufgabe in der Liste:");
            Console.ResetColor();
            Head.Print();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{"Diese Aufgabe wird entfernt!",31}");
            Console.ResetColor();
            Remove(Head);
        }
        /// <summary>
        /// removes the given element
        /// </summary>
        /// <param name="element"></param>
        private void Remove(LElem element)
        {
            if (Head == null)
            {
                throw new ArgumentNullException("Cannot remove null element!");
            }

            LElem previous = FindPrevious(element);
            // element is the Head
            if (previous == element)
            {
                Head = element.nextLElem;
                return;
            }
            previous.nextLElem = element.nextLElem;
        }
        
        public void Ausgeben()
        {
            if (Head == null)
            {
                Console.WriteLine("Liste ist leer.");
            }
            else
            {
                Run = Head;
                while (Run != null)
                {
                    Run.Print();
                    Run = Run.nextLElem;
                }
            }
        }
    }
}

/// return early pattern:
/// http://www.itamarweiss.com/personal/2018/02/28/return-early-pattern.html
