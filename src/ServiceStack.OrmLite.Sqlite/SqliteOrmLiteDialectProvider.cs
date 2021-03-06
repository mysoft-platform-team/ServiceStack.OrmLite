using System.Data;
#if NETSTANDARD2_0
using Microsoft.Data.Sqlite;
#else
using SqliteConnection = System.Data.SQLite.SQLiteConnection;
using SqliteParameter = System.Data.SQLite.SQLiteParameter;
#endif

namespace ServiceStack.OrmLite.Sqlite
{
    public class SqliteOrmLiteDialectProvider : SqliteOrmLiteDialectProviderBase
    {
        public static SqliteOrmLiteDialectProvider Instance = new SqliteOrmLiteDialectProvider();

        protected override IDbConnection CreateConnection(string connectionString)
        {
#if NETSTANDARD2_0
            return new NetStandardSqliteConnection(connectionString);
#else
            return new SqliteConnection(connectionString);
#endif
        }

        public override IDbDataParameter CreateParam()
        {
            return new SqliteParameter();
        }
    }
}