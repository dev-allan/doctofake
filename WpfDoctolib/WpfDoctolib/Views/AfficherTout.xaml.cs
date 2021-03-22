using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfDoctolib.ViewModels;
using WpfDoctolib.Models;

namespace WpfDoctolib.Views
{
    /// <summary>
    /// Logique d'interaction pour AfficherTout.xaml
    /// </summary>
    public partial class AfficherTout : Window
    {
        private static List<Medecin> medecins;
        private static List<Patient> patients;
        private static List<RendezVous> RDVs;
        public AfficherTout()
        {
            InitializeComponent();
            AfficherListeMedecin();
            AfficherListePatient();
            AffichezListeRendezVous();
            //DataContext = new AfficherToutViewModel(this);
        }
        void AfficherListeMedecin()
        {
            medecins = Medecin.GetList();
            ListeBoxMedecins.ItemsSource = medecins;
        }

        void AfficherListePatient()
        {
            patients = Patient.GetList();
            ListeBoxPatient.ItemsSource = patients;
        }
        void AffichezListeRendezVous()
        {
            RDVs = RendezVous.GetList();
            ListeBoxRDV.ItemsSource = RDVs;
        }
    }
}
