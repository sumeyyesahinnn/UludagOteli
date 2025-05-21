using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class GirisBLL
    {
        private GirisDAL girisDAL = new GirisDAL();

        public bool ValidateYonetici(string kullaniciAdi, string sifre)
        {
            return girisDAL.ValidateYonetici(kullaniciAdi, sifre);
        }

        public bool ValidatePersonel(string kullaniciAdi, string sifre)
        {
            return girisDAL.ValidatePersonel(kullaniciAdi, sifre);
        }
    }
}
