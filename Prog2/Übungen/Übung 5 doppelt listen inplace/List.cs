using System;

namespace Übung_5
{
    class List
    {
        static int count = 0;

        public int Count => count;

        public class Node
        {
            public int data;
            public Node Previous;
            public Node Next;

            public int Data { get { return data; } }

            public Node(int data, Node vorgänger, Node nachfolger)
            {
                this.data = data;
                Previous = vorgänger;
                Next = nachfolger;
                count++;
            }

            public void Print()
            {
                Console.WriteLine(this.Data);
                if (Next != null)
                {
                    Next.Print();
                }
            }
        }

        Node head;
        Node last;

        public Node Head => head;
        public Node Last => last;
        private Node Run;

        public void Append(int data)
        {
            Node newNode = new Node(data, Last, null);

            if (Head == null)
            {
                last = newNode;
                head = newNode;
                return;
            }

            Last.Next = newNode;
            newNode.Previous = Last;
            last = newNode;
        }

        private void Append(Node n)
        {
            Append(n.Data);
        }

        public void Sort()
        {
            bool notCircle1 = false;
            Node stop = null;

            do
            {
                Run = Head;
                Node temp = Head;

                while (!notCircle1 ? (Run != Last) : (Run != stop))
                {
                    if (Run.Data <= temp.Data)
                    {
                        temp = Run;
                    }

                    if (!notCircle1 == false && Run == stop.Previous)
                    {
                        Run = stop;
                    }
                    else
                    {
                        Run = Run.Next;
                    }
                }

                Remove(temp);
                Append(temp);

                if (!notCircle1)
                {
                    stop = Last;
                    notCircle1 = true;
                }

            } while (stop.Previous != null);
        }

        public void ReverseList()
        {
            Node reverse = Last;

            while (reverse.Previous != null)
            {
                Append(reverse.Previous);
                Remove(reverse.Previous);
            }
        }

        private void Remove(Node n)
        {
            if (n == Head)
            {
                Head.Next.Previous = Head.Previous;
                head = Head.Next;
                return;
            }
            Run = Head;

            while (Run.Next != n)
            {
                Run = Run.Next;
            }

            Run.Next = n.Next;
            n.Next.Previous = Run;
            count--;
        }

        public void Print()
        {
            if (Head == null)
            {
                throw new ArgumentNullException("Kein Objekt in der Liste.");
            }
            Head.Print();
        }
    }
}

