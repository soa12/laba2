using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DomainModel;

namespace DataAccess
{
    public class RecordRepository : IPhoneBookRepository
    {
        RecordContext context = new RecordContext();

        public void Create(Record r)
        {
            context.Records.Add(r);
            context.SaveChanges();
        }

        public Record Read(int id)
        {
            return context.Records.Find(id);
        }

        public void Update(Record r)
        {
            context.Entry(r).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var record = context.Records.Find(id);
            if (record != null)
            {
                context.Records.Remove(record);
                context.SaveChanges();
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public IEnumerable<Record> GetRecords()
        {
            return context.Records;
        }  


    }
}
