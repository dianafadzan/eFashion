using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eF
{
    public  class Stavka
    {

        private Artikal artikal;
        private int kolicina;

        public Stavka(Artikal artikal, int kolicina)
        {
            this.artikal = artikal;
            this.kolicina = kolicina;
        }

        public int getKol()
        {
            return kolicina;
        }

        public void setKol(int kolicina)
        {
            this.kolicina = kolicina;
        }

        public Artikal getArtikal()
        {
            return artikal;
        }

        public void setArtikal(Artikal artikal)
        {
            this.artikal = artikal;
        }
    }
}
