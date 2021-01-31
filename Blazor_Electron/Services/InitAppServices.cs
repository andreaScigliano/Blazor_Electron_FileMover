using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Electron.Services
{
    public static class InitAppServices
    {
        public static void CreateDatabase()
        {

            string db = "./db.sqlite";
            
            if (!File.Exists(db))
            {
                SQLiteConnection.CreateFile(db);
                SQLiteConnection connection = new SQLiteConnection($"Data Source={db};version=3;");
                connection.Open();
                string query = "CREATE TABLE IF NOT EXISTS Track(name text primary key,path text);" +
                                    "CREATE TABLE IF NOT EXISTS Track_to_track(nameSource text, nameDestination text, PRIMARY key (nameSource, nameDestination) FOREIGN KEY (nameSource) REFERENCES Track(name), FOREIGN KEY (nameDestination) REFERENCES Track(name));" +
                                    "CREATE table if not EXISTS application(id INTEGER PRIMARY key);";
                SQLiteCommand queryExe = new SQLiteCommand(query,connection);
                queryExe.ExecuteNonQuery();
                connection.Close();
                
            }
        }
    }
}
