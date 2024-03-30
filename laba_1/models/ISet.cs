using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_1.models
{
    internal interface ISet<T>
    {
        bool Add(T value);

        bool Remove(T value);

        void Clear();

        bool Contains(T value);

        T[] GetValues();


    }
}
