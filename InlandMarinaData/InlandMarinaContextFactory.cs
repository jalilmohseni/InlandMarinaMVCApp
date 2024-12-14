using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InlandMarinaData
{
    public class InlandMarinaContextFactory : IDesignTimeDbContextFactory<InlandMarinaContext>
    {
        public InlandMarinaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InlandMarinaContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=InlandMarina;
                                          Trusted_Connection=True;
                                          Encrypt=False;");

            return new InlandMarinaContext(optionsBuilder.Options);
        }
    }
}
