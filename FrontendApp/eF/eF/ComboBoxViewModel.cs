using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eF
{
    class ComboBoxViewModel
    {

        public List<string> velicine { get; set; }
        public static List<int> kolicina { get; set; }
        public static List<int> postanskibrojevi { get; set; }

        public ComboBoxViewModel()
        {
            velicine = new List<string>();
            kolicina = new List<int>();
            velicine.Add("S");
            velicine.Add("M");
            velicine.Add("L");
            velicine.Add("XL");
            postanskibrojevi = new List<int>();
            postanskibrojevi.Add(78000);
            postanskibrojevi.Add(74000);

            for (int i = 1; i < 20; i++)
            {
                kolicina.Add(i);
            }

        }
    }
}
