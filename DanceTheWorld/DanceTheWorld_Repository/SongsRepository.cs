using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanceTheWorld_Data;

namespace DanceTheWorld_Repository
{
    public static class SongsRepository
    {
        public async static Task<Song> Get(int id)
        {
            Song song = null;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureSQLConnectionString"].ConnectionString))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();
                    string cmdText = "SELECT * FROM songs WHERE songID = " + id.ToString();
                    command.CommandText = cmdText;
                    SqlDataReader reader =  await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        song = SelectFromDataReader(reader);
                    }
                    conn.Close();
                }
            }

            return song;
        }

        public async static Task<List<Song>> Get(string startYear, string endYear)
        {
            List<Song> songs = new List<Song>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureSQLConnectionString"].ConnectionString))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();
                    string cmdText = "SELECT * FROM songs";
                    if(!string.IsNullOrWhiteSpace(startYear) || !string.IsNullOrWhiteSpace(endYear))
                    {
                        if(!string.IsNullOrWhiteSpace(startYear))
                        {
                            cmdText += " WHERE year >= " + startYear;
                            if (!string.IsNullOrWhiteSpace(endYear))
                                cmdText += " AND year <= " + endYear;
                        }
                        else if (!string.IsNullOrWhiteSpace(endYear))
                        {
                            cmdText += "WHERE year <= " + endYear;
                        }
                    }
                    command.CommandText = cmdText;
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Song song = SelectFromDataReader(reader);
                        songs.Add(song);
                    }
                    conn.Close();
                }
            }

            return songs;
        }

        private static Song SelectFromDataReader(SqlDataReader reader)
        {
            Song song = new Song();
            song.SongID = (int)(reader["songID"]);
            song.Longitude = (double)reader["longitude"];
            song.Latitude = (double)reader["latitude"];
            song.Danceability = (double)reader["danceability"];
            song.Year = (int)(reader["year"] == DBNull.Value ? 0 : reader["year"]);
            return song;
        }
    }
}
