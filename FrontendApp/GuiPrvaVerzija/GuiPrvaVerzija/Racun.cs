using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiPrvaVerzija
{
    class racun
    {
        public int idracuna { get; set; }
        public DateTime datum { get; set; }
        public decimal ukupno { get; set; }
        public string radnik_jmb { get; set; }

        /*public List<Stavka> niz = new List<Stavka>();

        public racun(int idracuna, DateTime datum, decimal ukupno, string radnik_jmb)
        {
            this.idracuna = idracuna;
            this.datum = datum;
            this.ukupno = ukupno;
            this.radnik_jmb = radnik_jmb;
        }

        
        public Racun(int broj)
        {
            id = broj.ToString();
            for(int i = 0; i < broj; i++)
            {
                niz.Add(new Stavka(i.ToString(), "majica" + i.ToString(), i, i + 2.5));
            }
        }
        */
    }



}
