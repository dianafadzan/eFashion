using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiPrvaVerzija
{
    class Racun
    {
        public string id { get; set; }
        public List<Stavka> niz = new List<Stavka>();
        
        public Racun(int broj)
        {
            id = broj.ToString();
            for(int i = 0; i < broj; i++)
            {
                niz.Add(new Stavka(i.ToString(), "majica" + i.ToString(), i, i + 2.5));
            }
        }
        
    }
}
