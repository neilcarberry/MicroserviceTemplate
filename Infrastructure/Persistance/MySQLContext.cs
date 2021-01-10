using Infrastructure.Interfaces;
using MySql.Data.MySqlClient;
using NPoco;

namespace Infrastructure.Persistance
{
    public class MySQLContext : Database, IDatabaseContext
    {
        private readonly IDatabase _database;
        public MySQLContext(string connection) : base(new MySqlConnection(connection), DatabaseType.MySQL)
        {

        }
    }
}