using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eF
{
    class Mjesto
    {
        private int postanskibroj;
        private string naziv;

        public Mjesto(int postanskibroj, string naziv)
        {
            this.postanskibroj = postanskibroj;
            this.naziv = naziv;
        }

        public int getPostanskiBroj()
        {
            return postanskibroj;
        }

        public void setPostanskiBroj(int pb)
        {
            this.postanskibroj = pb;
        }

        public void setNaziv(string naziv)
        {
            this.naziv = naziv;
        }

        public string getNaziv()
        {
            return naziv;
        }
    }
}
