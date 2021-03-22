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
    public class GestionDesPatientsViewModel : ViewModelBase
    {
        private GestionDesPatients _mainWindow;
        private Patient patient;
        public Patient Patient { get => patient; set { patient = value; if (value != null) RaiseAllChanged(); } }

        public string CodePatient { get; set; }
        public string NomPatient { get; set; }
        public string AdressePatient { get; set; }
        public string NaissancePatient { get; set; }
        public string SexePatient { get; set; }

        public ICommand NouveauForm { get; set; }
        public ICommand RechercherPatient { get; set; }
        public ICommand AjouterPatient { get; set; }
        public ICommand ModifierPatient{ get; set; }
        public ICommand SupprimerPatient{ get; set; }

        public GestionDesPatientsViewModel(GestionDesPatients mainWindow)
        {
            Patient = new Patient();
            NouveauForm = new RelayCommand(ActionNouveauForm);
            RechercherPatient = new RelayCommand(ActionRechercherPatient);
            AjouterPatient = new RelayCommand(ActionAjouterPatient);
            ModifierPatient = new RelayCommand(ActionModifierPatient);
            SupprimerPatient= new RelayCommand(ActionSupprimerPatient);
            _mainWindow = mainWindow;
        }

        public void ActionNouveauForm()
        {
            CodePatient = "";
            NomPatient = "";
            AdressePatient = "";
            SexePatient = "";
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("AdressePatient");
            RaisePropertyChanged("SexePatient");
        }

        public void ActionRechercherPatient()
        {
            MessageBox.Show("Fonctionnalité à venir");
        }

        public void ActionAjouterPatient()
        {
            Patient.Save(CodePatient, NomPatient, AdressePatient, NaissancePatient, SexePatient);
            if (SexePatient == "Masculin")
                MessageBox.Show("Monsieur " + NomPatient + " né le " + NaissancePatient + " a bien été ajouté avec le code " + CodePatient);
            else
                MessageBox.Show("Madame " + NomPatient + " née le " + NaissancePatient + " a bien été ajouté avec le code " + CodePatient);
        }

        public void ActionModifierPatient()
        {
            if (Patient.Update(NomPatient, AdressePatient, NaissancePatient, SexePatient, CodePatient))
                MessageBox.Show("Patient Modifié");
            else
                MessageBox.Show("Erreur lors de la saisie");
        }

        public void ActionSupprimerPatient()
        {
            if (Patient.Delete(CodePatient))
                MessageBox.Show("Patient Supprimé");
            else
                MessageBox.Show("Erreur lors de la saisie");
        }

        private void RaiseAllChanged()
        {
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("AdressePatient");
            RaisePropertyChanged("NaissancePatient");
            RaisePropertyChanged("SexePatient");
        }
    }
}
