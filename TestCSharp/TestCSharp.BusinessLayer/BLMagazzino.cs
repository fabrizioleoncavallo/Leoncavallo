using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCSharp.BusinessEntity;
using TestCSharp.DataAccessLayer;

namespace TestCSharp.BusinessLayer
{
    public class BLMagazzino
    {

        static DALMagazzino dalMagazzino = new DALMagazzino();

        public List<BEMagazzino> RicercaMagazzini(BEMagazzino magazzino)
        {
            List<BEMagazzino> result = null;
            try
            {
                result = dalMagazzino.RicercaMagazzini(magazzino);
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
                result = dalMagazzino.AggiungiMagazzino(magazzino);
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
                result = dalMagazzino.ModificaMagazzino(magazzino);
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
                result = dalMagazzino.CancellaMagazzino(magazzino);
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
                result = dalMagazzino.DettaglioMagazzino(magazzino);
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
