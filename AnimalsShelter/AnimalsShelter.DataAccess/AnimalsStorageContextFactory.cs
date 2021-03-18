using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnimalsShelter.DataAccess
{
    class AnimalsStorageContextFactory : IDesignTimeDbContextFactory<AnimalsStorageContext>
    {
        public AnimalsStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnimalsStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AnimalsStorage;Integrated Security=True");
            return new AnimalsStorageContext(optionsBuilder.Options);
        }
    }
}
