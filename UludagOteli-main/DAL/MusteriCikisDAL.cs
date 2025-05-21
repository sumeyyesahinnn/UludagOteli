using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class MusteriCikisDAL
    {
        private readonly DatabaseHelper _dbHelper;

        public MusteriCikisDAL()
        {
            _dbHelper = new DatabaseHelper();
        }

        public DataTable TumMusterileriGetir()
        {
            string query = @"
                SELECT 
                    m.MusteriID, 
                    m.Ad, 
                    m.Soyad, 
                    r.OdaID, 
                    r.GirisTarihi, 
                    r.CikisTarihi, 
                    r.ToplamTutar 
                FROM Musteriler m
                JOIN Rezervasyonlar r ON m.MusteriID = r.MusteriID";
            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable MusteriAra(string arama)
        {
            string query = @"
                SELECT 
                    m.MusteriID, 
                    m.Ad, 
                    m.Soyad, 
                    r.OdaID, 
                    r.GirisTarihi, 
                    r.CikisTarihi, 
                    r.ToplamTutar 
                FROM Musteriler m
                JOIN Rezervasyonlar r ON m.MusteriID = r.MusteriID
                WHERE m.Ad LIKE @Arama OR m.Soyad LIKE @Arama";
            return _dbHelper.ExecuteQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@Arama", "%" + arama + "%")
            });
        }

        public int MusteriIDGetir(string adSoyad)
        {
            string query = "SELECT MusteriID FROM Musteriler WHERE CONCAT(Ad, ' ', Soyad) = @AdSoyad";
            object result = _dbHelper.ExecuteScalar(query, new MySqlParameter[]
            {
                new MySqlParameter("@AdSoyad", adSoyad)
            });

            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool RezervasyonSil(int musteriID)
        {
            string query = "DELETE FROM Rezervasyonlar WHERE MusteriID = @MusteriID";
            int result = _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@MusteriID", musteriID)
            });
            return result > 0;
        }

        public bool OdaDurumunuGuncelle(int odaID, string yeniDurum)
        {
            string query = "UPDATE Odalar SET OdaDurumu = @OdaDurumu WHERE OdaID = @OdaID";
            int result = _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@OdaDurumu", yeniDurum),
                new MySqlParameter("@OdaID", odaID)
            });
            return result > 0;
        }
    }
}
