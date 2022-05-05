using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
    
namespace Z33xClient.Models
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options): base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}
