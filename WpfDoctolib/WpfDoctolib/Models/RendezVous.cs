using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using WpfDoctolib.Tools;

namespace WpfDoctolib.Models
{
    public class RendezVous
    {
        private int numeroRdv;
        private string dateRDV;
        private string heureRDV;
        private string codePatient;
        private string codeMedecin;
        private static string request;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int NumeroRdv { get => numeroRdv; set => numeroRdv = value; }
        public string DateRDV { get => dateRDV; set => dateRDV = value; }
        public string HeureRDV { get => heureRDV; set => heureRDV = value; }
        public static SqlCommand Command { get => command; set => command = value; }
        public static SqlDataReader Reader { get => reader; set => reader = value; }
        public string CodePatient { get => codePatient; set => codePatient = value; }
        public string CodeMedecin { get => codeMedecin; set => codeMedecin = value; }


        public bool Save(string CodePatient, string CodeMedecin, string dateRDV, string heureRDV)
        {
            DataBase.Connection.Open();
            request = "INSERT INTO RDV (DateRDV, HeureRDV, CodeMedecin, CodePatient) output inserted.NumeroRdv " +
                "values (@dateRDV, @heureRDV, @codeMedecin ,@codePatient) ";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@dateRDV", dateRDV));
            command.Parameters.Add(new SqlParameter("@heureRDV", heureRDV));
            command.Parameters.Add(new SqlParameter("@codeMedecin", CodeMedecin));
            command.Parameters.Add(new SqlParameter("@codePatient", CodePatient));
            NumeroRdv = (int)command.ExecuteScalar();
            command.Dispose();

            DataBase.Connection.Close();
            return NumeroRdv > 0;
        }

        public bool Delete(SqlTransaction transaction)
        {
            request = "DELETE FROM RDV where NumeroRDV = @numeroRDV";
            command = new SqlCommand(request, DataBase.Connection, transaction);
            command.Parameters.Add(new SqlParameter("@numeroRDV", numeroRdv));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public bool Update()
        {
            string request = "UPDATE RDV SET DateRDV = @dateRDV, HeureRDV=@heureRdv";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@dateRDV", dateRDV));
            command.Parameters.Add(new SqlParameter("@heureRDV", heureRDV));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static List<RendezVous> SearchRDV(string search)
        {

            List<RendezVous> RDVs = new List<RendezVous>();
            string request = "SELECT NumeroRDV, DateRDV, HeureRDV, CodeMedecin, CodePatient FROM RDV WHERE " +
                "NumeroRDV like @search OR DateRDV like @search OR HeureRDV like @search OR CodePatient like @search OR CodePatient like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                RendezVous rdv = new RendezVous
                {
                    numeroRdv = reader.GetInt32(0),
                    dateRDV = reader.GetString(1),
                    heureRDV = reader.GetString(2),
                    CodeMedecin = reader.GetString(3),
                    CodePatient = reader.GetString(4),
                };
                RDVs.Add(rdv);
            }
            reader.Close();
            command.Dispose();

            request = "deuxième requete";
            command = new SqlCommand(request, DataBase.Connection);


            DataBase.Connection.Close();
            return RDVs;
        }

        public static List<RendezVous> GetRDV()
        {
            List<RendezVous> liste = new List<RendezVous>();
            request = "SELECT NumeroRDV, DateRDV, HeureRDV, CodeMedecin, CodePatient FROM RDV ORDER BY NumeroRDV DESC";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                RendezVous e = new RendezVous
                {
                    numeroRdv = reader.GetInt32(0),
                    dateRDV = reader.GetString(1),
                    heureRDV = reader.GetString(2),
                    codeMedecin = reader.GetString(3),
                    codePatient = reader.GetString(4),
                };
                liste.Add(e);
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return liste;
        }

        public static List<RendezVous> GetList()
        {
            return RendezVous.GetRDV();
        }
    }
}
