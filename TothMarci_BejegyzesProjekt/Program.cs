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
            Console.WriteLine("Melyik tartalmat szeretnéd módosítani? ");
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

        static void TobbMint30()
        {
            bool yn = false;
            foreach (var item in bejegyzes)
            {
                if (item.Likeok > 35)
                {
                    yn = true;
                }    
                if (yn == false)
                {
                    Console.WriteLine("Nincs olyan bejegyzés ami több likeot kapott mint 35!");
                }
                else
                {
                    Console.WriteLine("Van olyan bejegyzés ami több likeot kapott mint 35!");
                }
            }
        }
        static void KevesebbMint15()
        {
            int num = 0;
            foreach (var item in bejegyzes)
            {
                if (item.Likeok < 15)
                {
                    num++;
                }
            }
            Console.WriteLine(num + "db bejegyzés rendelkezik kevesebb mint 15 like-al.");
        }

        static void RendEsKi()
        {
            List<Bejegyzes> rendezettLista = bejegyzes.OrderByDescending(o => o.Likeok).ToList();
            foreach (var item in rendezettLista)
            {
                Console.WriteLine(item);
            }
            StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt");
            for (int i = 0; i < rendezettLista.Count; i++)
            {
                sw.WriteLine($"{rendezettLista[i].Szerzo},{rendezettLista[i].Tartalom},{rendezettLista[i].Letrejott},{rendezettLista[i].Szerkesztve},{rendezettLista[i].Likeok}");
            }
            sw.Close();
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
            TobbMint30();
            KevesebbMint15();
            RendEsKi();


            //slattttt!!
            Console.ReadKey();
        }
    }
}
