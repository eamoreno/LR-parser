using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LR1Parser
{
    public static class Tools
    {
        private const string _terminalPattern = "[a-z=]+";
 		private const string _noTerminalPattern = "<[A-Za-z]+'?>";
 		private const string _producePattern = "->";
		private const string _orPattern = "|";
        //private const string _production = "<[A-Za-z]+> *->(<[A-Za-z]+>|[a-z]+| )+(\|(<[A-Za-z]+>|[a-z]+| )+)+";
 
 
        public static string productionPattern(){
            string ret ="";
            ret = string.Format("{0} *{1}({0}|{2}| )+({3}({0}|{2}| )+)+", 
                _noTerminalPattern, _producePattern, _terminalPattern, _orPattern.ToMeta());   
         
            return ret;
        }

        public static string[] GetProductions(string gramar)
        {            
            var production = new List<String>();
            var array = gramar.Split('\n');
            foreach (var prod in array)
            {               
                string pattern = string.Format("{0}|{1}|{2}|{3}", _noTerminalPattern, _terminalPattern, _orPattern.ToMeta(), _producePattern);
                var elements = Regex.Matches(prod, pattern).Cast<Match>().Select(m => m.Value.Trim()).ToArray();
                var prods = GetSubProduction(elements);
                production.AddRange(prods);
            }            
            return production.ToArray<string>();
        }

        public static string Normalization(string[] dato)
        {
            string ret = "";            

            foreach (var linea in dato)
            {               
                 string patern = string.Format("{0}|{1}|{2}|{3}", _noTerminalPattern, _terminalPattern, _orPattern.ToMeta(), _producePattern);
                 var elements = Regex.Matches(linea,patern).Cast<Match>().Select(m => m.Value.Trim()).ToArray();
                 foreach (var elemnt in elements)                 
                     ret = ret + elemnt + " ";                                 
                 ret = ret.Trim();
                 ret = ret + "\n";
            }
            return ret;
        }

        public static string Increases(string gramar)
        {
            string aum = "";

            var produ = Regex.Match(gramar, _noTerminalPattern);
            var prodfirst = produ.ToString().Replace(">", "'>");
            
            aum = prodfirst + " -> " + produ;
            //Queda en Formato <S'> -> <S>
            return aum;
        }

        public static string[] GetSubProduction(string[] elements)
        {
             List<string> retArrray = new List<string>();
             var r = new Regex(_noTerminalPattern);
                if (!r.IsMatch(elements[0]))
                {
                    throw new Exception("Error DE Inicio en Produccion" + elements[0]);
                }

             var first = elements[0];
             var second = elements[1];
             var production = "";
             int inc = 0;
             foreach(var element in elements)
             {
                 if (element.Contains(_orPattern))
                 {
                     retArrray.Add(production);
                     production = "";
                     inc++;
                 }
                 else
                 {
                     if (inc == 0)  //si no a entrado ninguna vez
                         production = production + element;
                     else
                     {                      //si ya entro una vez                      
                         production = first + second + element;
                         inc = 0;
                     }   
                 }                 
             }
             retArrray.Add(production);
             return retArrray.ToArray();
        }

 		public static string[] First(string[] elements, string[] gramar){
 			var firsts = new List<string> ();
 			foreach (var element in elements) {
 				var terminals = First (element, gramar);
 				firsts.AddRange(terminals);
 			}
 			if (!firsts.Any ())
 				firsts.Add ("$");
 			return firsts.Distinct().ToArray();
 		}
 
       /* public static string[] GetProductions(string gramar)
        {
            string productionPatern = productionPattern();
            var productions = Regex.Matches(gramar, productionPatern).Cast<Match>().Select( m => m.Value.Trim()).ToArray();
            return productions;

        }*/       

 		public static string[] First(string element, string[] gramar){
 			var firsts = new List<string> ();
 			if (!string.IsNullOrEmpty(element) && 
 				IsTerminal (element) && 
 				element != "$") {
 				firsts.Add (element.Trim());
 			} else {
 				foreach (var production in gramar) {
 					var elementA = Regex.Split (production, _producePattern).First ().Trim ();
 					if (element == elementA) {
 						var prodFirsts = First (production);
 						firsts.AddRange (prodFirsts);
 					}
 				}
 			}
 			return firsts.Distinct().ToArray();
 		}

        public static bool IsPointAtEnd(string cad)
        {
            bool band = false;

            int tam = cad.Length;
            if (cad[tam - 1] == '.')
                band = true;
            return band;
        }

 		public static string[] First(string production)
        {
 			string patternTerminal1 = string.Format("{0}( )*{1}", _producePattern, _terminalPattern);
			//string patternTerminal2 = string.Format("{1}( )*{0}", _orPattern, _terminalPattern);
			string patternTerminal2 = string.Format("\\|( )*{0}", _terminalPattern);
 
 			var terminal = Regex.Matches (production, patternTerminal1).Cast<Match>().Select(m => m.Value);
 			var terminals = Regex.Matches(production, patternTerminal2).Cast<Match>().Select(m=>m.Value);
 
 			terminal = terminal.Select(t => t.Replace(_producePattern, string.Empty).Trim());
			terminals = terminals.Select(t => t.Replace(_orPattern, string.Empty).Trim());
			terminals = terminals.Select(t => t.Replace("|", string.Empty).Trim());
 
 			var listTerminals = terminal.Union(terminals).ToList();
 			if (!listTerminals.Any ())
 				listTerminals.Add ("$");
 
 			return listTerminals.ToArray();
 		}
 
 		public static string[] GetGama(string elemA, string[] gramar){
 			var gamas = new List<string> ();
 			foreach(var production in gramar){
 				var elementA = Regex.Split(production, _producePattern).First().Trim();
 				if (elementA == elemA) {
 					var prodGamas = GetGama (production).ToList();
 					gamas = gamas.Union(prodGamas).ToList();
 				}
 			}
 			return gamas.ToArray();
 		}
 
 
 		public static string[] GetGama(string production)
        {
 			string patternTerminal1 = string.Format ("{0}( )*({1}|{2}| )+", _producePattern, _terminalPattern, _noTerminalPattern);
			//string patternTerminal2 = string.Format ("{0}( )*({1}|{2}| )+", _orPattern, _terminalPattern, _noTerminalPattern);
			string patternTerminal2 = string.Format ("\\|( )*({0}|{1}| )+", _terminalPattern, _noTerminalPattern);
 
 			var terminal = Regex.Matches (production, patternTerminal1).Cast<Match>().Select(m => m.Value);
 			var terminals = Regex.Matches(production, patternTerminal2).Cast<Match>().Select(m=>m.Value);
 
 			terminal = terminal.Select(t => t.Replace(_producePattern, string.Empty).Trim());
			terminals = terminals.Select(t => t.Replace(_orPattern, string.Empty).Trim());
			terminals = terminals.Select(t => t.Replace("|", string.Empty).Trim());
 
 			var listTerminals = terminal.Union(terminals).ToList();
 			return listTerminals.ToArray();
 		}
 
 		public static string[] GetBeta(string production){
 			string patternBbeta = string.Format ("\\.({0}|{1}| )+", _terminalPattern, _noTerminalPattern);
 			var matchesBbeta = Regex.Matches (production, patternBbeta).Cast<Match>().Select(m=>m.Value);
 			var elementBbeta = matchesBbeta.FirstOrDefault();
 			//			string elementB = null; 
 			//			string beta = null;
 			if(elementBbeta != null){
 				var elements = elementBbeta.Split(' ');
 				if (elements.Count () >= 2) {
 					var betaElements = elements.ToList();
 					betaElements.RemoveAt(0);
 					return betaElements.ToArray();
 				}
 			}
 			return new string[]{};
 		}
 
 
 		public static bool IsTerminal(string element)
 		{
 			return element.All(t => !char.IsUpper(t));
 		}
 
 		//[A -> α.Bβ, a]
 		public static string[] GetElements(string production){
 			string patternElement = string.Format ("{0}'?", _noTerminalPattern);
 			string patternAlpha = string.Format("( )*({0}|{1})?( )*\\.", _noTerminalPattern, _terminalPattern);
 			string patternBbeta = string.Format("\\.({0}|{1}| )+", _noTerminalPattern, _terminalPattern);
 			string aPattern = string.Format (", *({0}|{1}|\\$)?", _noTerminalPattern, _terminalPattern);
 
 			var matches = Regex.Matches(production, patternElement).Cast<Match>().Select(m=>m.Value);
 			var matchesBbeta = Regex.Matches (production, patternBbeta).Cast<Match>().Select(m=>m.Value);
 
 			var elementA = matches.FirstOrDefault();
 			var alpha = Regex.Matches (production, patternAlpha).Cast<Match> ().Select (m => m.Value).FirstOrDefault();
 
 
 			var elementBbeta = matchesBbeta.FirstOrDefault();
 			string elementB = null; 
 			string beta = null;
 			if(elementBbeta != null){
 				var elements = elementBbeta.Split(' ');
 				if (elements.Any ()) {
 					elementB = elements [0];
 				}
 				if (elements.Count () >= 2) {
 					beta = elements[1];
 				}
 			}
 
 			var a = Regex.Matches(production, aPattern).Cast<Match>().Select(m => m.Value).FirstOrDefault();
 
 			if (alpha != null) {
 				alpha = alpha.Replace(".",string.Empty).Trim();
 			}
 			if (elementB != null) {
 				elementB = elementB.Replace (".", string.Empty).Trim();
 			}
 			a = a != null ? 
 				a.Replace (",", string.Empty).Trim() : "$";
 
 			return new []{ elementA, alpha, elementB, beta, a};
 		}
 
 		public static bool ContainsItemsSet(List<string[]> itemsSet, string[] item)
 		{
 			for (var i = 0; i < itemsSet.Count(); i++)
 			{
 				if(AreEqual(itemsSet[i], item))
 					return true;
 			}
 			return false;
 		}
 
 		public static int IndexOfGramar(string[] gramar, string production)
        {
 			for (var i = 0; i < gramar.Count(); i++)
 			{
 				if(production == gramar[i]){
 					return i;
 				}
 			}
 			return -1;
 		}
 
 		public static int IndexOfItemsSet(List<string[]> itemsSet, string[] item)
 		{
 			for (var i = 0; i < itemsSet.Count(); i++)
 			{
 				if(AreEqual(itemsSet[i], item))
 					return i;
 			}
 			return -1;
 		}
 
 		public static bool AreEqual(string[] array1, string[] array2)
 		{
 			if (array1.Count() != array2.Count())
 				return false;
 			for (var i = 0; i < array1.Count(); i++)
 			{
 				if (array1[i] != array2[i])
 					return false;
 			}
 			return true;
 		}
 
 
 		private static bool IsPointOfEnd(string production){
 			if (production.Contains (".,"))
 				return true;
 			return false;
 		}
 
 		public static string MakeProduction(string elementA, string alpha, string x, string beta, string a){
 			var prod = elementA + " " + _producePattern; 
 			if (alpha != null)
 				prod += " " + alpha;
 			if (x != null)
 			{
 				prod += " " + x;
 			}
 			prod += ".";
 			if (beta != null)
 				prod += beta;
 
 			prod += ", " + a;
 			return prod;
 		}
 
 		public static string MakeProduction(string eB, string gama, string b){
 			return string.Format("{0} -> .{1}, {2}", eB, gama, b);
 		}
 
 		public static string[] GetTerminals(string[] gramarGp){
 			var totalTerminals = new List<string> ();
 			foreach(var production in gramarGp){
 				var terminals = Regex.Matches(production, _terminalPattern).Cast<Match>().Select(m => m.Value).Distinct();
 				totalTerminals = totalTerminals.Union(terminals).ToList();
 			}
 			totalTerminals.Add("$");
 			return totalTerminals.ToArray();
 		}
 
 		public static string[] GetNoTerminals(string[] gramarGp){
 			var totalTerminals = new List<string> ();
 			foreach(var production in gramarGp){
 				var terminals = Regex.Matches(production, _noTerminalPattern).Cast<Match>().Select(m => m.Value).Distinct();
 				totalTerminals = totalTerminals.Union(terminals).ToList();
 			}
 			return totalTerminals.ToArray();
 		}
 	}     
}
