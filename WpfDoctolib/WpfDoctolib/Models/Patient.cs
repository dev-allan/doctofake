using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using WpfDoctolib.Tools;

namespace WpfDoctolib.Models
{
    public class Patient
    {
        private int id;
        private string codePatient;
        private string nomPatient;
        private string adressePatient;
        private string dateNaissance;
        private string sexePatient;
        private static string request;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public string CodePatient { get => codePatient; set => codePatient = value; }
        public string NomPatient { get => nomPatient; set => nomPatient = value; }
        public string AdressePatient { get => adressePatient; set => adressePatient = value; }
        public string DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string SexePatient { get => sexePatient; set => sexePatient = value; }
        public int Id { get => id; set => id = value; }

        public bool Save(string codePatient, string nomPatient, string adressePatient, string dateNaissance, string sexePatient)
        {
            request = "INSERT INTO Patient (CodePatient, NomPatient, AdressePatient, DateNaissance, SexePatient) OUTPUT INSERTED.ID values (@codePatient, @nomPatient, @adressePatient, @dateNaissance, @sexePatient)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codePatient", codePatient));
            command.Parameters.Add(new SqlParameter("@nomPatient", nomPatient));
            command.Parameters.Add(new SqlParameter("@adressePatient", adressePatient));
            command.Parameters.Add(new SqlParameter("@dateNaissance", dateNaissance));
            command.Parameters.Add(new SqlParameter("@sexePatient", sexePatient));
            DataBase.Connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return Id > 0;
        }

        public bool Delete(string codePatient)
        {
            request = "DELETE FROM Patient where CodePatient = @codePatient";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codePatient", codePatient));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public bool Update(string nomPatient, string adressePatient, string dateNaissance, string sexePatient, string codePatient)
        {
            string request = "UPDATE Patient SET NomPatient = @nomPatient, AdressePatient=@adressePatient, DateNaissance=@dateNaissance, SexePatient=@sexePatient WHERE CodePatient=@codePatient";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nomPatient", nomPatient));
            command.Parameters.Add(new SqlParameter("@adressePatient", adressePatient));
            command.Parameters.Add(new SqlParameter("@dateNaissance", dateNaissance));
            command.Parameters.Add(new SqlParameter("@sexePatient", sexePatient));
            command.Parameters.Add(new SqlParameter("@codePatient", codePatient));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static List<Patient> SearchPatient(string search)
        {

            List<Patient> patients = new List<Patient>();
            string request = "SELECT CodePatient, NomPatient, AdressePatient, DateNaissance, SexePatient FROM Patient WHERE " +
                "CodePatient like @search OR NomPatient like @search OR DateNaissance like @search OR SexePatient like @search OR AdressePatient like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Patient patient = new Patient
                {
                    codePatient = reader.GetString(0),
                    nomPatient = reader.GetString(1),
                    adressePatient = reader.GetString(2),
                    dateNaissance = reader.GetString(3),
                    sexePatient = reader.GetString(4)
                };
                patients.Add(patient);
            }
            reader.Close();
            command.Dispose();

            request = "deuxième requete";
            command = new SqlCommand(request, DataBase.Connection);


            DataBase.Connection.Close();
            return patients;
        }

        public static List<Patient> GetPatient()
        {
            List<Patient> liste = new List<Patient>();
            request = "SELECT CodePatient, NomPatient, AdressePatient, DateNaissance, SexePatient FROM Patient";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Patient e = new Patient
                {
                    codePatient = reader.GetString(0),
                    nomPatient = reader.GetString(1),
                    adressePatient = reader.GetString(2),
                    dateNaissance = reader.GetString(3),
                    sexePatient = reader.GetString(4),
                };
                liste.Add(e);
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return liste;
        }

        public static List<Patient> GetList()
        {
            return Patient.GetPatient();
        }


    }
}
