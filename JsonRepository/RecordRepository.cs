using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Newtonsoft.Json;
using System.ComponentModel;

namespace JsonRepository
{
    public class RecordRepository : IPhoneBookRepository
    {
        private string text1;
        //RecordContext context = new RecordContext();
        List<Record> records = new List<Record>();

        
        public void Create(Record r)
        {
            records = GetRecords().ToList();
            records.Add(r);
            var serialise= JsonConvert.SerializeObject(records);
            File.WriteAllText(@"D:\Program Data\PhoneBook.json", serialise);
        }

        public Record Read(int id)
        {
            records = GetRecords().ToList();
            return records.Find(m => m.Id == id);
        }

        public void Update(Record r)
        {

        }
        public void Delete(int id)
        {

        }

        public void Save()
        {

        }
        public IEnumerable<Record> GetRecords()
        {
            //using (FileStream fs = new FileStream(@"D:\Program Data\PhoneBook.json", FileMode.OpenOrCreate))
            //    text = fs.ToString();
            var text = File.ReadAllText(@"D:\Program Data\PhoneBook.json");
            records = JsonConvert.DeserializeObject<List<Record>>(text);
            return records;
        }

        public void Serializable()
        {
            var serialise = JsonConvert.SerializeObject(records);
            File.WriteAllText(@"D:\Program Data\PhoneBook.json", serialise);

        }

        public IEnumerable<Record> GetRecords(string name)
        {
            using (FileStream fs = new FileStream("PhoneBook.json", FileMode.OpenOrCreate))
                text1 = fs.ToString();
            records = JsonConvert.DeserializeObject<List<Record>>(text1);
            return records;
        }

        public IEnumerable<Record> GetRecords(int day)
        {
            using (FileStream fs = new FileStream("PhoneBook.json", FileMode.OpenOrCreate))
                text1 = fs.ToString();
            records = JsonConvert.DeserializeObject<List<Record>>(text1);
            return records;
        }

        //public DateTime Test()
        //{
        //    DateTime d = DateTime.Today;
        //    return d;
        //}

        public BindingList<Record> ToBindingList()
        {
            throw new NotImplementedException();
        }
    }
}
