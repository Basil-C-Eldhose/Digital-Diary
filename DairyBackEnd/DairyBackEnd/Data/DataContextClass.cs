using DairyBackEnd.Models;
using DiaryBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyBackEnd.Data
{
    public class DataContextClass:DbContext
    {
        public DataContextClass(DbContextOptions<DataContextClass>options): base(options)
        {

        }
        public DbSet<Registration> tblregistration { get; set; }
        public DbSet<Profile> tblprofile { get; set; }

        public DbSet<Entry> tblentry { get; set; }
    }
}
