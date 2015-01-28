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
        private static string RunPoint(String cadena)
        {
            //cadena = cadena.Replace(" ", "");
            int pospunt = cadena.IndexOf('.');
            int pocoma = cadena.IndexOf(',');
            string recorre = cadena.Substring(pospunt + 1);            
             
            if (pocoma - 1 != pospunt)
            {
                //String dato = cadena.Substring(pos + 1, tam.Length);
                cadena = cadena.Remove(pospunt, recorre.Length).Insert(pospunt, recorre + ".");
            }
            return cadena;
        }

        public static string[] Closure(string[] sI, string[] gramarGp)
        {
            var I = new List<string>(sI);
            for (var i = 0; i < I.Count; i++)
            {
                var elements = GetElements(I[i]);
                var eB = elements[2];
                var beta = elements[3];
                var a = elements[4];
                var aBeta = new[] { beta, a };
                foreach (var gama in GetGama(eB, gramarGp))
                {
                    foreach (var b in First(aBeta, gramarGp))
                    {
                        var prod = eB + " -> ." + gama + ", " + b;
                        I.Add(prod);
                    }
                }
            }
            return I.ToArray();
        }

        public static string[] GoTo(string[] I, string x, string[] gramarGp)
        {
            var j = new List<string>();
            foreach (var prod in I)
            {
                var elements = GetElements(prod);
                var eA = elements[0];
                var alpha = elements[1];
                var eX = elements[2];
                string first = GetFirst(prod);
                var beta = string.Join(" ", GetBeta(prod));
                var a = elements[4];
                if (!string.IsNullOrEmpty(x) && eX == x)
                {
                    //A -> αX.β, a
                    var newElement = MakeProduction(eA, alpha, x, beta, a, first);//RunPoint(prod);
                    j.Add(newElement);
                }
            }
            return Closure(j.ToArray(), gramarGp);
        }

        public static string GetFirst(string cadena)
        {
            string ret = "";

            int posfle = cadena.IndexOf('>');
            int pospunt = cadena.IndexOf('.');
            ret = cadena.Substring(posfle +1, pospunt-posfle-1);
            return ret;
        }

        public static List<string[]> Items(string[] gramarGp)
        {
            var sC = new List<string[]>();
            var n = Closure(new[] { "S' -> .S, $" }, gramarGp);
            sC.Add(n);
            for (var i = 0; i < sC.Count; i++)
            {
                var I = sC[i];
                foreach (var prod in I)
                {
                    var elements = GetElements(prod);
                    var x = elements[2];
                    var itemSet = GoTo(I, x, gramarGp);
                    if (itemSet.Any() && !ContainsItemsSet(sC, itemSet))
                    {
                        sC.Add(itemSet);
                    }
                }
            }
            return sC;
        }

        public static string[] First(string[] elements, string[] gramar)
        {
            var firsts = new List<string>();
            foreach (var element in elements)
            {
                var terminals = First(element, gramar);
                firsts.AddRange(terminals);
            }
            if (!firsts.Any())
                firsts.Add("$");
            return firsts.Distinct().ToArray();
        }

        public static string[] First(string element, string[] gramar)
        {
            var firsts = new List<string>();
            if (!string.IsNullOrEmpty(element) &&
                IsTerminal(element) &&
                element != "$")
            {
                firsts.Add(element.Trim());
            }
            else
            {
                foreach (var production in gramar)
                {
                    var elementA = Regex.Split(production, "->").First().Trim();
                    if (element == elementA)
                    {
                        var prodFirsts = First(production);
                        firsts.AddRange(prodFirsts);
                    }
                }
            }
            return firsts.Distinct().ToArray();
        }

        public static string[] First(string production)
        {
            const string patternTerminal1 = @"->( )*[a-z]+";
            const string patternTerminal2 = @"\|( )*[a-z]+";

            var terminal = Regex.Matches(production, patternTerminal1).Cast<Match>().Select(m => m.Value);
            var terminals = Regex.Matches(production, patternTerminal2).Cast<Match>().Select(m => m.Value);

            terminal = terminal.Select(t => t.Replace("->", string.Empty).Trim());
            terminals = terminals.Select(t => t.Replace("|", string.Empty).Trim());

            var listTerminals = terminal.Union(terminals).ToList();
            if (!listTerminals.Any())
                listTerminals.Add("$");

            return listTerminals.ToArray();
        }

        public static string[] GetGama(string elemA, string[] gramar)
        {
            var gamas = new List<string>();
            foreach (var production in gramar)
            {
                var elementA = Regex.Split(production, "->").First().Trim();
                if (elementA == elemA)
                {
                    var prodGamas = GetGama(production).ToList();
                    gamas = gamas.Union(prodGamas).ToList();
                }
            }
            return gamas.ToArray();
        }

        public static string[] GetGama(string production)
        {
            const string patternTerminal1 = @"->( )*[A-Za-z ]+";
            const string patternTerminal2 = @"\|( )*[A-Za-z ]+";

            var terminal = Regex.Matches(production, patternTerminal1).Cast<Match>().Select(m => m.Value);
            var terminals = Regex.Matches(production, patternTerminal2).Cast<Match>().Select(m => m.Value);

            terminal = terminal.Select(t => t.Replace("->", string.Empty).Trim());
            terminals = terminals.Select(t => t.Replace("|", string.Empty).Trim());

            var listTerminals = terminal.Union(terminals).ToList();
            return listTerminals.ToArray();
        }

        public static string[] GetBeta(string production)
        {
            const string patternBbeta = @"\.[A-Za-z ]+";
            var matchesBbeta = Regex.Matches(production, patternBbeta).Cast<Match>().Select(m => m.Value);

            var elementBbeta = matchesBbeta.FirstOrDefault();
            string elementB = null;
            string beta = null;
            if (elementBbeta != null)
            {
                var elements = elementBbeta.Split(' ');
                if (elements.Count() >= 2)
                {
                    var betaElements = elements.ToList();
                    betaElements.RemoveAt(0);
                    return betaElements.ToArray();
                }
            }
            return new string[] { };
        }


        public static bool IsTerminal(string element)
        {
            return element.All(t => !char.IsUpper(t));
        }

        //[A -> α.Bβ, a]
        public static string[] GetElements(string production)
        {
            const string patternElement = @"[A-Za-z.$]+'?";
            const string patternAlpha = @"( )*[A-Za-z]+( )*\.";
            const string patternBbeta = @"\.[A-Za-z ]+";
            const string aPattern = @",[A-Za-z\/$ ]+";

            var matches = Regex.Matches(production, patternElement).Cast<Match>().Select(m => m.Value);
            var matchesBbeta = Regex.Matches(production, patternBbeta).Cast<Match>().Select(m => m.Value);

            var elementA = matches.FirstOrDefault();
            var alpha = Regex.Matches(production, patternAlpha).Cast<Match>().Select(m => m.Value).FirstOrDefault();


            var elementBbeta = matchesBbeta.FirstOrDefault();
            string elementB = null;
            string beta = null;
            if (elementBbeta != null)
            {
                var elements = elementBbeta.Split(' ');
                if (elements.Any())
                {
                    elementB = elements[0];
                }
                if (elements.Count() >= 2)
                {
                    beta = elements[1];
                }
            }

            var a = Regex.Matches(production, aPattern).Cast<Match>().Select(m => m.Value).FirstOrDefault();

            if (alpha != null)
            {
                alpha = alpha.Replace(".", string.Empty).Trim();
            }
            if (elementB != null)
            {
                elementB = elementB.Replace(".", string.Empty).Trim();
            }
            a = a != null ?
                a.Replace(",", string.Empty).Trim() : "$";

            return new[] { elementA, alpha, elementB, beta, a };
        }

        public static bool ContainsItemsSet(List<string[]> itemsSet, string[] item)
        {
            for (var i = 0; i < itemsSet.Count(); i++)
            {
                if (AreEqual(itemsSet[i], item))
                    return true;
            }
            return false;
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


        private static string MakeProduction(string elementA, string alpha, string x, string beta, string a, string inicio)
        {
            var prod = elementA + " ->";

            if (alpha != null)
                prod += " " + inicio + " ";
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
    }
}
