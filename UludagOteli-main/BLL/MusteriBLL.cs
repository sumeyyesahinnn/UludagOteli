using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class MusteriBLL
    {
        private readonly MusteriDAL _musteriDAL;

        public MusteriBLL()
        {
            _musteriDAL = new MusteriDAL();
        }

        public DataTable RezervasyonVeMusteriDetaylariGetir()
        {
            return _musteriDAL.RezervasyonVeMusteriDetaylariGetir();
        }

        public bool MusteriGuncelle(int musteriID, string ad, string soyad, string telefon, string tC_Numarasi, int odaID, DateTime girisTarihi, DateTime cikisTarihi)
        {
            return _musteriDAL.MusteriGuncelle(musteriID, ad, soyad, telefon, tC_Numarasi, odaID, girisTarihi, cikisTarihi);
        }

        public bool MusteriSil(int musteriID)
        {
            return _musteriDAL.MusteriSil(musteriID);
        }
    }
}
