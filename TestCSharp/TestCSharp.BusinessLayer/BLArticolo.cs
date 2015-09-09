using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCSharp.BusinessEntity;
using TestCSharp.DataAccessLayer;

namespace TestCSharp.BusinessLayer
{
    public class BLArticolo
    {

        DALArticolo dalArticolo = new DALArticolo();

        public List<BEArticolo> RicercaArticoli()
        {
            List<BEArticolo> result = null;
            try
            {
                result = dalArticolo.RicercaArticoli();
            }
            catch (Exception ex)
            {
                result = null;
                throw ex;
            }
            return result;
        }

        public bool AggiungiArticolo(BEArticolo articolo)
        {
            bool result = false;
            try
            {
                result = dalArticolo.AggiungiArticolo(articolo);
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public bool ModificaArticolo(BEArticolo articolo)
        {
            bool result = false;
            try
            {
                result = dalArticolo.ModificaArticolo(articolo);
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public bool CancellaArticolo(BEArticolo articolo)
        {
            bool result = false;
            try
            {
                result = dalArticolo.CancellaArticolo(articolo);
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
    }
}
