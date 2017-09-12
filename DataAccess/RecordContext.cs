using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataAccess
{
    class RecordContext : DbContext
    {
        public RecordContext() : base("name=RecordConnectionString")
        {
            
        }

        public DbSet Records { get; set; }
    }
}
