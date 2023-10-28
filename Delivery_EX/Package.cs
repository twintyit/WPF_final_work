using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    [Serializable]
    public class Package
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Height}см X {Width}см X {Length}см {Weight}кг";
        }
    }
}
