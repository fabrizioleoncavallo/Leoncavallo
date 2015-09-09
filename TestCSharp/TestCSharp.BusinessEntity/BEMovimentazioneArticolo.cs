using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCSharp.BusinessEntity
{
    [Serializable]
    public class BEMovimentazioneArticolo
    {

        public int Id { get; set; }
        public BEMagazzino MagazzinoPartenza { get; set; }
        public BEMagazzino MagazzinoDestinazione { get; set; }
        public BECausale Causale { get; set; }

        public BEMovimentazioneArticolo()
        {
        }

        public BEMovimentazioneArticolo(int id, BEMagazzino magazzinoPartenza, BEMagazzino magazzinoDestinazione, BECausale causale)
        {
            Id = id;
            MagazzinoPartenza = magazzinoPartenza;
            MagazzinoDestinazione = magazzinoDestinazione;
            Causale = causale;
        }

    }
}
