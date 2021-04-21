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

            Console.Error.WriteLine(lista.Count);

            Console.WriteLine($"2. feladat: Az első tánc neve: {lista[0].tipus}, az utolsó tánc neve pedig: {lista.Last().tipus}");
            Console.WriteLine($"3. feladat: a samba-t táncolók száma: ");

            int sambadb =0;
            foreach (Adat adat in lista)
            {
                if (adat.tipus=="samba")
                {
                    sambadb++;
                }
            }

            Console.WriteLine(sambadb);

            foreach (Adat adat in lista)
            {
                if (adat.lany == "Vilma")
                {
                    Console.WriteLine(adat.tipus);
                }
            }

            Console.WriteLine("Adjon meg egy táncnevet!");
            string usertanc = Console.ReadLine();

            List<Adat> vilmatancai = new List<Adat>();
            foreach (Adat adat in lista)
            {
                if (adat.lany=="Vilma" && adat.tipus=="usertanc")
                {
                    vilmatancai.Add(adat);
                }
            }

            if (vilmatancai.Count > 0)
            {
                foreach (Adat item in vilmatancai) 
                {
                    Console.WriteLine($"A {usertanc} bemutatóján Vilma párja {item.fiu} volt.");
                }
            }
            else
            {
                Console.WriteLine($"Vilma nem táncolt {usertanc} - t.");
            }

        }
    }
}
