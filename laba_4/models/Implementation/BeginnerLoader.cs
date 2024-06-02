using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4.models.Implementation
{
    public class BeginnerLoader: ILoader
    {
        public int Efficiency { get; } = 2;
        public string Name { get; } = "Beginner Loader";

        public void LoadMaterial(Furnace furnace)
        {
            furnace.Materials -= Efficiency;
            furnace.UseMaterial(Efficiency);
        }
    }
}
