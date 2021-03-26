using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnimalsShelter.DataAccess
{
    public class AnimalsShelterStorageContextFactory : IDesignTimeDbContextFactory<AnimalsShelterStorageContext>
    {
        public AnimalsShelterStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnimalsShelterStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AnimalsShelterStorage;Integrated Security=True");
            return new AnimalsShelterStorageContext(optionsBuilder.Options);
        }
    }
}
