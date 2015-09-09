using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCSharp.BusinessEntity;

namespace TestCSharp.DataAccessLayer
{
    public class DALCausale
    {

        private List<BECausale> _ListaCausali { get; set; }

        public DALCausale()
        {
            _ListaCausali = new List<BECausale>()
                {
                    //lista statica
                    new BECausale(1, "Carico"),
                    new BECausale(2, "Scarico per Furto"),
                    new BECausale(3, "Scarico per Vendita"),
                    new BECausale(4, "Invio ad altro magazzino"),
                };
        }

        public List<BECausale> RicercaCausali(BECausale causale)
        {
            List<BECausale> result = null;
            try
            {
                //query di ricerca in like sul nome
                result = (from a in _ListaCausali
                          where (string.IsNullOrWhiteSpace(causale.Nome) || a.Nome.ToLower().Contains(causale.Nome.ToLower()))
                          select a).ToList();
            }
            catch (Exception ex)
            {
                result = null;
                throw ex;
            }
            return result;
        }

    }
}
