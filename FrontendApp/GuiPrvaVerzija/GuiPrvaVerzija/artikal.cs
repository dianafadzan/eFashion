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
        public kategorija kategorija { get; set; }

        
     }
}
