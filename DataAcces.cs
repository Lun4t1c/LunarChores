using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Caliburn.Micro;
using System.Data.SqlClient;

namespace LunarChores
{
    public static class DataAcces
    {
        #region Get connection
        private static IDbConnection GetDapperConnection()
        {
            try
            {
                return new SqlConnection(Properties.Settings.Default.cnstring);
            }
            catch
            {
                System.Windows.MessageBox.Show("Could not connect to database.");
                return null;
            }
        }
        #endregion

        #region Insert data
        public static void InsertNote(NoteModel noteModel)
        {
            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute(
                    "INSERT INTO NOTES(Description, Is_important) VALUES(@desc, @is_important)" ,
                    new { desc = noteModel.Description, is_important = noteModel.Is_important }
                );
            }
        }
        
        public static void InsertChore(ChoreModel choreModel)
        {
            spInsertChore(choreModel);
        }

        public static void InsertStreak(StreakModel streakModel)
        {
            spInsertStreak(streakModel);
        }
        #endregion

        #region Get data
        public static DayModel GetLastDay()
        {
            try
            {
                spCreateNewDay();
            }
            catch { }

            DayModel OutV = null;
            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                OutV = connection.QueryFirstOrDefault<DayModel>($"select * from DAYS ORDER BY day_date DESC");
            }

            return OutV;
        }

        public static BindableCollection<NoteModel> GetAllNotes()
        {
            BindableCollection<NoteModel> OutV = new BindableCollection<NoteModel>();
            List<NoteModel> dapperList = new List<NoteModel>();

            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                dapperList = connection.Query<NoteModel>($"SELECT * FROM NOTES").OrderBy(note => note.Id).ToList();
            }

            foreach (NoteModel noteModel in dapperList)
                OutV.Add(noteModel);

            return OutV;
        }

        public static BindableCollection<ChoreModel> GetAllChores()
        {
            BindableCollection<ChoreModel> OutV = new BindableCollection<ChoreModel>();
            List<ChoreModel> dapperList = new List<ChoreModel>();

            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                dapperList = connection.Query<ChoreModel>($"SELECT * FROM CHORES").OrderBy(chore => chore.Id).ToList();
            }

            foreach (ChoreModel choreModel in dapperList)
                OutV.Add(choreModel);

            return OutV;
        }

        public static BindableCollection<StreakModel> GetAllStreaks()
        {
            BindableCollection<StreakModel> OutV = new BindableCollection<StreakModel>();
            List<StreakModel> dapperList = new List<StreakModel>();

            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                dapperList = connection.Query<StreakModel>($"SELECT * FROM STREAKS").OrderBy(streak => streak.Id).ToList();
            }

            foreach (StreakModel streakModel in dapperList)
                OutV.Add(streakModel);

            return OutV;
        }

        public static bool CheckIsChoreDoneToday(ChoreModel choreModel)
        {
            bool OutV;

            DayModel currentDay = GetLastDay();
            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                OutV = connection.QueryFirstOrDefault<bool>(
                    $"SELECT Is_done " +
                    $"FROM DAY_CHORE " +
                    $"WHERE Id_chore = @idchore AND Id_day = @idday",
                    new { idchore = choreModel.Id, idday = currentDay.Id }
                );
            }

            return OutV;
        }
        #endregion

        #region Update data
        public static void UncheckChore(ChoreModel choreModel)
        {
            DayModel currentDay = GetLastDay();

            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute(
                    "UPDATE DAY_CHORE " +
                    "SET Is_done = 1 " +
                    "WHERE Id_day = @idday AND Id_chore = @idchore",
                    new { idday = currentDay.Id, idchore = choreModel.Id }
                );
            }
        }
        
        public static void ResetStreak(StreakModel streakModel)
        {
            DayModel currentDay = GetLastDay();

            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute(
                    "UPDATE DAY_STREAK " +
                    "SET Is_canceled = 1 " +
                    "WHERE Id_day = @idday AND Id_streak = @idstreak",
                    new { idday = currentDay.Id, idstreak = streakModel.Id }
                );
            }
        }
        #endregion

        #region Stored procedures
        public static void spCreateNewDay()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.cnstring))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateNewDay", conn) { CommandType = CommandType.StoredProcedure })
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void spInsertChore(ChoreModel choreModel)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.cnstring))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertChore", conn) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@chore_name", SqlDbType.NVarChar).Value = choreModel.Name;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void spInsertStreak(StreakModel streakModel)
        {
            Console.WriteLine($"NAME - {streakModel.Name}");
            using (var conn = new SqlConnection(Properties.Settings.Default.cnstring))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertStreak", conn) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@streak_name", SqlDbType.NVarChar).Value = streakModel.Name;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void spDeleteAllProgress()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.cnstring))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteAllProgress", conn) { CommandType = CommandType.StoredProcedure })
                {                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void spDeleteAllData()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.cnstring))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteAllData", conn) { CommandType = CommandType.StoredProcedure })
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
