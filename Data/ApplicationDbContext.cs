
using Microsoft.EntityFrameworkCore;
using technicalExam.Models;

namespace technicalExam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customers> Customers { get;set;}
        public DbSet<TalkToGuests> TalkToGuests { get;set;}
        public DbSet<spokenToGuests> spokenToGuests { get;set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}