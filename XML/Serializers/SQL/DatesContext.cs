using FileXML;
using System.Data.Entity;

namespace SQL
{
    class DatesContext : DbContext
    {
        public DatesContext()
            : base("DbConnection")
        { }

        public DbSet<Dates> Dates { get; set; }
    }
}