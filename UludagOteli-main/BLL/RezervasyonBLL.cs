using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class RezervasyonBLL
    {
        private readonly RezervasyonDAL _rezervasyonDAL;

        public RezervasyonBLL()
        {
            _rezervasyonDAL = new RezervasyonDAL();
        }

        

        public decimal ToplamTutarHesapla(DateTime girisTarihi, DateTime cikisTarihi, int odaID)
        {
            int kalinanGun = (cikisTarihi - girisTarihi).Days;
            if (kalinanGun <= 0)
            {
                throw new ArgumentException("Çıkış tarihi, giriş tarihinden sonra olmalıdır.");
            }

            decimal odaUcreti = _rezervasyonDAL.OdaUcretiniGetir(odaID);

            return kalinanGun * odaUcreti;
        }


        public int MusteriEkle(string ad, string soyad, string telefon, string TC_Numarasi, int odaID)
        {
            return _rezervasyonDAL.MusteriEkle(ad, soyad, telefon, TC_Numarasi, odaID);
        }

        public bool RezervasyonKaydet(int musteriID, int odaID, DateTime girisTarihi, DateTime cikisTarihi, decimal toplamTutar, string durum)
        {
            return _rezervasyonDAL.RezervasyonEkle(musteriID, odaID, girisTarihi, cikisTarihi, toplamTutar, durum);
        }

        public int OdaIDGetir(string odaNumarasi)
        {
            return _rezervasyonDAL.OdaIDGetir(odaNumarasi);
        }

        public DataTable OdaTipleriniGetir()
        {
            return _rezervasyonDAL.OdaTipleriniGetir();
        }

        public DataTable BosOdaBilgileriGetir(string odaTipi)
        {
            return _rezervasyonDAL.BosOdaBilgileriGetir(odaTipi);
        }

        public bool OdaDurumunuGuncelle(int odaID, string yeniDurum)
        {
            return _rezervasyonDAL.OdaDurumunuGuncelle(odaID, yeniDurum);
        }

        



    }
}
