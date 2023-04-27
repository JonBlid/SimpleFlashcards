using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCardApplication.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string databaseFile = Path.Combine(Environment.CurrentDirectory, "FlashCardDatabase.db3");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(databaseFile))
            {
                sqlConnection.CreateTable<T>();
                int rows = sqlConnection.Insert(item);
                if (rows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(databaseFile))
            {
                sqlConnection.CreateTable<T>();
                int rows = sqlConnection.Update(item);
                if (rows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(databaseFile))
            {
                sqlConnection.CreateTable<T>();
                int rows = sqlConnection.Delete(item);
                if (rows > 0)
                    result = true;
            }

            return result;
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T> items;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(databaseFile))
            {
                sqlConnection.CreateTable<T>();
                items = sqlConnection.Table<T>().ToList();
            }

            return items;
        }

    }
}
