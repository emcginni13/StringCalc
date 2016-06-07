using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//NEW
//VERY NEW
namespace Calculator
{
    public class StringCalculator
    {
        public static int Calculate(string numbersToAdd)
        {
            string negatives=null;
            string[] delimArray = new string[4];
            int total = 0;
            string delimitor = ",";
            if (numbersToAdd.Contains("\n"))
            {
               delimitor = "\n";
            }
            if (numbersToAdd == "") { return 0; }
            if (numbersToAdd.StartsWith("//"))
            {
                delimitor = GetCustomDelim(numbersToAdd);
                if (delimitor.Contains("["))
                {
                    int i = 0;
                    var multipleDelimsStrings = delimitor.Split('[');
                    foreach (var s in multipleDelimsStrings)
                    {
                        if (s.Contains("]")) { delimArray[i] = s.Substring(0, s.IndexOf(']')); }
                        i++;
                    }
                    for (var index = 1; index < delimArray.Length; index++)
                    {
                        numbersToAdd = numbersToAdd.Replace(delimArray[index], ",");
                    }
                }
                numbersToAdd = numbersToAdd.Substring(numbersToAdd.IndexOf('\n')+1);             
            }
            
            foreach (var num in GetNumbers(numbersToAdd,delimitor))
            {
                if (int.Parse(num) > 1000) { total = total - int.Parse(num); }
                if (int.Parse(num) < 0) { negatives +=',' + num + " "; } 
                total = total + int.Parse(num);
            }
            if (negatives != null) { throw new ArgumentException("Your calculation included the invalid negative number(s) " + negatives ); }
            return  total;
        }
        public static string[] GetNumbers(string numbersBefore, string delimitor)
        {
            numbersBefore = numbersBefore.Replace(delimitor, ",");
            var numbers = numbersBefore.Split(',');
            return numbers;
        }
        public static string GetCustomDelim(string numbersToAdd)
        {
            var index = numbersToAdd.IndexOf('\n');
            var delimitor = numbersToAdd.Substring(2, index - 2);
            return delimitor;
        }
    }
}
