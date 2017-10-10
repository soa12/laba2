using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IPhoneBookRepository
    {
        IEnumerable<Record> GetRecords(); 
        void Create(Record r);
        Record Read(int id);
        void Update(Record r);
        void Delete(int id);
        void Save();

        BindingList<Record> ToBindingList();

        DateTime Test();
        IEnumerable<Record> GetRecords(string name);
        IEnumerable<Record> GetRecords(int day);
    }
}
