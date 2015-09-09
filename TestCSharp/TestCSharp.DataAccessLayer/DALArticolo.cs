using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCSharp.BusinessEntity;

namespace TestCSharp.DataAccessLayer
{
    public class DALArticolo
    {

        private List<BEArticolo> _ListaArticoli { get; set; }

        public DALArticolo()
        {
            _ListaArticoli = new List<BEArticolo>();
        }

        public List<BEArticolo> RicercaArticoli()
        {
            List<BEArticolo> result = null;
            try
            {
                result = _ListaArticoli;
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
                _ListaArticoli.Add(articolo);
                result = true;
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
                BEArticolo articoloDaAggiornare = _ListaArticoli.FirstOrDefault(a => a.Id == articolo.Id);
                if (articoloDaAggiornare != null)
                {
                    articoloDaAggiornare.Nome = articolo.Nome;
                    result = true;
                }
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
                BEArticolo articoloDaCancellare = _ListaArticoli.FirstOrDefault(a => a.Id == articolo.Id);
                if (articoloDaCancellare != null)
                {
                    _ListaArticoli.Remove(articoloDaCancellare);
                    result = true;
                }
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
