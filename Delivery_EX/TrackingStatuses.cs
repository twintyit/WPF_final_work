using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
   
    internal class TrackingStatuses
    {
        private string[] trackingStatuses = { "В обработке", "Отправлено", "В пути", "Прибыло в город", "Доставлено" };
        Random rand = new Random();

        /// <summary>
        /// генерирует случайный статус
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetStatus(long id)
        {
            return trackingStatuses[rand.Next(0, trackingStatuses.Length)];
        }

       /// <summary>
       /// дает дефолтный статус "В обработке"
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public string GetDefaultStatus(long id)
        {
            return trackingStatuses[0];
        }
    }
}
