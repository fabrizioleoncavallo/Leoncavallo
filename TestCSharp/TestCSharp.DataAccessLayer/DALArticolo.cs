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
        private int _Id { get; set; }
        private int _IdMovimentazione { get; set; }

        public DALArticolo()
        {
            _ListaArticoli = new List<BEArticolo>();
            _Id = 0;
        }

        public List<BEArticolo> RicercaArticoli(BEArticolo articolo)
        {
            List<BEArticolo> result = null;
            try
            {
                //query di ricerca in like sul nome
                result = (from a in _ListaArticoli
                          where (string.IsNullOrWhiteSpace(articolo.Nome) || a.Nome.ToLower().Contains(articolo.Nome.ToLower()))
                          select a).ToList();
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
                _Id = _Id + 1; //per simulare la sequence del db
                articolo.Id = _Id;
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
                BEArticolo articoloDaAggiornare = _ListaArticoli.SingleOrDefault(a => a.Id == articolo.Id);
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
                BEArticolo articoloDaCancellare = _ListaArticoli.SingleOrDefault(a => a.Id == articolo.Id);
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

        public BEArticolo DettaglioArticolo(BEArticolo articolo)
        {
            BEArticolo result = null;
            try
            {
                result = _ListaArticoli.SingleOrDefault(a => a.Id == articolo.Id);
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
                BEArticolo articoloDaModificare = _ListaArticoli.SingleOrDefault(a => a.Id == articolo.Id);
                if (articoloDaModificare != null)
                {
                    _IdMovimentazione = _IdMovimentazione + 1; //per simulare la sequence del db
                    movimentazione.Id = _IdMovimentazione;
                    articoloDaModificare.Movimentazioni.Add(movimentazione);
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
