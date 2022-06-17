using System;
using Microsoft.EntityFrameworkCore;

namespace Z33xClient.Models
{
	public class RecordDbContext : DbContext
    {
        public RecordDbContext(DbContextOptions<RecordDbContext> options) : base(options)
        {

        }

        public DbSet<Record> Records { get; set; } = null!;
    }
}

