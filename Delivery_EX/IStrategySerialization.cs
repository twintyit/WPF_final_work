using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    public interface IStrategySerialization
    {
        void Serialize(Record record);
        List<Record> Deserialize();
        Record FindRecordById(long id);
        bool RemoveRecordById(long id);
    }
}
