using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class GirisDAL
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        // Yönetici girişini kontrol et
        public bool ValidateYonetici(string kullaniciAdi, string sifre)
        {
            string query = "SELECT COUNT(*) FROM Yonetici WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
            MySqlParameter[] parameters = {
                new MySqlParameter("@KullaniciAdi", kullaniciAdi),
                new MySqlParameter("@Sifre", sifre)
            };

            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
        }

        // Personel girişini kontrol et
        public bool ValidatePersonel(string kullaniciAdi, string sifre)
        {
            string query = "SELECT COUNT(*) FROM Personel WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
            MySqlParameter[] parameters = {
                new MySqlParameter("@KullaniciAdi", kullaniciAdi),
                new MySqlParameter("@Sifre", sifre)
            };

            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
        }
    }
}
