using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Allat
{
    internal class Állat
    {

        private string nev;
        private int szuletesiEv;

        private int szepsegPont;
        private int viselkedesiPont;
        private int pontSzam;

        private static int aktualisEv;
        private static int korHatar;

   

        public Állat(string nev, int szuletesiEv)
        {
            this.nev = nev;
            this.szuletesiEv = szuletesiEv;
        }

        public int Kor()
        { return aktualisEv - szuletesiEv; }
       

        public void potozzak(int szepsegPont, int viselkedesiPont)
        { 
            this.szepsegPont = szepsegPont;
            this.viselkedesiPont = viselkedesiPont;
            if (Kor() <= korHatar)
            {
                pontSzam = viselkedesiPont * Kor() + szepsegPont * (korHatar - Kor());
            }
            else
            {
                pontSzam = 0;
            }
        }
        public override string ToString()
        {
            return nev + "pontszama: " + pontSzam + "pont";
        }

        public string Nev
        { 
            get { return nev; }
        }
        public int ViselkedesiPont
        {
            get { return viselkedesiPont; }
        }

        public int PontSzam
        {
            get { return pontSzam; }
        }
        public int SzuletesiEv
        { get { return szuletesiEv; } }

        public int SzepsegPont
        { get { return szepsegPont; } }


        private static void AllatVerseny()
        {
            Állat allat;


            int igazolvanyszam;
            string nev;
            int szulEv;
            int szepseg, viselkedes;
            int veletlenPontHatar = 10;
            Random random = new Random();

            int osszesVerenyzo = 0;
            int osszesPont = 0;
            int legtobbPont = 0;

            Console.WriteLine("Kezdodik a verseny");

            char tovabb = 'i';
            while (tovabb == 'i')
            {

                Console.Write("az allat neve");
                nev = Console.ReadLine();

                Console.Write("az allat igazolvanyszama");
                igazolvanyszam = Console.ReadLine();

                Console.Write("szuletesi eve:");
                while (!int.TryParse(Console.ReadLine(), out szulEv)
                    || szulEv <= 0
                    || szulEv > Állat.aktualisEv)
                {
                    Console.Write("Hibas adat kerem ujra");
                }
                szepseg = random.Next(veletlenPontHatar+1);
                viselkedes = random.Next(veletlenPontHatar + 1);

                allat = new Állat(nev, szulEv);

                allat.potozzak(szepseg, viselkedes);

                Console.WriteLine(allat);

                osszesVerenyzo++;
                osszesPont += allat.pontSzam;
                if (legtobbPont < allat.pontSzam)
                {
                    legtobbPont = allat.pontSzam;
                }

                List<int> allatok = new List<int>();
                
                    for (int i = 0; i < nev.Length; i++)
                    {
                    allatok[i] = nev[i];

                    allatok[i] += 1;
                
                } 

                

                Console.Write("van meg alllat? (i/n)");

                tovabb = char.Parse(Console.ReadLine());

                Console.WriteLine("\nOsszesen" + osszesVerenyzo + "versenyzo volt," +
                    "\nOsszpontszamuk: "+ osszesPont + "pont"
                    + "\n legnagyobb pontszam" + legtobbPont
                    + "\n" + (osszesVerenyzo / osszesPont) + "az atlagpont" );

            }

           
        }

        static void Main(string[] args)
        { 
            int aktEv = 2015, korhatar = 10;
           
            Állat.aktualisEv = aktEv;
            Állat.korHatar = korhatar;

            AllatVerseny();
            Console.ReadKey();
        }
    }
}
