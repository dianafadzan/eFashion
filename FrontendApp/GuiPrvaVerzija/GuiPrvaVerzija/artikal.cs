using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiPrvaVerzija
{
    public class artikal
    {
        public int sifra { get; set; }
        public string naziv { get; set; }
        public string velicina { get; set; }
        public int kolicina { get; set; }
        public decimal cijena { get; set; }
        public string slika { get; set; }
        public int kategorija_idkategorije { get; set; }

        /*
        public artikal(int sifra, string naziv, string velicina, int kolicina, decimal cijena, string slika, int kategorija_idkategorije)
        {
            this.sifra = sifra;
            this.naziv = naziv;
            this.velicina = velicina;
            this.kolicina = kolicina;
            this.cijena = cijena;
            this.slika = slika;
            this.kategorija_idkategorije = kategorija_idkategorije;
        }

        public int Sifra { get => sifra; set => sifra = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Velicina { get => velicina; set => velicina = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public decimal Cijena { get => cijena; set => cijena = value; }
        public string Slika { get => slika; set => slika = value; }
        public int Kategorija_idkategorije { get => kategorija_idkategorije; set => kategorija_idkategorije = value; }
    
    */    
     }
}
