using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace LR1
{
    public class Parser
    {              		
        public static string[] Closure(string[] sI, string[] gramarGp)
        {
			var I = new List<string>(sI);
			for (var i = 0; i < I.Count; i++) {
                var elements = LR1Parser.Tools.GetElements(I[i]);
				var eB = elements [2]; 
				var beta = elements[3];
				var a = elements [4];
				var aBeta = new []{ beta, a };
				foreach (var gama in LR1Parser.Tools.GetGama(eB, gramarGp)){
                    foreach (var b in LR1Parser.Tools.First(aBeta, gramarGp))
                    {

                        var prod = LR1Parser.Tools.MakeProduction(eB, gama, b);
						I.Add(prod);
					}
				}
			}
			return I.ToArray();
		}

		public static string[] GoTo(string[] I, string x, string[] gramarGp){
			var j = new List<string>();
			foreach(var prod in I){
                var elements = LR1Parser.Tools.GetElements(prod);
				var eA = elements[0];
				//var alpha = elements [1];
                var alpha = LR1Parser.Tools.GetAlpha(prod);
			    var eX = elements[2];
                var beta = string.Join(" ", LR1Parser.Tools.GetBeta(prod));
				var a = elements [4];
			    if (!string.IsNullOrEmpty(x) && eX == x)
			    {
			        //A -> αX.β, a
                    var newElement = LR1Parser.Tools.MakeProduction(eA, alpha, x, beta, a);
			        j.Add(newElement);
			    }
			}
            return Closure(j.ToArray(), gramarGp);
		}

        public static List<string[]> Items(string[] gramarGp, ref List<State> lnsc)
        {
            lnsc = new List<State>();
            var sC = new List<string[]>();
            string dato = MakePoint(gramarGp[0] + ", $");
            var n = Closure(new[] { dato }, gramarGp);
            int ava = 0;
            sC.Add(n);
            var Estados = new State { Id = ava, Produc = n, Aristas = new List<Arista>() };
            lnsc.Add(Estados);
            for (var i = 0; i < sC.Count; i++)
            {
                var I = sC[i];
                foreach (var prod in I)
                {
                    var elements = LR1Parser.Tools.GetElements(prod);
                    var x = elements[2];
                    var itemSet = GoTo(I, x, gramarGp);
                    if (itemSet.Any() && !LR1Parser.Tools.ContainsItemsSet(sC, itemSet))
                    {
                        sC.Add(itemSet);                        
                        var NuevosEstados = new State { Id = ++ava, Produc = itemSet, Aristas = new List<Arista>() };
                        lnsc.Add(NuevosEstados);
                        CreaAristas(x, lnsc[i], NuevosEstados);
                    }
                }
            }
            return sC;            
        }    

        public static string MakePoint(string cadena)
        {
            int posfle = cadena.IndexOf("->");
            cadena = cadena.Remove(posfle + 2, 1).Insert(posfle + 2, " .");
            return cadena;
        }        

        public static void CreaAristas(string sigue, State Origen, State Destino)
        {
            Origen.Aristas.Add(new Arista { Id = sigue, Nodo = Destino });
        }

        /*public static ICollection<string[]> Items(string[] gramarGp){
        var sC = new List<string[]>();
        string dato = MakePoint(gramarGp[0] + ", $");
        var n = Closure(new[] { "S' -> .S, $" }, gramarGp);
        sC.Add(n);
        for (var i = 0; i < sC.Count; i++){
            var I = sC[i];
            foreach (var prod in I) {
                var elements = LR1Parser.Tools.GetElements(prod);
                var x = elements [2];
                var itemSet = GoTo(I, x, gramarGp);
                if (itemSet.Any() && !LR1Parser.Tools.ContainsItemsSet(sC, itemSet))
                {
                    sC.Add (itemSet);
                }
            }
        }
        return sC;
    }*/
    }
}
