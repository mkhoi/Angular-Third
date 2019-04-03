namespace WebApi.Models
{
    using System.Data.Entity;
    public class DBContext : DbContext
    {
        public DBContext() : base ("name=conn")
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}