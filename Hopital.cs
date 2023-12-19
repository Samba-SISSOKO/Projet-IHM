using System;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;

namespace model
{
    class Hopital
    {
        private static Hopital instance;
        private Authentification utilisateur;
        private Queue<Patient> patients;
        private List<Salle> salles;

        private Hopital()
        {
            this.patients = new Queue<Patient>();
            this.salles = new List<Salle>();
            int nbSalles = DAOAuthentification.SelectCountSalle();
            for (int i = 1; i <= nbSalles; i++)
            {
                this.salles.Add(new Salle(this, i));
            }
        }

        public static Hopital Instance
        {
            get
            {
                if (instance == null)
                    instance = new Hopital();
                return instance;
            }
        }

        public Authentification Utilisateur
        {
            get
            {
                return this.utilisateur;
            }
        }

        public Authentification Connexion(string login, string password)
        {
            this.utilisateur = DAOAuthentification.SelectAuthentificationByLoginPassword(login, password);
            return this.utilisateur;
        }

        public Salle getSalleAttribuee(int idSalle)
        {
            return this.salles.ElementAt(idSalle - 1);
        }

        public void SalleDispo(Salle s)
        {
            if (patients.Count() != 0)
                s.AjoutVisite(this.patients.Dequeue());
        }

        public void AjouterPatientFile(Patient p)
        {
            this.patients.Enqueue(p);
            ActualisationEntreePatient(p, DateTime.Now);
        }

        public void InsererPatient(Patient p)
        {
            DAOPatient.InsertPatient(p);
        }

        public Patient RecupererPatient(string nom, string prenom)
        {
            return DAOPatient.SelectPatientByNomPrenom(nom, prenom);
        }

        public Patient RecupererPatient(int id)
        {
            return DAOPatient.RecupererPatientParId(id);
        }

        public List<Visite> RecupererVisitesPatient(int patientId)
        {
            return DAOVisite.SelectVisitesByPatientId(patientId);
        }

        public List<Visite> RecupererVisitesMedecin(string nomMedecin)
        {
            return DAOVisite.SelectVisitesByMedecin(nomMedecin);
        }

        public string AfficherFileAttente()
        {
            string file = "";
            file += "Patients en attente :\n";
            foreach (Patient p in patients)
            {
                file += p.ToString() + "\n";
            }
            return file + "\n";
        }

        public string AfficherProchainPatient()
        {
            if (patients.Count() != 0)
            {
                return "Prochain patient :\n" + patients.Peek().ToString();
            }
            else return "File d'attente vide.";
        }

        public bool ModifierInfoPatient(int patientId, string nouvelleAdresse, string nouveauTelephone)
        {
            return DAOPatient.UpdateAdresseTelephoneByPatientId(patientId, nouvelleAdresse, nouveauTelephone);
        }

        public bool nouveauFichier()
        {
            string docPath = Environment.CurrentDirectory;
            using (StreamWriter w = File.AppendText(Path.Combine(docPath, "PassagePatientAttente.txt"))) { }
            string[] lines = File.ReadAllLines(Path.Combine(docPath, "PassagePatientAttente.txt"));
            foreach (string l in lines)
                if (l == "ID\tNOM\tPRENOM\tDATE/HEURE")
                    return false;
            return true;
        }

        public void ActualisationEntreePatient(Patient p, DateTime d)
        {
            bool nouveauFic = nouveauFichier();
            // Set a variable to the Documents path.
            string docPath = Environment.CurrentDirectory;

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "PassagePatientAttente.txt"), true))
            {
                if (nouveauFic)
                    outputFile.WriteLine("ID\tNOM\tPRENOM\tDATE/HEURE");
                outputFile.WriteLine(p.Id + "\t" + p.Nom + "\t" + p.Prenom + "\t" + d.ToString());
            }
        }
    }
}
