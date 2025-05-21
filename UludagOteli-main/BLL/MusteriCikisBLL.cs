using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class MusteriCikisBLL
    {
        private readonly MusteriCikisDAL _musteriCikisDAL;

        public MusteriCikisBLL()
        {
            _musteriCikisDAL = new MusteriCikisDAL();
        }

        public DataTable TumMusterileriGetir()
        {
            return _musteriCikisDAL.TumMusterileriGetir();
        }

       

        public DataTable MusteriAra(string arama)
        {
            return _musteriCikisDAL.MusteriAra(arama);
        }

        public int MusteriIDGetir(string adSoyad)
        {
            return _musteriCikisDAL.MusteriIDGetir(adSoyad);
        }

        public bool HesapKapat(int musteriID, int odaID)
        {
            bool hesapSonuclandi = _musteriCikisDAL.RezervasyonSil(musteriID);
            if (hesapSonuclandi)
            {
                return _musteriCikisDAL.OdaDurumunuGuncelle(odaID, "Boş");
            }
            return false;
        }
    }
}
