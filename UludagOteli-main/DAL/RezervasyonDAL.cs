using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class RezervasyonDAL
    {
        private readonly DatabaseHelper _dbHelper;

        public RezervasyonDAL()
        {
            _dbHelper = new DatabaseHelper();
        }


        public decimal OdaUcretiniGetir(int odaID)
        {
            string query = "SELECT OdaUcreti FROM Odalar WHERE OdaID = @OdaID";

            DataTable result = _dbHelper.ExecuteQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@OdaID", odaID)

            });

            if (result.Rows.Count > 0)
            {
                return Convert.ToDecimal(result.Rows[0]["OdaUcreti"]);
            }

            return 0;
        }

        public int MusteriEkle(string ad, string soyad, string telefon, string TC_Numarasi, int odaID)
        {
            string query = "INSERT INTO Musteriler (Ad, Soyad, Telefon, TC_Numarasi, OdaID) " +
                           "VALUES (@Ad, @Soyad, @Telefon, @TC_Numarasi, @OdaID); SELECT LAST_INSERT_ID();";

            object result = _dbHelper.ExecuteScalar(query, new MySqlParameter[]
            {
                new MySqlParameter("@Ad", ad),
                new MySqlParameter("@Soyad", soyad),
                new MySqlParameter("@Telefon", telefon),
                new MySqlParameter("@TC_Numarasi", TC_Numarasi),
                new MySqlParameter("@OdaID", odaID)

            });

            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool RezervasyonEkle(int musteriID, int odaID, DateTime girisTarihi, DateTime cikisTarihi, decimal toplamTutar, string durum)
        {
            string query = "INSERT INTO Rezervasyonlar (MusteriID, OdaID, GirisTarihi, CikisTarihi, ToplamTutar, Durum) " +
                           "VALUES (@MusteriID, @OdaID, @GirisTarihi, @CikisTarihi, @ToplamTutar, @Durum)";

            int result = _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@MusteriID", musteriID),
                new MySqlParameter("@OdaID", odaID),
                new MySqlParameter("@GirisTarihi", girisTarihi),
                new MySqlParameter("@CikisTarihi", cikisTarihi),
                new MySqlParameter("@ToplamTutar", toplamTutar),
                new MySqlParameter("@Durum", durum)
            });

            return result > 0;
        }

        public int OdaIDGetir(string odaNumarasi)
        {
            string query = "SELECT OdaID FROM Odalar WHERE OdaNumarasi = @OdaNumarasi";

            DataTable result = _dbHelper.ExecuteQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@OdaNumarasi", odaNumarasi)
            });

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["OdaID"]);
            }

            return 0; // Eğer OdaID bulunamazsa 0 döner
        }

        public DataTable OdaTipleriniGetir()
        {
            string query = "SELECT DISTINCT OdaTipi FROM Odalar";

            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable BosOdaBilgileriGetir(string odaTipi)
        {
            string query = "SELECT OdaID, OdaNumarasi, OdaUcreti FROM Odalar WHERE OdaTipi = @OdaTipi AND OdaDurumu = 'Boş'";

            return _dbHelper.ExecuteQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@OdaTipi", odaTipi)
            });
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
