﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            context.SaveChanges();
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

        public IEnumerable<Record> GetRecords(string name)
        {
            var record = from r in context.Records
                         where r.Name.Contains(name)
                         select r;
             
            
            return record;
        }

        public IEnumerable<Record> GetRecords(int day)
        {
            var day1 = DateTime.Today.AddDays(day).Day;
            
            var record = from r in context.Records      
                         where
                    (r.Birthday.Month == DateTime.Today.Month && r.Birthday.Day >= DateTime.Today.Day &&
                    r.Birthday.Day <= day1)
                         select r;
                        
            return record;
        }

        public DateTime Test()
        {
            var dayPlus = DateTime.Today.AddDays(DateTime.Today.AddMonths(1).Day);
            return dayPlus;
        }

        public BindingList<Record> ToBindingList()
        {
            context.Records.Load();
            return context.Records.Local.ToBindingList();
            //context.Records.ToListAsync();
        }
    }
}
