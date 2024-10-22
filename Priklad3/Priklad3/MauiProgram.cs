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
                          [Name] TEXT  NULL,
                          [Surname] VARCHAR(2048) NOT NULL,
						  [Birthday] TEXT NULL,
                          [SSN] TEXT  NULL
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

                        com.CommandText = "INSERT INTO Osoby (Jmeno, Prijmeni, Narozen) Values ('Bob','Dylan', '1941-05-24')";
                        int pocetZmenenychRadku = com.ExecuteNonQuery();
                        Console.WriteLine($"Počet změněných řádků: {pocetZmenenychRadku}");

                        com.CommandText = "INSERT INTO Osoby (Jmeno, Prijmeni) Values ('Jack','Kerouac')";
                        com.ExecuteNonQuery();

                        com.CommandText = "SELECT * FROM Osoby";
                        using (SQLiteDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"({reader["ID"]}):{reader["Jmeno"],-20} {reader["Prijmeni"],-20} \t\tnarozen {reader["Narozen"]}");
                            }
                        }
                        com.CommandText = "DELETE FROM [Osoby] WHERE [Prijmeni] = 'Dylan'";
                        com.ExecuteNonQuery();

                        com.CommandText = "ALTER TABLE [Osoby] ADD [Vaha] NUMERIC";
                        com.ExecuteNonQuery();

                        com.CommandText = "UPDATE [Osoby] SET [Narozen]='1922-03-22', [Vaha] = 68 WHERE Prijmeni='Kerouac'";
                        com.ExecuteNonQuery();
                        com.CommandText = "INSERT INTO Osoby (Jmeno, Prijmeni, Narozen, Vaha) Values ('Karel', 'Klostermann', '1848-02-14', 86)";
                        com.ExecuteNonQuery();

                        com.CommandText = "DROP TABLE [Osoby]";
                        com.ExecuteNonQuery();
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
