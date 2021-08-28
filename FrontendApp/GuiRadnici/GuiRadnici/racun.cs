using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiRadnici
{
    public class racun
    {
        public int idracuna { get; set; }
        public DateTime datum { get; set; }
        public decimal ukupno { get; set; }
       
        public radnik radnik { get; set; }

    }
}
