using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;
namespace DataAccess
{
    class RecordContext : DbContext
    {
        public RecordContext() : base("name=PhoneBookConnectionString")
        {
            
        }

        public DbSet<Record> Records { get; set; }
    }
}
