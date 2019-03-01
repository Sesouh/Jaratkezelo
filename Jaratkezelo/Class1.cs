using System;
using System.Collections.Generic;
using System.Text;

namespace Jaratkezelo
{
    public class Class1
    {
        public class Jarat
        {
            public string Jaratszam { get; set; }
            public string HonnanRepter { get; set; }
            public string HovaRepter { get; set; }
            public DateTime Indulas { get; set; }
            public int Keses { get; set; }

            public Jarat(string jaratszam, string honnanRepter, string hovaRepter, DateTime indulas)
            {
                this.Jaratszam = jaratszam;
                this.HonnanRepter = honnanRepter;
                this.HovaRepter = hovaRepter;
                this.Indulas = indulas;
                this.Keses = 0;
            }
        }

        public List<Jarat> jaratok_lista = new List<Jarat>();

        public void Ujjarat(string jaratszam, string repterHonnan,string repterHova,DateTime indulas)
        {
            if (jaratszam.Equals("")) throw new ArgumentException();
            if (repterHonnan.Equals("")) throw new ArgumentException();
            if (repterHova.Equals("")) throw new ArgumentException();
            for (int i = 0; i < jaratok_lista.Count; i++)
            {
                if (jaratok_lista[i].Jaratszam.Equals(jaratszam)) throw new ArgumentException();
            }

            Jarat jaratPeldany = new Jarat(jaratszam, repterHonnan, repterHova, indulas);
            jaratok_lista.Add(jaratPeldany);
        }

        public void Keses(string jaratSzam, int keses)
        {
            if (keses == 0) throw new ArgumentException();
            for (int i = 0; i < jaratok_lista.Count; i++)
            {
                if (jaratok_lista[i].Jaratszam.Equals(jaratSzam))
                {
                    if (jaratok_lista[i].Keses + keses < 0) throw new NegativKesesException(jaratok_lista[i].Jaratszam);
                    jaratok_lista[i].Keses += keses;
                    return;
                }
            }
            throw new ArgumentException();
        }
        
        public DateTime MikorIndul(string jaratSzam)
        {
            for (int i = 0; i < jaratok_lista.Count; i++)
            {
                if (jaratok_lista[i].Jaratszam.Equals(jaratSzam))
                {
                    DateTime varhato_indulas = jaratok_lista[i].Indulas;
                    varhato_indulas = varhato_indulas.AddMinutes(jaratok_lista[i].Keses);
                    return varhato_indulas;
                }
            }
            throw new ArgumentException();
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < jaratok_lista.Count; i++)
            {
                if (jaratok_lista[i].HonnanRepter.Equals(repter))
                {
                    lista.Add(jaratok_lista[i].Jaratszam);
                }
            }
            if (lista.Count != 0) return lista;
            throw new ArgumentException();
        }
    }
}
