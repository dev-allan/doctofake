using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using WpfDoctolib.Tools;

namespace WpfDoctolib.Models
{
    public class Medecin
    {
        private int id;
        private string codeMedecin;
        private string nomMedecin;
        private string tellMedecin;
        private DateTime dateInscription;
        private string specialiteMedecin;
        private static string request;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public string NomMedecin { get => nomMedecin; set => nomMedecin = value; }
        public DateTime DateInscription { get => dateInscription; set => dateInscription = value; }
        public string SpecialiteMedecin { get => specialiteMedecin; set => specialiteMedecin = value; }
        public string TellMedecin { get => tellMedecin; set => tellMedecin = value; }
        public string CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public int Id { get => id; set => id = value; }

        public bool Save(string codeMedecin, string nomMedecin, string tellMedecin, string specialiteMedecin)
        {
            request = "INSERT INTO Medecin (CodeMedecin, NomMedecin, TelMedecin, DateEmbauche, SpecialiteMedecin) OUTPUT INSERTED.ID values (@codeMedecin, @nomMedecin, @telephone, @dateInscription, @specialite)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codeMedecin", codeMedecin));
            command.Parameters.Add(new SqlParameter("@NomMedecin", nomMedecin));
            command.Parameters.Add(new SqlParameter("@telephone", tellMedecin));
            command.Parameters.Add(new SqlParameter("@dateInscription", DateTime.Now));
            command.Parameters.Add(new SqlParameter("@specialite", specialiteMedecin));
            DataBase.Connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return Id > 0;
        }

        public bool Delete(string codeMedecin)
        {
            request = "DELETE FROM Medecin where CodeMedecin = @codeMedecin";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codeMedecin", codeMedecin));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public bool Update(string nomMedecin, string tellMedecin, string specialiteMedecin, string codeMedecin)
        {
            string request = "UPDATE MEDECIN SET NomMedecin = @nomMedecin, TelMedecin=@telMedecin, SpecialiteMedecin=@specialiteMedecin WHERE CodeMedecin=@codeMedecin";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nomMedecin", nomMedecin));
            command.Parameters.Add(new SqlParameter("@telMedecin", tellMedecin));
            command.Parameters.Add(new SqlParameter("@specialiteMedecin", specialiteMedecin));
            command.Parameters.Add(new SqlParameter("@codeMedecin", codeMedecin));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static List<Medecin> SearchMedecin(string search)
        {
            List<Medecin> medecins = new List<Medecin>();
            string request = "SELECT CodeMedecin, NomMedecin, TelMedecin, DateEmbauche, SpecialiteMedecin FROM Medecin WHERE CodeMedecin like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", search));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            Medecin e = new Medecin
            {
                codeMedecin = reader.GetString(0),
                nomMedecin = reader.GetString(1),
                tellMedecin = reader.GetString(2),
                dateInscription = reader.GetDateTime(3),
                specialiteMedecin = reader.GetString(4),
            };
            medecins.Add(e);
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return medecins;
        }

        public static List<Medecin> GetMedecin()
        {
            List<Medecin> liste = new List<Medecin>();
            request = "SELECT codeMedecin, NomMedecin, TelMedecin, DateEmbauche, SpecialiteMedecin FROM Medecin";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Medecin e = new Medecin
                {
                    codeMedecin = reader.GetString(0),
                    nomMedecin = reader.GetString(1),
                    tellMedecin = reader.GetString(2),
                    dateInscription = reader.GetDateTime(3),
                    specialiteMedecin = reader.GetString(4),
                };
                liste.Add(e);
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return liste;
        }

        public static List<Medecin> GetList()
        {
            return Medecin.GetMedecin();
        }

    }
}
