using laba_4.models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4.models
{
    public interface ILoader
    {
        int Efficiency { get; }
        string Name { get; }
        void LoadMaterial(Furnace furnace);
    }
}
