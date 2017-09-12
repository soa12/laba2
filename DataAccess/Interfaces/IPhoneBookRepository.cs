using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DataAccess.Interfaces
{
    public interface IPhoneBookRepository
    {
        IEnumerable<Record> GetRecords(); 
        void Create(Record r);
        void Read(int id);
        void Update(Record r);
        void Delete(int id);
    }
}
