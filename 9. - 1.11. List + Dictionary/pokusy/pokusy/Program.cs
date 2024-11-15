using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokusy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> favouriteFoods = new Dictionary<string, string>();
            favouriteFoods["Karel"] = "Buchtičky";
            favouriteFoods["Lojza"] = "Výpečky";
            favouriteFoods["Xaver"] = "Šišky s mákem";
            favouriteFoods["Xénie"] = "Jitrnice";
            favouriteFoods["Androméda"] = "Kebab";

            foreach (KeyValuePair<string, string> kvp in favouriteFoods)
            {
                Console.WriteLine("Oblíbené jídlo studenta " + kvp.Key + " je " +  kvp.Value);
            }
            if (favouriteFoods.ContainsKey("Martin"))
            {
                Console.WriteLine("Je v seznamu a ma oblibene jidlo");
            }
            else
            {
                Console.WriteLine("neni v seznamu, zije z energie vesmiru");
            }
            Console.ReadKey();
        }
    }
}
