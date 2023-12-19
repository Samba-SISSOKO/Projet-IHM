using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Visite
    {
        private int id;
        private int idpatient;
        private DateTime dateVisite;
        private string medecin;
        private  int numeroSalle;
        private decimal tarif;
        
        

        public Visite(int idpatient, DateTime date, string medecin, int numeroSalle, decimal tarif)
        {
            
            this.idpatient = idpatient;
            this.dateVisite = date;
            this.medecin = medecin;
            this.numeroSalle = numeroSalle;
            this.tarif = tarif;
            
        }

        public Visite(int id, int idpatient, DateTime date, string medecin, int numeroSalle, decimal tarif)
        {
            this.Id = id;
            this.idpatient = idpatient;
            this.dateVisite = date;
            this.medecin = medecin;
            this.numeroSalle = numeroSalle;
            this.tarif = tarif;

        }

        public Visite(int id) { this.id = id; }

       

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdPatient
        {
            get { return idpatient; }
            set { idpatient = value; }
        }

        public DateTime DateVisite
        {
            get { return dateVisite; }
            set { dateVisite = value; }
        }

        public string Medecin
        {
            get { return medecin; }
            set { medecin = value; }
        }

        public int NumeroSalle
        {
            get { return numeroSalle; }
            set { numeroSalle = value; }
        }

        public decimal Tarif
        {
            get { return tarif; }
            set { tarif = value; }
        }

        public override string ToString()
        {
            return  "idPatient: "+ IdPatient + " DateVisite: " + dateVisite + " Medecin: " + medecin + " Num_Salle: " + numeroSalle + " Tarif: " + tarif;
        }

    }
}
