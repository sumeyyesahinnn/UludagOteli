using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class PersonelBLL
    {
        private readonly PersonelDAL _personelDAL;

        public PersonelBLL()
        {
            _personelDAL = new PersonelDAL();
        }

        public DataTable TumPersonelleriGetir()
        {
            return _personelDAL.TumPersonelleriGetir();
        }

        public bool PersonelEkle(string adSoyad, string kullaniciAdi, string sifre, string telefon, string tC_Numarası, string gorev)
        {
            return _personelDAL.PersonelEkle(adSoyad, kullaniciAdi, sifre, telefon, tC_Numarası, gorev);
        }

        public bool PersonelGuncelle(int personelID, string adSoyad, string kullaniciAdi, string sifre, string telefon, string tC_Numarası, string gorev)
        {
            return _personelDAL.PersonelGuncelle(personelID, adSoyad, kullaniciAdi, sifre, telefon, tC_Numarası, gorev);
        }


        public bool PersonelSil(int personelID)
        {
            return _personelDAL.PersonelSil(personelID);
        }
    }
}
