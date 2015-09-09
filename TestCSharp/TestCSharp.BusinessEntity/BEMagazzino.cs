using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCSharp.BusinessEntity
{
    [Serializable]
    public class BEMagazzino
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public BEMagazzino()
        {
        }

        public BEMagazzino(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}
