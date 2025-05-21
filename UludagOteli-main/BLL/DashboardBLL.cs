using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class DashboardBLL
    {
        private readonly DashboardDAL _dashboardDAL;

        public DashboardBLL()
        {
            _dashboardDAL = new DashboardDAL();
        }

        public int DoluOdaSayisi()
        {
            return _dashboardDAL.DoluOdaSayisi();
        }

        public decimal ToplamGelir()
        {
            return _dashboardDAL.ToplamGelir();
        }

        public int AktifRezervasyonSayisi()
        {
            return _dashboardDAL.AktifRezervasyonSayisi();
        }

        public int SuAndaOteldeKalanSayisi()
        {
            return _dashboardDAL.SuAndaOteldeKalanSayisi();
        }

        public DataTable TumRezervasyonlariGetir()
        {
            return _dashboardDAL.TumRezervasyonlariGetir();
        }

        public DataTable HizliArama(string aramaMetni)
        {
            return _dashboardDAL.HizliArama(aramaMetni);
        }

       
    }
}
