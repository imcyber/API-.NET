using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace api.data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        { // Usado para criar as migrações

            var connectionstring = "Server=localhost;Port=3306;Database=dbapi;Uid=root;Pwd=Bruno9211";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionstring);
            return new MyContext(optionsBuilder.Options);

        }
    }

}
