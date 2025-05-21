using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class OdaDurumuBLL
    {
        private readonly OdaDurumuDAL _odaDurumuDAL;

        public OdaDurumuBLL()
        {
            _odaDurumuDAL = new OdaDurumuDAL();
        }

        // Tüm odaları getir
        public DataTable TumOdalarGetir()
        {
            return _odaDurumuDAL.TumOdalarGetir();
        }

        // Oda durumu güncelle
        public bool OdaDurumunuGuncelle(int odaID, string yeniDurum)
        {
            return _odaDurumuDAL.OdaDurumunuGuncelle(odaID, yeniDurum);
        }
    }
}
