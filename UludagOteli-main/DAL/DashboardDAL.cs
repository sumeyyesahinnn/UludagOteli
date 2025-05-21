using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class DashboardDAL
    {
        private readonly DatabaseHelper _dbHelper;

        public DashboardDAL()
        {
            _dbHelper = new DatabaseHelper();
        }

        public int DoluOdaSayisi()
        {
            string query = "SELECT COUNT(*) FROM Rezervasyonlar WHERE CikisTarihi >= CURDATE()";
            return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
        }

        public decimal ToplamGelir()
        {
            string query = @"
                SELECT SUM(DATEDIFF(CikisTarihi, GirisTarihi) * 
                           (SELECT OdaUcreti FROM Odalar WHERE Odalar.OdaID = Rezervasyonlar.OdaID)) 
                FROM Rezervasyonlar";
            return Convert.ToDecimal(_dbHelper.ExecuteScalar(query));
        }

        public int AktifRezervasyonSayisi()
        {
            string query = "SELECT COUNT(*) FROM Rezervasyonlar WHERE Durum = 'Rezervasyon'";
            return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
        }

        public int SuAndaOteldeKalanSayisi()
        {
            string query = "SELECT COUNT(*) FROM Rezervasyonlar WHERE Durum = 'Su Anda Otelde'";
            return Convert.ToInt32(_dbHelper.ExecuteScalar(query));
        }

        public DataTable TumRezervasyonlariGetir()
        {
            string query = @"
                SELECT 
                    r.RezervasyonID, 
                    m.Ad AS MusteriAdi ,
                    m.Soyad AS MusteriSoyadi,
                    m.TC_Numarasi, 
                    r.GirisTarihi, 
                    r.CikisTarihi, 
                    o.OdaNumarasi, 
                    r.Durum
                FROM Rezervasyonlar r
                INNER JOIN Musteriler m ON r.MusteriID = m.MusteriID
                INNER JOIN Odalar o ON r.OdaID = o.OdaID";
            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable HizliArama(string aramaMetni)
        {
            string query = @"
                SELECT 
                    r.RezervasyonID, 
                    m.Ad AS MusteriAdi ,
                    m.Soyad AS MusteriSoyadi,
                    m.TC_Numarasi, 
                    r.GirisTarihi, 
                    r.CikisTarihi, 
                    o.OdaNumarasi, 
                    r.Durum
                FROM 
                   Rezervasyonlar r
                INNER JOIN
                  Musteriler m ON r.MusteriID = m.MusteriID
                INNER JOIN 
                  Odalar o ON r.OdaID = o.OdaID
                WHERE 
                   m.Ad LIKE @Arama OR o.OdaNumarasi LIKE @Arama";
            return _dbHelper.ExecuteQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@Arama", $"%{aramaMetni}%")
            });
        }

        
    }
}
