using System;

namespace Übung_4
{
    class Network
    {
        public class Device
        {
            //public string data;
            static int counter = 1;

            public int adress;
            public int upload = 0;
            public int download = 0;
            public Device Next;

            public Device(Device next = null)
            {
                adress = counter;
                counter++;
                Next = next;
            }

            public void Print()
            {
                Console.WriteLine($"Gerät mit Adresse {this.adress}: Anzahl  Uploads/Downloads = {this.upload}/{this.download}");
            }
        }

        public Device Head
        {
            get; private set;
        }

        public Device First
        {
            get;
            set;
        }

        /// <summary>
        /// Add new Device with pointer to Head
        /// </summary>
        public void Add()
        {
            if (First == null)
            {
                First = new Device();
                First.Next = First;
                Head = First;
                return;
            }

            Device newElement = new Device(Head);
            First.Next = newElement;
            First = newElement;
        }

        public void AddAfter(int previousAdress)
        {
            Device previous = Find(previousAdress);

            Device current = new Device(previous.Next);
            previous.Next = current;
        }

        public void Remove(int networkAdress)
        {
            if (Head == null)
            {
                throw new ArgumentNullException("Cannot remove null element!");
            }

            Device current = Find(networkAdress);

            Device previous = FindPrevious(current);

            previous.Next = current.Next;
        }

        public Device Find(int adress)
        {
            Device head = Head;

            while (head.adress != adress)
            {
                head = head.Next;
                if (head == Head)
                {
                    //Kein Element mit der Adresse
                    return null;
                }
            }
            return head;
        }

        public Device FindPrevious(Device element)
        {
            Device previous = Head;

            while (previous.Next != element)
            {
                previous = previous.Next;
            }
            return previous;
        }

        public void Print()
        {
            Console.WriteLine("Status des Ringpuffer-Netzwerks:");

            if (Head == null)
            {
                Console.WriteLine("Leer");
                return;
            }
            else
            {
                First = Head;

                while (First.Next != Head)
                {
                    First.Print();
                    First = First.Next;

                    if (First.Next == Head)
                    {
                        First.Print();
                    }
                }
            }
        }
    }
}
