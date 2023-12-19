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


    class DAOAuthentification
    {


        public static int SelectCountSalle()
        {

            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";

            string sql = "select count(*) from authentification where metier > "+0;           

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

           // SqlDataReader reader = command.ExecuteReader();

            int count = (int)command.ExecuteScalar();

            connexion.Close();
            return count;          

        }


        public static Authentification SelectAuthentificationByLoginPassword(string login, string password)
        {

            Authentification auth = null;
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=Hopital_Cs;Integrated Security=True";
            string sql = "SELECT * FROM Authentification where login=@login AND password=@password"; 


            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            command.Parameters.Add("login", SqlDbType.NChar).Value = login;
            command.Parameters.Add("password", SqlDbType.NVarChar).Value = password;


            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                auth = new Authentification(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                
            }

            connexion.Close();
            return auth;
        }


    }
}
