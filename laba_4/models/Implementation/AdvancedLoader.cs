using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4.models.Implementation
{
    public class AdvancedLoader : ILoader
    {
        public int Efficiency { get; } = 8;
        public string Name { get; } = "Advanced Loader";

        public void LoadMaterial(Furnace furnace)
        {
            furnace.Materials -= Efficiency;
            furnace.UseMaterial(Efficiency);
        }
    }
}
