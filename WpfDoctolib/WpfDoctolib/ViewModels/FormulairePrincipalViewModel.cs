using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfDoctolib.Models;
using WpfDoctolib.Views;

namespace WpfDoctolib.ViewModels
{
    public class FormulairePrincipalViewModel : ViewModelBase
    {
        private FormulairePrincipalWindow _mainWindow;
        public ICommand GestionMedecin { get; set; }
        public ICommand GestionPatient { get; set; }
        public ICommand GestionRendezVous { get; set; }
        public ICommand AfficherTout { get; set; }
        public ICommand RechercheRDVParDate { get; set; }
        public ICommand AfficherRDVPatient { get; set; }

        public FormulairePrincipalViewModel(FormulairePrincipalWindow mainWindow)
        {
            GestionMedecin = new RelayCommand(ActionGestionMedecin);
            GestionPatient = new RelayCommand(ActionGestionPatient);
            GestionRendezVous = new RelayCommand(ActionGestionRendezVous);
            AfficherTout = new RelayCommand(ActionAfficherTout);

            _mainWindow = mainWindow;
        }

        public void ActionGestionMedecin()
        {
            GestionDesMedecins a = new GestionDesMedecins();
            a.Show();
        }

        public void ActionGestionPatient()
        {
            GestionDesPatients a = new GestionDesPatients();
            a.Show();
        }

        public void ActionGestionRendezVous()
        {
            GestionDesRdv a = new GestionDesRdv();
            a.Show();
        }

        public void ActionAfficherTout()
        {
            AfficherTout a = new AfficherTout();
            a.Show();
        }
    }
}
