using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class PersonelDAL
    {
        private readonly DatabaseHelper _dbHelper;

        public PersonelDAL()
        {
            _dbHelper = new DatabaseHelper();
        }

        public DataTable TumPersonelleriGetir()
        {
            string query = "SELECT PersonelID, AdSoyad, KullaniciAdi, Sifre, Telefon, TC_Numarası, Gorev FROM Personel";
            return _dbHelper.ExecuteQuery(query);
        }

        public bool PersonelEkle(string adSoyad, string kullaniciAdi, string sifre, string telefon, string tC_Numarası, string gorev)
        {
            string query = "INSERT INTO Personel (AdSoyad, KullaniciAdi, Sifre, Telefon, TC_Numarası, Gorev) VALUES (@AdSoyad, @KullaniciAdi, @Sifre, @Telefon, @TC_Numarası, @Gorev)";
            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@AdSoyad", adSoyad),
                new MySqlParameter("@KullaniciAdi", kullaniciAdi),
                new MySqlParameter("@Sifre", sifre),
                new MySqlParameter("@Telefon", telefon),
                new MySqlParameter("@TC_Numarası", tC_Numarası),
                new MySqlParameter("@Gorev", gorev)
            }) > 0;
        }

        public bool PersonelGuncelle(int personelID, string adSoyad, string kullaniciAdi, string sifre, string telefon, string tC_Numarası, string gorev)
        {
            string query = @"
               UPDATE Personel 
               SET 
                  AdSoyad = @AdSoyad, 
                  KullaniciAdi = @KullaniciAdi, 
                  Sifre = @Sifre, 
                  Telefon = @Telefon, 
                  TC_Numarası = @TC_Numarası, 
                  Gorev = @Gorev
                  WHERE PersonelID = @PersonelID";

            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
              new MySqlParameter("@PersonelID", personelID),
              new MySqlParameter("@AdSoyad", adSoyad),
              new MySqlParameter("@KullaniciAdi", kullaniciAdi),
              new MySqlParameter("@Sifre", sifre),
              new MySqlParameter("@Telefon", telefon),
              new MySqlParameter("@TC_Numarası", tC_Numarası),
              new MySqlParameter("@Gorev", gorev)
            }) > 0;
        }


        public bool PersonelSil(int personelID)
        {
            string query = "DELETE FROM Personel WHERE PersonelID = @PersonelID";
            return _dbHelper.ExecuteNonQuery(query, new MySqlParameter[]
            {
                new MySqlParameter("@PersonelID", personelID)
            }) > 0;
        }
    }
}
