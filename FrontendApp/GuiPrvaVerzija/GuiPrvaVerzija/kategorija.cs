using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiPrvaVerzija
{
    class kategorija
    {
        private int idkategorije;
        private string naziv;

        public kategorija(int idkategorije, string naziv)
        {
            this.idkategorije = idkategorije;
            this.naziv = naziv;
        }

        public int Idkategorije { get => idkategorije; set => idkategorije = value; }
        public string Naziv { get => naziv; set => naziv = value; }
    }
}
