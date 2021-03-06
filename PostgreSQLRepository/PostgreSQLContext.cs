﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;

namespace PostgreSQLRepository
{
    class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<Record> Records { get; set; }
    }
}
