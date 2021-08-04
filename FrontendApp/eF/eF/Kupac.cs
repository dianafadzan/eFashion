using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eF
{
    public class Kupac
    {
        private int idkupca;
        private string username;
        private string password;
        private string ime;
        private string prezime;
        private string adresa;
        private string brojTelefona;
        private string email;

        public Kupac(int idkupca, string username, string password, string ime, string prezime, string adresa, string brojTelefona, string email)
        {
            this.idkupca = idkupca;
            this.username = username;
            this.password = password;
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.brojTelefona = brojTelefona;
            this.email = email;
        }

        public Kupac(string username, string password, string ime, string prezime, string adresa, string brojTelefona, string email)
        {
            this.username = username;
            this.password = password;
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.brojTelefona = brojTelefona;
            this.email = email;
        }

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }
    }
}
