using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashion
{
    class Mjesto
    {
        private int postanskibroj { get; set; }
        private string naziv  { get; set; }

        public Mjesto(int postanskibroj, string naziv)
        {
            this.postanskibroj = postanskibroj;
            this.naziv = naziv;
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
            }
        }

    }
}
