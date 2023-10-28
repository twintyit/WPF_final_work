using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_EX
{
    public class BinarySerialization : IStrategySerialization
    {
        string filePath;
        public BinarySerialization(string filePath)
        {
            this.filePath = filePath;
        }
        public void Serialize(Record record)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Append))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, record);
            }
        }

        public List<Record> Deserialize()
        {
            List<Record> records = new List<Record>();
            using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (stream.Position < stream.Length)
                {
                    records.Add((Record)formatter.Deserialize(stream));
                }
            }
            return records;
        }

        public Record FindRecordById(long id)
        {
            List<Record> records = Deserialize();

            return records.FirstOrDefault(record => record.Id == id);
        }

        public bool RemoveRecordById(long id)
        {
            List<Record> records = Deserialize();
            Record recordToRemove = records.FirstOrDefault(record => record.Id == id);
            if (recordToRemove != null)
            {
                records.Remove(recordToRemove);
                SerializeRecords(records);
                return true;
            }
            return false;
        }

        private void SerializeRecords(List<Record> records)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                foreach (var record in records)
                {
                    formatter.Serialize(stream, record);
                }
            }
        }
    }
}
