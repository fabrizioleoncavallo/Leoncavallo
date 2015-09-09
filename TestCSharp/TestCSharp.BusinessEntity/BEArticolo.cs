using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCSharp.BusinessEntity
{
    [Serializable]
    public class BEArticolo
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public List<BEMovimentazioneArticolo> Movimentazioni { get; set; }

        public BEArticolo()
        {
            Movimentazioni = new List<BEMovimentazioneArticolo>();
        }

        public BEArticolo(int id, string nome, List<BEMovimentazioneArticolo> movimentazioni)
        {
            Id = id;
            Nome = nome;
            Movimentazioni = movimentazioni;
        }

    }
}
