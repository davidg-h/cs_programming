using System;

namespace Übung_5
{
    class Queue
    {
        int[] arr;

        public Queue(int length = 5)
        {
            arr = new int[length];
        }

        public void Enqueue(int number)
        {
            int indexer = 0;

            while (indexer < arr.Length)
            {
                if (arr[indexer] == 0)
                {
                    arr[indexer] = number;
                    return;
                }
                indexer++;
            }

            if (indexer > arr.Length)
            {
                throw new Exception("Array ist voll");
            }
        }

        public int Dequeue()
        {
            int oldest = arr[0];
            for (int i = 0; i < arr.Length-1; i++)
            {
                arr[i] = arr[i + 1];
            }
            return oldest;
        }

        public void Peek()
        {
            Console.WriteLine(arr[0]);
           /* foreach (var item in arr)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}
