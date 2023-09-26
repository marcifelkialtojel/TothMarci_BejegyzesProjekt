using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TothMarci_BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> bejegyzes = new List<Bejegyzes>();
        static void SzamKer(){
            Console.WriteLine("Kérek egy számot: ");
            int dbSzam = Convert.ToInt32 (Console.ReadLine());
            if (dbSzam >= 0)
            {
                for (int i = 0; i < dbSzam; i++)
                {
                    Bejegyzes1();
                }
            }
            else
            {
                Console.WriteLine("Hibás input (nem valós szám)!");
                SzamKer();
            }
        }

        static void Bejegyzes1()
        {
            Console.WriteLine("Ki volt a szerző?");
            string szerzo = Console.ReadLine();
            Console.WriteLine("Mi a tartalom?");
            string tartalom = Console.ReadLine();
            Bejegyzes b3 = new Bejegyzes(szerzo, tartalom);
            bejegyzes.Add(b3);
            Console.WriteLine(b3);
        }
        static void Beolvas()
        {
            StreamReader sr = new StreamReader("bejegyzesek.csv");
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                string szerzo = adatok[0];
                string tartalom = adatok[1];
                Bejegyzes b = new Bejegyzes(szerzo, tartalom);
                bejegyzes.Add(b);
                Console.WriteLine(b);
            }
        }

        static void Likeolas()
        {
            Random r = new Random();
            for (int i = 0; i < bejegyzes.Count; i++)
            {
                int b = r.Next(0, bejegyzes.Count);
                bejegyzes[b].Like();
            }
        }

        static void ListaT()
        {
            foreach (var item in bejegyzes)
            {
                Console.WriteLine($"{item}");
            }
        }
        static void TartalomModify()
        {
            Console.WriteLine("Add meg a módosítani kívánt tartalmat: ");
            string modTartalom = Console.ReadLine();
            bejegyzes[2].Tartalom = modTartalom;
            Console.WriteLine(bejegyzes[2]);
        }

        static void MostLiked()
        {
            int like = 0;
            foreach (var item in bejegyzes)
            {
                if (item.Likeok > like)
                {
                    like = item.Likeok;
                }
            }
            Console.WriteLine(like);
        }

        static void Main(string[] args)
        {
            
            Bejegyzes a1 = new Bejegyzes("Purk", "Timodi Purk");
            bejegyzes.Add(a1);
            Console.WriteLine(a1);
            Bejegyzes a2 = new Bejegyzes("Nella Vándor", "Büdös Nagy Blunt");
            bejegyzes.Add(a2);
            Console.WriteLine(a2);

            SzamKer();
            Beolvas();
            Likeolas();
            TartalomModify();
            ListaT();
            MostLiked();

            Console.ReadKey();
        }
    }
}
