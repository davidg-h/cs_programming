using System;

namespace Übung_5
{
    class Stack
    {
        int[] arr;
        bool sorted = false;

        public Stack(int i = 5)
        {
            arr = new int[i];
        }

        public void Push(int number)
        {
            int index = 1;
            while (index <= arr.Length)
            {
                if (arr[arr.Length - index] == 0)
                {
                    arr[arr.Length - index] = number;
                    return;
                }
                index++;
            }

            if (index > arr.Length)
            {
                throw new Exception("Array ist schon voll");
            }
        }

        public int Pop()
        {
            if (!sorted)
            {
                this.Sort();
                sorted = true;
            }
            int top = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            return top;
        }

        private void Sort()
        {
            int nuller = NullCounter();
            int temp;
            int index = 0;
            for (int i = 0; i < arr.Length - nuller; i++, index++)
            {
                while (arr[index] == 0)
                {
                    index++;
                }
                temp = arr[index];
                arr[index] = arr[index - nuller];
                arr[index - nuller] = temp;
            }
        }

        private int NullCounter()
        {
            int nullCounter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    nullCounter++;
                }
            }
            return nullCounter;
        }
        public void Peek()
        {
            if (!sorted)
            {
                this.Sort();
                sorted = true;
            }

            Console.WriteLine(arr[0]);

            /*foreach (var item in arr)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}
