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
        #endregion

        #region Get data
        public static DayModel GetLastDay()
        {
            DayModel OutV = null;
            using (IDbConnection connection = GetDapperConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                OutV = connection.QueryFirstOrDefault<DayModel>($"select * from DAYS ORDER BY Id DESC");
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

                dapperList = connection.Query<ChoreModel>($"SELECT * FROM CHORES").OrderBy(note => note.Id).ToList();
            }

            foreach (ChoreModel choreModel in dapperList)
                OutV.Add(choreModel);

            return OutV;
        }

        public static bool CheckIsChoreDoneToday(int IdChore)
        {
            throw new NotImplementedException();
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
        #endregion
    }
}
