using Microsoft.EntityFrameworkCore.Design;

namespace DemoApp.Migrator
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            return ContextProvider.GetDbContext();
        }
    }
}