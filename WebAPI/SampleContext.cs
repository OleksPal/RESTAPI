using System.Data.Entity;

namespace WebAPI
{
    public class SampleContext : DbContext
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\komp\source\repos\WebAPI\WebAPI\Database.mdf;
        Integrated Security=True;MultipleActiveResultSets=true;";

        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public SampleContext() : base(connectionString)
        { }

        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<Shop> Stores { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
    }
}
