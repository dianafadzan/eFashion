using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiPrvaVerzija
{
    class Stavka
    {
        public string sifra { get; set; }
        public string naziv { get; set; }
        public int kolicina { get; set; }
        public double cijena { get; set; }

        public Stavka(string sifra, string naziv, int kolicina, double cijena)
        {
            this.sifra = sifra;
            this.naziv = naziv;
            this.kolicina = kolicina;
            this.cijena = cijena;
        }
    }
}
