using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Authentification
    {
        private string login;
        private string password;
        private string nom;
        private int metier;

        public Authentification(string login, string password, string nom, int metier)
        {
            this.login = login;
            this.password = password;
            this.nom = nom;
            this.metier = metier;
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public int Metier
        {
            get { return metier; }
            set { metier = value; }
        }


        public override string ToString()
        {
            string str= "Login: " + login + "Password: " + password + "Nom: " + nom + "Metier: " + metier;
            return str;
        }
    }
}
