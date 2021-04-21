using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2021LatinTancok9FSchon
{
    class Program
    {
        class Adat
        {
            public string tipus;
            public string lany;
            public string fiu;
        }

        static void Main(string[] args)
        {
            List<Adat> lista = new List<Adat>();

            using (StreamReader f = new StreamReader("tancrend.txt", Encoding.Default))
            {
                while (!f.EndOfStream)
                {
                    Adat a = new Adat(); 
                    a.tipus = f.ReadLine();
                    a.lany = f.ReadLine();
                    a.fiu = f.ReadLine();
                    lista.Add(a); 
                }
            }

            //Console.Error.WriteLine(lista.Count);

            Console.WriteLine($"2. feladat: Az első tánc neve: {lista[0].tipus}, az utolsó tánc neve pedig: {lista.Last().tipus}");
            Console.Write($"3. feladat: a samba-t táncolók száma: ");

            int sambadb =0;
            foreach (Adat adat in lista)
            {
                if (adat.tipus=="samba")
                {
                    sambadb++;
                }
            }

            Console.WriteLine(sambadb);

            Console.WriteLine(lista.Count(adat => adat.tipus == "samba"));



            Console.WriteLine("4. feladat: Vilma a következő táncokban szerepelt:");

            foreach (Adat adat in lista)
            {
                if (adat.lany == "Vilma")
                {
                    Console.WriteLine(adat.tipus);
                }
            }

            List<Adat> ezekben_tancolt_vilma = lista.Where(adat => adat.lany == "Vilma").ToList();
            List<Adat> ezekben_tancolt_vilma2 = new List<Adat>(lista.Where(adat => adat.lany == "Vilma"));


            Console.WriteLine("Adjon meg egy táncnevet!");
            string usertanc = Console.ReadLine();

            List<Adat> vilmausertancai = new List<Adat>();
            foreach (Adat adat in lista)
            {
                if (adat.lany=="Vilma" && adat.tipus=="usertanc")
                {
                    vilmausertancai.Add(adat);
                }
            }

            if (vilmausertancai.Count > 0)
            {
                foreach (Adat item in vilmausertancai) 
                {
                    Console.WriteLine($"A {usertanc} bemutatóján Vilma párja {item.fiu} volt.");
                }
            }
            else
            {
                Console.WriteLine($"Vilma nem táncolt {usertanc} - t.");
            }

            // {a,b} U {a} = {a,b}
            // "egy elem csak egyszer szerepelhet" / "ki kell szűrni az ismétlődéseket"   -> HALMAZ HashSet

            HashSet<string> lánynevek = new HashSet<string>();
            foreach (Adat adat in lista)
            {
                lánynevek.Add(adat.lany);

            }


            List<string> lánynévlista0 = new List<string>();
            Console.Write("Lányok: ");
            foreach (string lánynév in lánynevek)
            {
                if (lánynév!= lánynevek.Last()) // ez most csak azért működik, mert ez egy HashSet!!!
                {
                    Console.Write(lánynév + ", ");
                };
            }
            Console.WriteLine(lánynevek.Last());

            // ez az ajánlott mo:
            Console.Write("Lányok: ");
            List<string> lánynévlista = lánynevek.ToList();
            for (int i = 0; i < lánynévlista.Count-1; i++)
            {
                Console.Write(lánynévlista[i] + ", ");
            }
            Console.WriteLine(lánynévlista.Last());


            Dictionary<string, int> szótár = new Dictionary<string, int>();

            foreach (Adat adat in lista)
            {
                if (szótár.ContainsKey(adat.fiu))
                {
                    szótár[adat.fiu]++;
                }
                else 
                {
                    szótár[adat.fiu] = 1;
                }
            }

            int maxérték = 0; // maximumkeresésnél a kezdőérték adása veszélyes! lásd: negatív hőmérsékletek közt maximumkeresés!

            // szótár + ciklus kulcsokon
            /**/
            foreach (string kulcs in szótár.Keys)
            {
                if (szótár[kulcs] > maxérték)
                {
                    maxérték = szótár[kulcs];
                }
            }

            foreach (string kulcs in szótár.Keys)
            {
                if (szótár[kulcs] == maxérték)
                {
                    Console.WriteLine(kulcs);
                }
            }
            /**/

            // szótár + ciklus párokon
            /** / 
            foreach (KeyValuePair<string, int> pár in szótár) // foreach (var item szótár) igazából ezt jelenti!
            {
                if (pár.Value>maxérték)
                {
                    maxérték = pár.Value;
                }
            }
            
            foreach (KeyValuePair<string, int> pár in szótár) // foreach (var item szótár) igazából ezt jelenti!
            {
                if (pár.Value==maxérték)
                {
                    Console.WriteLine(pár.Key);
                }
            }            
            /**/


            // szótár + LinQ
            /** / 
            maxérték = szótár.Max(pár => pár.Value);
            foreach (KeyValuePair<string, int> p in szótár.Where(pár => pár.Value == maxérték))
            {
                Console.WriteLine(p.Key);
            }
            /**/


        }
    }
}
