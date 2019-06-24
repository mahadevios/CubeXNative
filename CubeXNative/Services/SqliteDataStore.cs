


//[assembly: Dependency(typeof(ListDemo.Services.SqliteDataStore))]
using System;
using SQLite;
using System.Threading.Tasks;

namespace CubeXNative
{
    public class SqliteDataStore : ISqliteDataStore<User>
    {
        readonly SQLiteAsyncConnection dataBase;

        public SqliteDataStore(string dbPath)
        {

            dataBase = new SQLiteAsyncConnection(dbPath);
            TableCreateIfExists<User>();


            //TableCreateIfExists<DbSavedJobs>();
            //TableCreateIfExists<DbAppliedJobs>();
            //TableCreateIfExists<DbMassNotification>();
            //TableCreateIfExists<DbNotification>();
            //TableCreateIfExists<DbVideos>();

        }

        public void TableCreateIfExists<T>()
        {
            try
            {
                string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name='" + typeof(T).Name + "'";
                var connection = dataBase.GetConnection();
                var cmd = connection.CreateCommand(cmdText);
                if (cmd.ExecuteScalar<string>() == null)
                {
                    connection.CreateTable<T>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Task<int> SaveUserAsync(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.name))
                {
                    return dataBase.InsertAsync(user);
                }
                return null;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public Task<User> GetUserAsync()
        {
            try
            {
                //return dataBase.Table<BaseUser>().Where(i => i.username == bUser.username).FirstOrDefaultAsync();
                return dataBase.Table<User>().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
    }


}
