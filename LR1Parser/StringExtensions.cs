using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR1Parser
{
    public static class StringExtensions
    {
        public static string ToMeta(this string value)
        {
            var regexOperators = new[] { "-", "+", ".", "(", ")", "|", "?", "*" };
            foreach (var regexOp in regexOperators){
                value = value.Replace(regexOp, @"\" + regexOp);
            }
            return value;
        }
    }
}
