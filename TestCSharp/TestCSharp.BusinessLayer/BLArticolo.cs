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

        static DALArticolo _dalArticolo = new DALArticolo();

        public List<BEArticolo> RicercaArticoli(BEArticolo articolo)
        {
            List<BEArticolo> result = null;
            try
            {
                result = _dalArticolo.RicercaArticoli(articolo);
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
                result = _dalArticolo.AggiungiArticolo(articolo);
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
                result = _dalArticolo.ModificaArticolo(articolo);
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
                result = _dalArticolo.CancellaArticolo(articolo);
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public BEArticolo DettaglioArticolo(BEArticolo articolo)
        {
            BEArticolo result = null;
            try
            {
                result = _dalArticolo.DettaglioArticolo(articolo);
            }
            catch (Exception ex)
            {
                result = null;
                throw ex;
            }
            return result;
        }

        public bool AggiungiMovimentazione(BEArticolo articolo, BEMovimentazioneArticolo movimentazione)
        {
            bool result = false;
            try
            {
                result = _dalArticolo.AggiungiMovimentazione(articolo, movimentazione);
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
