using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    internal class VolumetricWeightCalculator
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int CalculateVolumetricWeight()
        {
            double volume = Length * Width * Height;
            double volumetricWeight = volume / 5000;

            return (int)volumetricWeight;
        }
    }
}
