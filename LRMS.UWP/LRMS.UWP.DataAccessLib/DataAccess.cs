using System;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace LRMS.DataAccessLib
{
    public static class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=local.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS LoginInfo (user_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "username NVARCHAR(15) NULL, " +
                    "password TEXT NULL, " +
                    "registry_date INTEGER, " +
                    "last_login_date INTEGER, " +
                    "login_count INTEGER)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=local.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO LoginInfo VALUES (1, 'admin', '123456', 1571065490, 1571065490, 1);";
                //insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
    }
}
