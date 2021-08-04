using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eF
{
    public class Narudzba
    {
        private List<Stavka> stavke = new List<Stavka>();
        private int idNarudzbe;
        private double ukupno=0;
        public Narudzba(List<Stavka> stavke, int idNarudzbe)
        {
            this.stavke = stavke;
            this.idNarudzbe = idNarudzbe;
        }

        public int getiD()
        {
            return idNarudzbe;
        }

        public double getUkupno()
        {
            return ukupno;
        }

        public void setUkupno(double idNarudzbe)
        {
            this.ukupno = idNarudzbe;
        }

        public void setId(int idNarudzbe)
        {
            this.idNarudzbe = idNarudzbe;
        }        


        public List<Stavka> getStavke()
        {
            return stavke;
        }

        public void setStavke(List<Stavka> art)
        {
            this.stavke = art;
        }

    }
}
