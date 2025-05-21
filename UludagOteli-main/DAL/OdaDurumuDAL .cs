using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UludagOteli.DAL
{
    internal class OdaDurumuDAL
    {
        private readonly DatabaseHelper _dbHelper;

        public OdaDurumuDAL()
        {
            _dbHelper = new DatabaseHelper();
        }

        // Tüm odaları getir
        public DataTable TumOdalarGetir()
        {
            string query = "SELECT OdaNumarasi, OdaTipi,OdaDurumu FROM Odalar";
            return _dbHelper.ExecuteQuery(query);
        }

        // Oda durumu güncelle
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
