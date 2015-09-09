using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCSharp.BusinessEntity;
using TestCSharp.DataAccessLayer;

namespace TestCSharp.BusinessLayer
{
    public class BLCausale
    {

        DALCausale dalCausale = new DALCausale();

        public List<BECausale> RicercaCausali(BECausale causale)
        {
            List<BECausale> result = null;
            try
            {
                result = dalCausale.RicercaCausali(causale);
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
