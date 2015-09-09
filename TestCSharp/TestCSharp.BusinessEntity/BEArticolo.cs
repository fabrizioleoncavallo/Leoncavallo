using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCSharp.BusinessEntity
{
    public class BEArticolo
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public BEArticolo()
        {
        }

        public BEArticolo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}
