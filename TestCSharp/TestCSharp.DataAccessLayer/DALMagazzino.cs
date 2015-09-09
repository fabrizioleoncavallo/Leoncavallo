using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCSharp.BusinessEntity;

namespace TestCSharp.DataAccessLayer
{
    public class DALMagazzino
    {

        private List<BEMagazzino> _ListaMagazzini { get; set; }
        private int _Id { get; set; }

        public DALMagazzino()
        {
            _ListaMagazzini = new List<BEMagazzino>();
            _Id = 0;
        }

        public List<BEMagazzino> RicercaMagazzini(BEMagazzino magazzino)
        {
            List<BEMagazzino> result = null;
            try
            {
                //query di ricerca in like sul nome
                result = (from a in _ListaMagazzini
                          where (string.IsNullOrWhiteSpace(magazzino.Nome) || a.Nome.ToLower().Contains(magazzino.Nome.ToLower()))
                          select a).ToList();
            }
            catch (Exception ex)
            {
                result = null;
                throw ex;
            }
            return result;
        }

        public bool AggiungiMagazzino(BEMagazzino magazzino)
        {
            bool result = false;
            try
            {
                _Id = _Id + 1; //per simulare la sequence del db
                magazzino.Id = _Id;
                _ListaMagazzini.Add(magazzino);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public bool ModificaMagazzino(BEMagazzino magazzino)
        {
            bool result = false;
            try
            {
                BEMagazzino magazzinoDaAggiornare = _ListaMagazzini.SingleOrDefault(a => a.Id == magazzino.Id);
                if (magazzinoDaAggiornare != null)
                {
                    magazzinoDaAggiornare.Nome = magazzino.Nome;
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

        public bool CancellaMagazzino(BEMagazzino magazzino)
        {
            bool result = false;
            try
            {
                BEMagazzino magazzinoDaCancellare = _ListaMagazzini.SingleOrDefault(a => a.Id == magazzino.Id);
                if (magazzinoDaCancellare != null)
                {
                    _ListaMagazzini.Remove(magazzinoDaCancellare);
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

        public BEMagazzino DettaglioMagazzino(BEMagazzino magazzino)
        {
            BEMagazzino result = null;
            try
            {
                result = _ListaMagazzini.SingleOrDefault(a => a.Id == magazzino.Id);
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
