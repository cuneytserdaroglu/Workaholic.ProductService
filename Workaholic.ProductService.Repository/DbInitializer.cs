using Workaholic.ProductService.Domain;

namespace Workaholic.ProductService.Repository;

public static class DbInitializer
{
    public static void InitializeSqlServer(UdemyUnitTestDBContext context)
    {
        context.Database.EnsureCreated();

       


        context.SaveChanges();
    }
}