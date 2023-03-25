using Microsoft.Data.Sqlite;

namespace InventoryApp.Database
{
    public class Database
    {
        public SqliteConnection Connection { get; set; }
    }
}