using laba_4.models.Implementation;
using laba_4.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4.models.Implementation
{
    public class Loader : ILoader
    {
        public int Efficiency { get; } = 5;
        public string Name { get; } = "Loader";

        public void LoadMaterial(Furnace furnace)
        {
            furnace.Materials -= Efficiency;
            furnace.UseMaterial(Efficiency);
        }
    }
}
