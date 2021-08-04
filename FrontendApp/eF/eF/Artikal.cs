using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eF
{
    public class Artikal
    {
        private int sifra;
        private string velicina;
        private double jedCijena;
        private string putanja;
        private string naziv;

        public Artikal(int sifra,string vel,double cijena,string putanja,string naziv)
        {
            this.naziv = naziv;
            this.sifra = sifra;
            this.velicina = vel;
            this.jedCijena = cijena;
            this.putanja = putanja;
        }
        public void setJedCijena(double cijena)
        {
            this.jedCijena = cijena;
        }

        public double getJedCijena()
        {
            return this.jedCijena;
        }

        public void setSifra(int cijena)
        {
            this.sifra = cijena;
        }

        public int getSifra()
        {
            return this.sifra;
        }

        public string getVelicina()
        {
            return this.velicina;

        }

        public void setVelicina(string putanja)
        {
            this.velicina = putanja;
        }

        public string getPutanja()
        {
            return this.putanja;

        }

        public void setPutanja(string putanja)
        {
            this.putanja = putanja;
        }
        public string getNaziv()
        {
            return this.naziv;

        }

        public void setNaziv(string putanja)
        {
            this.naziv = putanja;
        }
    }
}
