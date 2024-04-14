using System;
using System.Collections.ObjectModel;

namespace laba_1.models
{
    internal class Set<T> : ObservableCollection<T>, ISet<T>
    {
        public Set()
        {
            Values = new T[Capacity];

        }
        private const int INITIAL_CAPACITY = 16;
        private T[] Values;
        private int Capacity = INITIAL_CAPACITY;

        public int Size { get; set; }

        public new bool Add(T value)
        {
            if (Size == Capacity - 1)
            {
                Capacity = (int)Math.Round(Capacity * 1.5);
                T[] newValues = new T[Capacity];
                Array.Copy(Values, 0, newValues, 0, Values.Length);
                Values = newValues;
            }
            if (Contains(value))
            {
                return false;
            }
            Values[Size] = value;
            base.Add(value);
            Size++;
            return true;
        }

        public new void Clear()
        {
            Size = 0;
            Capacity = INITIAL_CAPACITY;
            Values = new T[Capacity];
            base.Clear();
        }

        public new bool Contains(T value)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Values[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public T[] GetValues()
        {
            T[] Result = new T[Size];
            Array.Copy(Values, Result, Size);
            return Result;
        }

        public new bool Remove(T value)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Values[i].Equals(value))
                {
                    for (int j = i; j < Size - 1; j++)
                    {
                        Values[j] = Values[j + 1];
                    }
                    Size--;
                    Values[Size] = default(T);
                    base.Remove(value);
                    return true;
                }
            }
            return false;
        }
    }
}
