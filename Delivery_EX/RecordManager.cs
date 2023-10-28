using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Delivery_EX
{
    public class RecordManager
    {
        Serializator serializator;
        TrackingStatuses ts;
        public long currentId { get; set; }

        public RecordManager()
        {
            currentId = long.Parse(File.ReadAllText("currentId.txt"));
            serializator = new Serializator(new BinarySerialization("BazaDanix.bin"));
            ts = new TrackingStatuses();
        }

        public Record GetDataItemById(long id)
        { 
            Record r = serializator.FindRecordById(id);
            
            if (r == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                r.Status = ts.GetStatus(r.Id);
                return r;
            }
        }

        public bool RemoveDataItemById(long id)
        {
            if (id == 0)
                return false;

            Record r = serializator.FindRecordById(id);
            if (r != null)
            { 
                if (serializator.RemoveRecordById(id))
                {
                    return true;
                }
            }
           
            return false;
        }

        public void AddRecord(Record r)
        {
            serializator.Serialize(r);
            currentId++;
        }

        public List<Record> GetRecords()
        {
           return serializator.Deserialize();
        }

        /// <summary>
        /// записывает текущий айди посылки в файл
        /// </summary>
        public void WhriteCurrentId()
        {
            File.WriteAllText("currentId.txt", currentId.ToString());
        }
    }
}
