using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using dao;

namespace user
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestInsert();
            //TestSelectByNomPrenomPatient();
            //TestSelectAuthentificationByLoginPassword();
            //TestSelectAllVisites();
            //TestVisiteInsert();
            //TestSelectAllVisites();
            //UpdateAdresseTelephone();
            //TestSelectVisitesByPatientId();
            TestMain();
            //TestInsertHopital();


        }

        static void UpdateAdresseTelephone()
        {
            DAOPatient.UpdateAdresseTelephoneByPatientId(5, "20 Rue de Monaco", "0123456789");
        }

        static void TestSelectVisitesByPatientId()
        {
            int id = 1;
            List<Visite> v = DAOVisite.SelectVisitesByPatientId(id);


            AfficherToutesVisites(v);

        }

        static void TestSelectAllVisites()
        {
            List<Visite> visites = DAOVisite.SelectAllVisites();

            // Afficher les résultats dans la console
            foreach (Visite visite in visites)
            {
                Console.WriteLine("Visite pour Patient ID : " + visite.IdPatient + "," + " Date : " + visite.DateVisite + "," + " Medecin : " + visite.Medecin + "," +
                                  " NumeroSalle : " + visite.NumeroSalle + "," + " Tarif : " + visite.Tarif);
            }
        }


        static void TestVisiteInsert()
        {
            //DAOVisite dAO = new DAOVisite();

            Visite v = new Visite(3, DateTime.Now, "Dr. Laurent", 2, 23);
            DAOVisite.Insert(v);

        }


        static void TestSelectAuthentificationByLoginPassword()
        {
            //DAOAuthentification dAO = new DAOAuthentification();
            Authentification auth = DAOAuthentification.SelectAuthentificationByLoginPassword("docteur1_login", "docteur1_password");
            Console.WriteLine("Docteur: " + auth.Nom + " Métier: " + auth.Metier);
        }


        static void TestInsertPatient()
        {

            //DAOPatient dAO = new DAOPatient();

            Patient p = new Patient("François", "Delbot", 40, "1 rur de rue", "0123456");
            DAOPatient.InsertPatient(p);

        }


        static void TestSelectByNomPrenomPatient()
        {
            string nom = "Sissoko";
            string prenom = "Samba";
            //DAOPatient dAO = new DAOPatient();
            Patient patient = DAOPatient.SelectPatientByNomPrenom(nom, prenom);


            Console.WriteLine("Nom: " + patient.Nom + "\t" + "Prenom: " + patient.Prenom + "\t" + "Age: " + patient.Age + "\t"
                + "Adresse: " + patient.Adresse + "\t" + "Téléphone: " + patient.Telephone);




        }


        static void AfficherToutesVisites(List<Visite> visites)
        {


            foreach (Visite v in visites)
            {
                Console.WriteLine("IdPatient: " + v.IdPatient + " Date: " + v.DateVisite + " Medecin: " + v.Medecin + " Num-Salle: " + v.NumeroSalle + " Taif: " + v.Tarif);
            }
        }

        //-------------------------------------------------------------------------------------------------------

        static void TestMain()
        {
            Hopital hopital = Hopital.Instance;
            while (true)
            {
                Console.Write("Entrez votre login : ");
                string login = Console.ReadLine();

                Console.Write("Entrez votre mot de passe : ");
                string password = Console.ReadLine();


                Authentification roleId = hopital.Connexion(login, password);

                if (roleId == null)
                {
                    Console.WriteLine("Login ou mot de passe incorrect.");
                    
                }
                else if (roleId.Metier == 1 || roleId.Metier == 2)
                {
                    Console.WriteLine("Bienvenue dans l'interface Medecin");
                    MedecinMenu();
                } else if(roleId.Metier == 0)
                {
                    Console.WriteLine("Bienvenue dans l'interface Secrétaire");
                    SecretaireMenu();
                }
                else
                {
                    Console.WriteLine(" Aucune information pour cet id .");

                }
            }
        }

        static void SecretaireMenu()
        {
            Hopital hopital = Hopital.Instance;
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1. Rajouter un patient");
                Console.WriteLine("2. Afficher l'état de la file d'attente");
                Console.WriteLine("3. Afficher le prochain patient de la file d'attente");
                Console.WriteLine("4. Mettre à jour le patient");
                Console.WriteLine("5. Afficher les visites d'un patient par son Id");
                //Console.WriteLine("6. Ajouter Patient dans la file d'attente ");               
                Console.WriteLine("8. Quitter l'interface Secrétaire");
                Console.WriteLine("----------------------------------");

                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        // Inscrire un patient
                        AjouterPatientFileHopital();


                        break;
                    case "2":

                        // Afficher l'état de la file d'attente
                        AfficherFileAttente();


                        break;
                    case "3":
                        // Afficher le prochain patient de la file d'attente
                        AfficherProchainPatient();
                        break;

                    case "4":
                        // Mettre à jour le patient
                        TestUpdatePatient();


                        break;

                    case "5":
                        // Afficher les visites d'un patient par son Id
                        AfficherVisitePatientId();
                        break;

                    //case "6":
                    //    // Ajouter Patient dans la file d'attente
                    //    AjouterPatientFileHopital();
                    //    break;

                    case "8":
                        return;
                    default:
                        Console.WriteLine("Option non valide. tu peux réessayer.");
                        break;
                }
            }
        }



        static void MedecinMenu()
        {
            Hopital hopital = Hopital.Instance;
            Salle s = hopital.getSalleAttribuee(hopital.Utilisateur.Metier);
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1. Rendre la salle disponible");
                Console.WriteLine("2. Afficher l'état de la file d'attente");
                Console.WriteLine("3. Sauvegarder les visites en base");
                Console.WriteLine("4. Afficher les visites à mon compte");
                Console.WriteLine("5. Quitter");
                Console.WriteLine("----------------------------------");

                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        // Rendre la salle dispo
                        Console.WriteLine("Salle n°" + s.Id + " rendue disponible a la consultation.");
                        hopital.SalleDispo(s);
                        break;
                    case "2":
                        // Afficher la file d'attente
                        Console.WriteLine(hopital.AfficherFileAttente());
                        break;
                    case "3":
                        Console.WriteLine("Sauvegarde des visites");
                        s.EnregistrerVisites();
                        break;
                    case "4":
                        Console.WriteLine("Visites a votre compte :");
                        List<Visite> visites = hopital.RecupererVisitesMedecin(hopital.Utilisateur.Nom);
                        foreach (Visite v in visites)
                            Console.WriteLine(v.ToString());
                        break;
                    case "5":
                        Console.WriteLine("Sauvegarde des visites, retour au menu principal");
                        s.EnregistrerVisites();
                        return;
                    default:
                        Console.WriteLine("Option non valide. Veuillez reessayer.");
                        break;
                }
            }
        }



        //static void MedecinMenu()
        //{
        //    Hopital hopital = Hopital.Instance;
        //    Salle s = hopital.getSalleAttribuee(hopital.Utilisateur.Metier);
        //    while (true)
        //    {
        //        Console.WriteLine("----------------------------------");
        //        Console.WriteLine("1. Rendre la salle disponible");
        //        Console.WriteLine("2. Afficher l'état de la file d'attente");
        //        Console.WriteLine("3. Sauvegarder les visites en base");
        //        Console.WriteLine("4. Afficher les visites à mon compte");
        //        Console.WriteLine("5. Quitter");
        //        Console.WriteLine("----------------------------------");

        //        Console.Write("Choisissez une option : ");
        //        string choix = Console.ReadLine();

        //        switch (choix)
        //        {
        //            case "1":
        //                // Rendre la salle dispo
        //                Console.WriteLine("Salle n°" + s.Id + " rendue disponible a la consultation.");
        //                hopital.SalleDispo(s);
        //                break;
        //            case "2":
        //                // Afficher la file d'attente
        //                Console.WriteLine(hopital.AfficherFileAttente());
        //                //hopital.AfficherFileAttente();

        //                break;
        //            case "3":
        //                Console.WriteLine("Sauvegarde des visites");
        //                s.EnregistrerVisites();
        //                break;
        //            case "4":
        //                Console.WriteLine("Visites a votre compte :");
        //                List<Visite> visites = hopital.RecupererVisitesMedecin(hopital.Utilisateur.Nom);
        //                foreach (Visite v in visites)
        //                    Console.WriteLine(v.ToString());
        //                break;
        //            case "5":
        //                Console.WriteLine("Sauvegarde des visites, retour au menu principal");
        //                s.EnregistrerVisites();
        //                return;
        //            default:
        //                Console.WriteLine("Option non valide. Veuillez reessayer.");
        //                break;
        //        }
        //    }
        //}



        static void InsertPatienrEnBaseHopital()
        {
            Hopital h = Hopital.Instance;

           
            Console.Write("Entrez le nom du patient : ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le prénom du patient : ");
            string prenom = Console.ReadLine();
            Console.Write("Entrez l'âge du patient : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Entrez l'adresse du patient : ");
            string adresse = Console.ReadLine();
            Console.Write("Entrez numéro de téléphone du patient : ");
            string telephone = Console.ReadLine();

            h.InsererPatient(new Patient(nom, prenom, age, adresse, telephone));

        }

        static void AfficherFileAttente()
        {
            Hopital h = Hopital.Instance;
            h.AfficherFileAttente();
           
            Console.WriteLine(h.AfficherFileAttente());                     

        }

        static void AfficherProchainPatient()
        {
            Hopital h = Hopital.Instance;
            Console.WriteLine(h.AfficherProchainPatient());

        }

        static void TestUpdatePatient()
        {
            Hopital h = Hopital.Instance;
            Console.Write("Entrez Id du Patient : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Entrez la nouvel adresse du patient : ");
            string adresse = Console.ReadLine();
            Console.Write("Entrez le nouveau téléphone du patient : ");
            string telephone = Console.ReadLine();
            //DAOPatient.UpdateAdresseTelephoneByPatientId(5, "20 Rue de Monaco", "0123456789");
            h.ModifierInfoPatient(id, adresse, telephone);
        }

        static void AfficherVisitePatientId()
        {

            Hopital h = Hopital.Instance;
            Console.Write("Entrez l'ID du patient : ");
            int patientId = int.Parse(Console.ReadLine());
            h.RecupererVisitesPatient(patientId);
           
            List<Visite> visites = h.RecupererVisitesPatient(patientId);

            foreach (Visite v in visites)
            
            Console.WriteLine(v.ToString() );

        }

        static void AjouterPatientFileHopital()
        {
            Hopital h = Hopital.Instance;

            Console.Write("Entrez le nom du patient : ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le prénom du patient : ");
            string prenom = Console.ReadLine();

            Patient p = h.RecupererPatient(nom, prenom);
            //Console.WriteLine(p.ToString());
            if (p != null)
            {
                Console.WriteLine("Patient trouvé, ajout à la file d'attente.");
                h.AjouterPatientFile(p);
            }
            else
            {
                Console.Write("Entrez l'âge du patient : ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Entrez l'adresse du patient : ");
                string adresse = Console.ReadLine();
                Console.Write("Entrez numéro de téléphone du patient : ");
                string telephone = Console.ReadLine();
                p = new Patient(nom, prenom, age, adresse, telephone);
                h.InsererPatient(p);

                h.AjouterPatientFile(h.RecupererPatient(nom, prenom));
            }
        }

       

    }
}
