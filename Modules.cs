
using Microsoft.EntityFrameworkCore;

public class Modules : DbContext
{
    public DbSet<Blog_Test> Kdb_Blog_Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseKdbndp("Server=localhost;User ID=SYSTEM;Password=123456;Database=KDBNDP_TESTS;Port=4321");



    public static void TestKdbndp_efcode()
    {
        using (var db = new Modules())
        {
            /* 添加数据 */
            var blogTest = new Blog_Test
            {
                Id = Guid.NewGuid(),
                Ids = Guid.NewGuid(),
                Name = "刘备",
                Sex = true,
                Sexy = true,
                Age = 45,
                Ager = 45,
                Birth = DateTime.Now,
                Birthy = DateTime.Now,
                Money = 1.5f,
                Moneies = 1.5f,
                Pi = 36.25,
                Pis = 36.25,
                State = State.无用,
                States = State.有用
            };
            Console.WriteLine($"Birth Date Kind {blogTest.Birth.Kind}");
            db.Kdb_Blog_Tests.Add(blogTest);
            var count = db.SaveChanges();
            Console.WriteLine("{0} records saved to database", count);
            Console.WriteLine("All blogs in database:");
        }
    }
}

