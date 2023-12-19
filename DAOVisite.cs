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
    class DAOVisite

    {

        public static List<Visite> SelectVisitesByMedecin(string nom)
        {
            List<Visite> listeVisite = new List<Visite>();

            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";
            string sql = "SELECT * FROM Visites WHERE medecin = '" + nom + "'";

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                int patientId = reader.GetInt32(reader.GetOrdinal("patientid"));
                DateTime dateVisite = reader.GetDateTime(reader.GetOrdinal("datevisite"));
                string medecin = reader.GetString(reader.GetOrdinal("medecin"));
                int numeroSalle = reader.GetInt32(reader.GetOrdinal("numsalle"));

                decimal tarif;
                if (!reader.IsDBNull(reader.GetOrdinal("tarif")))
                {
                    tarif = reader.GetDecimal(reader.GetOrdinal("tarif"));
                }
                else
                {
                    return null;
                }

                Visite visite = new Visite(id, patientId, dateVisite, medecin, numeroSalle, tarif);
                listeVisite.Add(visite);
            }

            connexion.Close();
            return listeVisite;


        }


        public static List<Visite> SelectVisitesByPatientId(int idPatient)
        {
            List<Visite> listeVisite = new List<Visite>();


            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";
            string sql = "SELECT * FROM Visites WHERE patientid = " + idPatient;

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int patientId = reader.GetInt32(reader.GetOrdinal("patientid"));
                DateTime dateVisite = reader.GetDateTime(reader.GetOrdinal("datevisite"));
                string medecin = reader.GetString(reader.GetOrdinal("medecin"));
                int numeroSalle = reader.GetInt32(reader.GetOrdinal("numsalle"));

                decimal tarif;
                if (!reader.IsDBNull(reader.GetOrdinal("tarif")))
                {
                    tarif = reader.GetDecimal(reader.GetOrdinal("tarif"));
                }
                else
                {

                    return null;
                }

                Visite visite = new Visite(patientId, dateVisite, medecin, numeroSalle, tarif);
                listeVisite.Add(visite);
            }

            connexion.Close();
            return listeVisite;


        }


        public static List<Visite> SelectAllVisites()
        {

            List<Visite> listeVisite = new List<Visite>();


            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";
            string sql = "select * from Visites";

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                int patientId = reader.GetInt32(reader.GetOrdinal("patientid"));
                DateTime dateVisite = reader.GetDateTime(reader.GetOrdinal("datevisite"));
                string medecin = reader.GetString(reader.GetOrdinal("medecin"));
                int numeroSalle = reader.GetInt32(reader.GetOrdinal("numsalle"));

                decimal tarif;
                if (!reader.IsDBNull(reader.GetOrdinal("tarif")))
                {
                    tarif = reader.GetDecimal(reader.GetOrdinal("tarif"));
                }
                else
                {

                    return null;
                }

                Visite visite = new Visite(patientId, dateVisite, medecin, numeroSalle, tarif);
                listeVisite.Add(visite);
            }

            connexion.Close();
            return listeVisite;
        }


        public static void Insert(Visite visite)
        {
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";

            string sql = "INSERT INTO Visites (patientid, datevisite, medecin, numsalle, tarif) " +
                              "VALUES (@patientid, @datevisite, @medecin, @numsalle, @tarif)";

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("patientid", SqlDbType.Int).Value = visite.IdPatient;
            command.Parameters.Add("datevisite", SqlDbType.DateTime).Value = visite.DateVisite;
            command.Parameters.Add("medecin", SqlDbType.NVarChar).Value = visite.Medecin;
            command.Parameters.Add("numsalle", SqlDbType.Int).Value = visite.NumeroSalle;
            command.Parameters.Add("tarif", SqlDbType.NVarChar).Value = visite.Tarif;

            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }




    }
}
