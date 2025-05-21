using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class MusteriDAL
    {
        private readonly DatabaseHelper _dbHelper;

        public MusteriDAL()
        {
            _dbHelper = new DatabaseHelper();
        }

        public DataTable RezervasyonVeMusteriDetaylariGetir()
        {
            string query = @"
              SELECT 
              m.MusteriID, 
              m.Ad,
              m.Soyad,
              m.Telefon, 
              m.TC_Numarasi,
              o.OdaNumarasi,
              r.GirisTarihi,
              r.CikisTarihi,
             
              (o.OdaUcreti * DATEDIFF(r.CikisTarihi, r.GirisTarihi)) AS ToplamTutar
              FROM 
                    Rezervasyonlar r
                INNER JOIN 
                    Musteriler m ON r.MusteriID = m.MusteriID
                INNER JOIN 
                    Odalar o ON r.OdaID = o.OdaID";
            return _dbHelper.ExecuteQuery(query);
        }

        public bool MusteriGuncelle(int musteriID, string ad, string soyad, string telefon, string tC_Numarasi, int odaID, DateTime girisTarihi, DateTime cikisTarihi)
        {
            string query = "UPDATE Musteriler SET Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon, TC_Numarasi = @TC_Numarasi, OdaID = @OdaID, GirisTarihi = @GirisTarihi, CikisTarihi = @CikisTarihi  WHERE MusteriID = @MusteriID";
            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
              new MySqlParameter("@MusteriID", musteriID),
              new MySqlParameter("@Ad", ad),
              new MySqlParameter("@Soyad", soyad),
              new MySqlParameter("@Telefon", telefon),
              new MySqlParameter("@TC_Numarasi", tC_Numarasi ),
              new MySqlParameter("@OdaID", odaID),
               new MySqlParameter("@GirisTarihi", girisTarihi),
              new MySqlParameter("@CikisTarihi", cikisTarihi)
            }) > 0;
        }

        public bool MusteriSil(int musteriID)
        {
            string query = "DELETE FROM Musteriler WHERE MusteriID = @MusteriID";
            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@MusteriID", musteriID)
            }) > 0;
        }
    }
}
