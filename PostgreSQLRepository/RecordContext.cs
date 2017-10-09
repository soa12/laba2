using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;

namespace PostgreSQLRepository
{
    class RecordContext : DbContext
    {
        public RecordContext() : base("PostgreSQL")
        {

        }

        public DbSet<Record> Records { get; set; }
    }
}
