using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;

namespace model
{
    class Salle
    {
        private Hopital h;
        private int id;
        private List<Visite> visites;
        private static decimal tarif = 23;

        public Salle(Hopital h, int id)
        {
            this.h = h;
            this.id = id;
            this.visites = new List<Visite>();
        }

        public int Id
        {
            get { return id; }
        }

        public void SalleDispo()
        {
            h.SalleDispo(this);
        }

        public void AjoutVisite(Patient p)
        {
            visites.Add(new Visite(p.Id, DateTime.Now, h.Utilisateur.Nom, this.id, tarif));
            if (this.visites.Count() == 5)
            {
                EnregistrerVisites();
            }
        }

        public void EnregistrerVisites()
        {
            foreach (Visite v in this.visites)
                DAOVisite.Insert(v);
            this.visites.Clear();
        }
    }
}
