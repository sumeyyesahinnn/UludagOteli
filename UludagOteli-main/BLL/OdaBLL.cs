using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UludagOteli.DAL;

namespace UludagOteli.BLL
{
    internal class OdaBLL
    {
        private readonly OdaDAL _odaDAL;

        public OdaBLL()
        {
            _odaDAL = new OdaDAL();
        }

        public DataTable TumOdalar()
        {
            return _odaDAL.TumOdalar();
        }

        public bool OdaEkle(string odaNumarasi, string odaTipi, string odaDurumu, decimal odaUcreti)
        {
            return _odaDAL.OdaEkle(odaNumarasi, odaTipi, odaDurumu,odaUcreti);
        }

        public bool OdaGuncelle(int odaID, string odaNumarasi, string odaTipi, string yeniDurumu, decimal odaUcreti)
        {
            return _odaDAL.OdaGuncelle(odaID, odaNumarasi, odaTipi, yeniDurumu, odaUcreti);
        }

        public bool OdaSil(int odaID)
        {
            return _odaDAL.OdaSil(odaID);
        }

        public DataTable BosOdalar()
        {
            return _odaDAL.BosOdalar();
        }

    }
}
