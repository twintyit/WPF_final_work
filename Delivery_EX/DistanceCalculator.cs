using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    /// <summary>
    /// Класс для имитации 
    /// </summary>
    internal class DistanceCalculator
    {
        private Random random = new Random();
        public string City1 { get; set; }
        public string City2 { get; set; }
        public int CalculateDistanceBetweenCities()
        {
         return random.Next(50, 1000);
        }
    }
}
