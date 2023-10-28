using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    public class Serializator
    {
        IStrategySerialization strategy;

        public Serializator(IStrategySerialization strategy)
        {
            this.strategy = strategy;
        }

        public void Serialize(Record record)
        {
            strategy.Serialize(record);
        }
        public List<Record> Deserialize()
        {
            return strategy.Deserialize();
        }
        public Record FindRecordById(long id)
        {
            return strategy.FindRecordById(id);
        }
        public bool RemoveRecordById(long id)
        {
            return strategy.RemoveRecordById(id);
        }
    }
}
