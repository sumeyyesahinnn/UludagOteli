using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class OdaDAL
    {
        private readonly DatabaseHelper _dbHelper;

        public OdaDAL()
        {
            _dbHelper = new DatabaseHelper();
        }

        public DataTable TumOdalar()
        {
            string query = "SELECT OdaID, OdaNumarasi, OdaTipi, OdaDurumu, OdaUcreti FROM Odalar";
            return _dbHelper.ExecuteQuery(query);
        }

        public bool OdaEkle(string odaNumarasi, string odaTipi, string odaDurumu, decimal odaUcreti)
        {
            string query = "INSERT INTO Odalar (OdaNumarasi, OdaTipi, OdaDurumu, OdaUcreti) VALUES (@OdaNumarasi, @OdaTipi, @OdaDurumu, @OdaUcreti)";
            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@OdaNumarasi", odaNumarasi),
                new MySqlParameter("@OdaTipi", odaTipi),
                new MySqlParameter("@OdaDurumu", odaDurumu),
                new MySqlParameter("@OdaUcreti", odaUcreti)
            }) > 0;
        }

        public bool OdaGuncelle(int odaID, string odaNumarasi, string odaTipi, string odaDurumu, decimal odaUcreti)
        {
            string query = "UPDATE Odalar SET OdaNumarasi = @OdaNumarasi, OdaTipi = @OdaTipi, OdaDurumu = @OdaDurumu, OdaUcreti = @OdaUcreti WHERE OdaID = @OdaID";
            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@OdaID", odaID),
                new MySqlParameter("@OdaNumarasi", odaNumarasi),
                new MySqlParameter("@OdaTipi", odaTipi),
                new MySqlParameter("@OdaDurumu",odaDurumu),
                new MySqlParameter("@OdaUcreti", odaUcreti)
            }) > 0;
        }

        public bool OdaSil(int odaID)
        {
            string query = "DELETE FROM Odalar WHERE OdaID = @OdaID";
            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@OdaID", odaID)
            }) > 0;
        }

        public DataTable BosOdalar()
        {
            string query = "SELECT OdaID, OdaNumarasi FROM Odalar WHERE OdaDurumu = 'Boş'";
            return _dbHelper.ExecuteQuery(query);
        }

    }
}
