using System;

namespace Example
{
	namespace Tools
	{ 
		class ValueQueue
		{
			// Private datafields:

			private long[] values;

			// Constructor with one parameter:

			public ValueQueue(uint size)
			{
				if (size == 0)
				{
					throw new ArgumentException("Invalid queue size!");
				}

				values = new long[size];
			}

			// Methods:

			public void Add(long value)
			{
				 values[Count++] = value;
			}

			public long Sum()
			{
				long sum = 0;

				foreach (uint value in values)
				{
					sum += value;
				}

				return sum;
			}

			public long Average()
			{
				return Sum() / Count;
			}

			// Read-only properties:

			public bool Full { get { return Count >= values.Length; } }

			// Auto-property:

			public uint Count { get; private set; }

			// Read-only indexer:

			public long this[uint index]
			{ 
				get { return values[index]; }
			}
		}
	}
}