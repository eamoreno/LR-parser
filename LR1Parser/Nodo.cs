using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR1
{
    public class Nodo
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Arista> Aristas { get; set; }
        public string[] Produc { get; set; }
    }
}
