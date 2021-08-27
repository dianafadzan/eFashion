using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiPrvaVerzija
{
    public class stavka
    {
        public int racunIdracuna { get; set; }
        public int artikalSifra { get; set; }
        public int kolicina { get; set; }
        public decimal cijena { get; set; }
        public racun racun { get; set; }
        public artikal artikal { get; set; }
        
        
    }
}
