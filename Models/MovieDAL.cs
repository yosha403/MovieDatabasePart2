using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistration.Models
{
    public class MovieDAL
    {
        public List<Movie> GetMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return movies;
            }
        }
        public void DeleteMovie(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "delete from movies where id=" + id;
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();
            }
        }
        public Movie GetMovie(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies where id=" +id;
                connect.Open();              
                Movie m = connect.Query<Movie>(sql).First();
                connect.Close();
                return m;
            }
        }
        public void UpdateMovie(Movie m)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "update movies " +
                    $"set title='{m.Title}', genre='{m.Genre}', `year`={m.Year}, runtime={m.RunTime} " +
                    $"where id={m.Id}";

                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();
            }
        }
        public void CreateMovie(Movie m)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "insert into movies " +
                    $"values({m.Id},'{m.Title}','{m.Genre}', {m.Year},{m.RunTime})";
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();
            }
        }
    }
}
