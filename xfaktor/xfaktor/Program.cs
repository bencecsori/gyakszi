using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace xfaktor
{
    class Versenyzo
    {
        private int rajtSzam;
        private string nev;
        private string szak;
        private int pontSzam;

        public Versenyzo(int rajtSzam, string nev, string szak)
        {
            this.rajtSzam = rajtSzam;
            this.nev = nev;
            this.szak = szak;
        }

        public void PontotKap(int pont)
        {
            pontSzam += pont;
        }

        public override string ToString()
        {
            return rajtSzam + "\t " + nev + "\t " + szak + "\t " + pontSzam + "pont";
        }

        public int RajtSzam
        { get { return rajtSzam; } }

        public string Nev
        { get { return nev; } }

        public int PontSzam
        { get { return pontSzam; } }

        public string Szak
        { get { return szak; } }
    }

    class VezerloOsztaly
    {
        VezerloOsztaly vezerles = new VezerloOsztaly();
        private List<Versenyzo> versenyzok = new List<Versenyzo>();
        public void Start()
        {
            AdatBevitel();
            Kiiratas("\nRésztvevők:\n");
            Verseny();
            Kiiratas("\nEredmények:\n");

            Eredmenyek();
            Keresesek();
        }
        private void AdatBevitel()
        {
            
            
            Versenyzo versenyzo;
            int sorszam = 1;

            

            StreamReader beolvas = new StreamReader("versenyzok.txt");
            
            
            while (!beolvas.EndOfStream)
            {
                string nev = beolvas.ReadLine();
                string szak = beolvas.ReadLine();

                versenyzo = new Versenyzo(sorszam, nev, szak);

                versenyzok.Append(versenyzo);
                sorszam++;
                            }

            beolvas.Close();


        }

        

        private void Eredmenyek()
        {
            Nyertes();
            Sorrend();
        }

        private int zsuriLetszam = 5;
        private int pontHatar = 10;

        private void Verseny()
        {
            Random random = new Random();
            int pont;
            foreach (Versenyzo versenyzo in versenyzok)
            {
                for (int i = 0; i <= zsuriLetszam ; i++)
                {
                    pont = random.Next(pontHatar);
                    versenyzo.PontotKap(pont);
                }
            }
        }

        private void Kiiratas(string cim)
        {
            Console.WriteLine(cim);
            foreach (Versenyzo s in versenyzok)
            {
                
                Console.WriteLine(s);
            }


        }
        private void Nyertes()
        {
            int max = versenyzok[0].PontSzam;

            foreach (Versenyzo item in versenyzok)
            {
                if (item.PontSzam > max)
                {  max = item.PontSzam; }

            }
            Console.WriteLine("\nA legjobb\n");
            foreach  (Versenyzo item in versenyzok)
            {
                if (item.PontSzam == max)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private void Sorrend()
        {
            Versenyzo temp;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                for (int j = i + 1; j < versenyzok.Count - 1; j++)
                {
                    if (versenyzok[i].PontSzam < versenyzok[j].PontSzam)
                    {
                        temp = versenyzok[i];
                        versenyzok[i] = versenyzok[j];
                        versenyzok[j] = temp;
                    }
                }
            }
            Kiiratas("\nEredmenytabla\n");
            
        }


        private void Keresesek()
        {
            Console.WriteLine("\n Adott szakhoz/nevhez tartozo enekesek keresese\n");
            Console.Write("\nKeres valakit (i/n)");
            char valasz;
            string nev;
            string szak;
            bool vanilyen;
            while (!char.TryParse(Console.ReadLine(), out valasz)) {
                Console.Write("egy karaktert irjon");

            }
            
;

            while (valasz == 'i' || valasz == 'I')
            {
                Console.WriteLine("\n Adott szakhoz/nevhez tartozo enekesek keresese\n");
                Console.Write("\nKeres valakit (s/n)");
                char opcio;
                while (!char.TryParse(Console.ReadLine(), out opcio))
                {
                    Console.Write("egy karaktert irjon");
                    

                }

                
                vanilyen = false;


                if (opcio == 's')
                {
                    Console.Write("\nAdja meg a szakot");
                    
                    szak= Console.ReadLine();


                    
                    foreach (Versenyzo item in versenyzok)
                    {
                        if (item.Szak == szak)
                        {
                            Console.WriteLine(item);
                            vanilyen = true;
                        }
                    }

                    if (!vanilyen)
                    {
                        Console.WriteLine("Errol a szakrol nem indult senki");
                    }

                    Console.Write("\nKeres meg valakit (i/n)");
                    valasz = char.Parse(Console.ReadLine());
                }

                else {
                    Console.Write("\nAdja meg a nevet");

                    nev = Console.ReadLine();
                    foreach (Versenyzo item in versenyzok)
                    {
                        if (item.Nev == nev)
                        {
                            Console.WriteLine(item);
                            vanilyen = true;
                        }
                    }

                    if (!vanilyen)
                    {
                        Console.WriteLine("Errol a szakrol nem indult senki");
                    }

                    Console.Write("\nKeres meg valakit (i/n)");
                    valasz = char.Parse(Console.ReadLine());
                }
            
            }
        }




    }


    }

    class Program
    {
        static void Main(string[] args)
        {
        Console.ReadKey();
    }

    }

