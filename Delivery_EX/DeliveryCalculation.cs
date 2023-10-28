using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace Delivery_EX
{
    internal class DeliveryCalculation
    {
        DistanceCalculator dc;
        VolumetricWeightCalculator vw;
        DeliveryPriceCalculator dp;
        DateCalculation dateCalculation;
        int weight;

        public DeliveryCalculation(int length, int width, int height, int weight, string city1, string city2)
        {
            this.weight = weight;
            dc = new DistanceCalculator { City1 = city1, City2 = city2};
            vw = new VolumetricWeightCalculator { Length = length, Height = height, Width = width};
            dp = new DeliveryPriceCalculator();
            dateCalculation = new DateCalculation(dc.CalculateDistanceBetweenCities());

        }
        public double CalculateDelivery()
        {
            int volumetricWeight = vw.CalculateVolumetricWeight();
            int actualWeight = (volumetricWeight > weight) ? volumetricWeight : weight;
            int dist = dc.CalculateDistanceBetweenCities();

            return dp.CalculateDeliveryPrice(actualWeight, dist);
        }

        public DateTime CalculateDateDelivery()
        {
           return dateCalculation.GetDateDelivery();
        }


    }
}
