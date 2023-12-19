using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using model;


namespace dao
{
    class DAOPatient
    {


        public static bool UpdateAdresseTelephoneByPatientId(int patientId, string nouvelleAdresse, string nouveauTelephone)
        {
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";
            string sql = "UPDATE Patients SET Adresse = @NouvelleAdresse, Telephone = @NouveauTelephone WHERE Id = @PatientId";

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;

            command.Parameters.AddWithValue("@PatientId", patientId);
            command.Parameters.AddWithValue("@NouvelleAdresse", nouvelleAdresse);
            command.Parameters.AddWithValue("@NouveauTelephone", nouveauTelephone);

            connexion.Open();
            int nb = command.ExecuteNonQuery();
            connexion.Close();
            if (nb > 0)
                return true;

            return false;
        }


        public static Patient RecupererPatientParId(int patientId)
        {
            Patient p = null;
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";
            string sql = "SELECT * FROM Patients WHERE  @Id=" + patientId;

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                p = new Patient(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));

            connexion.Close();

            return p;
        }

        public static void InsertPatient(Patient patient)
        {
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";

            string sql = "INSERT INTO Patients (nom, prenom, age, adresse, telephone) " +
                              "VALUES (@nom, @prenom, @age, @adresse, @telephone)";

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;


            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = patient.Nom;
            command.Parameters.Add("prenom", SqlDbType.NVarChar).Value = patient.Prenom;
            command.Parameters.Add("age", SqlDbType.Int).Value = patient.Age;
            command.Parameters.Add("adresse", SqlDbType.NVarChar).Value = patient.Adresse;
            command.Parameters.Add("telephone", SqlDbType.NVarChar).Value = patient.Telephone;

            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
            //return true;
        }

        public static Patient SelectPatientByNomPrenom(string nom, string prenom)
        {
            Patient p = null;

            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";
            string sql = "SELECT * FROM Patients WHERE nom = @nom AND prenom = @prenom";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            command.Parameters.Add("nom", SqlDbType.NVarChar).Value = nom;
            command.Parameters.Add("prenom", SqlDbType.NVarChar).Value = prenom;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                p = new Patient(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            }

            connexion.Close();
            return p;
        }





    }
}

