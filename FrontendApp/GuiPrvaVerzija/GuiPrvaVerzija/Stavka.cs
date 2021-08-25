using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiPrvaVerzija
{
    class stavka
    {
        public int racun_idracuna { get; set; }
        public string artikal_sifra { get; set; }
        public int kolicina { get; set; }
        public decimal cijena { get; set; }

        /*
        public stavka(int racun_idracuna, string artikal_sifra, int kolicina, decimal cijena)
        {
            this.racun_idracuna = racun_idracuna;
            this.artikal_sifra = artikal_sifra;
            this.kolicina = kolicina;
            this.cijena = cijena;
        }

        */
    }
}
