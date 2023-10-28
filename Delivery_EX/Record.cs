using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Delivery_EX
{
    [Serializable]
    public class Record
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Lastame { get; set; }
        public string Surname { get; set; }
        public string MobNum { get; set; }

        public string Status { get; set; }

        public string From { get; set; }
        public string To { get; set; }

        public string DeliveryDate { get; set; }

        public Package Package { get; set; }

        public Record()
        {
            Package = new Package();
        }

        public override string ToString()
        {
            return $"Id: {Id} - {Status} - {Name} {Lastame} {Surname} - {MobNum} - {From} {To} Размеры: {Package}";
        }
    }
}
