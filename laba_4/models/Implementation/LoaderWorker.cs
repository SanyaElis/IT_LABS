using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4.models.Implementation
{
    public class LoaderWorker : Worker
    {
        public LoaderWorker(string name, ILoader loader) : base(name, loader) { }

        public override async void Work(Furnace furnace)
        {
            while (!furnace.IsOverheated)
            {
                if (furnace.Materials > 0)
                {
                    IsWorking = true;
                    Loader.LoadMaterial(furnace);
                }
                else
                {
                    IsWorking = false;
                }

                await Task.Delay(1000);
            }

            IsWorking = false;
        }
    }
}
