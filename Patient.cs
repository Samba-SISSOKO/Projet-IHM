using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Patient
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private string adresse;
        private string telephone;

        public Patient(string nom, string prenom, int age, string adresse, string telephone)
        {
            this.Id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.adresse = adresse;
            this.telephone = telephone;
        }

        public Patient(int id , string nom, string prenom, int age, string adresse, string telephone)
        {
            this.Id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.adresse = adresse;
            this.telephone = telephone;
        }



        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public override string ToString()
        {
            string str ="Nom: " + nom + " Prenom: " + prenom + " Age: " + age + " Adresse: " + adresse + " Telephone: " + telephone;
            return str;
        }

    }


    
}
