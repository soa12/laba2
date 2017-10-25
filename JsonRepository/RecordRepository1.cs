using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel;

namespace JsonRepository 
{
    public class RecordRepository1 : IPhoneBookRepository
    {
        private string text;
        //RecordContext context = new RecordContext();
        List<Record> records = new List<Record>(); 

        public void Create(Record r)
        {
            records = GetRecords().ToList();
            records.Add(r);
            JsonConvert.SerializeObject(records);
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
            using (FileStream fs = new FileStream("PhoneBook.json", FileMode.OpenOrCreate))
            text = fs.ToString();
                records = JsonConvert.DeserializeObject<List<Record>>(text);
            return records;
        }

        public IEnumerable<Record> GetRecords(string name)
        {
            using (FileStream fs = new FileStream("PhoneBook.json", FileMode.OpenOrCreate))
                text = fs.ToString();
            records = JsonConvert.DeserializeObject<List<Record>>(text);
            return records;
        }

        public IEnumerable<Record> GetRecords(int day)
        {
            using (FileStream fs = new FileStream("PhoneBook.json", FileMode.OpenOrCreate))
                text = fs.ToString();
            records = JsonConvert.DeserializeObject<List<Record>>(text);
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
