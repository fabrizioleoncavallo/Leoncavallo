using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCSharp.BusinessEntity
{
    [Serializable]
    public class BECausale
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public BECausale()
        {
        }

        public BECausale(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}
