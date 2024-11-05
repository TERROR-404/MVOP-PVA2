using Microsoft.Extensions.Logging;
using System.Data.SQLite;

namespace Priklad3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            string createTableQuery = @"CREATE TABLE IF NOT EXISTS [Osoby] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [Name] VARCHAR(2048) NOT  NULL,
                          [Surname] VARCHAR(2048) NOT NULL,
						  [Birthday] TEXT NOT NULL,
                          [SSN] TEXT NOT NULL
                          )";
            string db = "Db.sqlite";
            string connectionString = "Data Source=" + db + ";Version=3";

            try
            {
                using (SQLiteConnection sqlC = new SQLiteConnection(connectionString))
                {
                    sqlC.Open();
                    using (SQLiteCommand com = new SQLiteCommand(sqlC))
                    {
                        com.CommandText = createTableQuery;
                        com.ExecuteNonQuery();

                        com.CommandText = "INSERT INTO Osoby (Name, Surname, Birthday, SSN) Values ('Bob','Dylan', '1941-05-24', 123456/7890)";
                        int pocetZmenenychRadku = com.ExecuteNonQuery();

                        com.CommandText = "SELECT * FROM Osoby";
                        using (SQLiteDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Label label = new Label();
                                label.Text = ($"({reader["ID"]}):{reader["Name"],-20} {reader["Surname"],-20} \t\tnarozen {reader["Birthday"]} {reader["SSN"]}");
                            }
                        }
                    }
                    sqlC.Close();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"{ex.Source}: {ex.Message}\n");
            }

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
