﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiRadnici
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
    }
}