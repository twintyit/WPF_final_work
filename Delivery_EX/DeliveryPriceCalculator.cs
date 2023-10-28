using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    internal class DeliveryPriceCalculator
    {
        private const double BasePricePerKm = 0.1;
        private const double PricePerKg = 0.5;

        public double CalculateDeliveryPrice(double weight, double distanceInKm)
        {
            double distancePrice = distanceInKm * BasePricePerKm;
            double weightPrice = weight * PricePerKg;

            return distancePrice + weightPrice;
        }
    }
}
