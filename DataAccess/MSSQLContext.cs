using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;
namespace DataAccess
{
    class MSSQLContext : DbContext
    {
        public MSSQLContext() : base("SQLServer")
        {
            
        }

        public DbSet<Record> Records { get; set; }
    }
}
