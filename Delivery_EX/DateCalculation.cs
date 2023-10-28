using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    public class DateCalculation
    {
        int distation;

        public DateCalculation(int distation)
        {
            this.distation = distation;
        }

        public DateTime GetDateDelivery()
        {
            Random random = new Random();
            int daysToAdd = random.Next(2, 6);
            return DateTime.Now.AddDays(daysToAdd);
        }
    }
}
