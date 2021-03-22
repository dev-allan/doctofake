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
    public class GestionDesMedecinViewModel : ViewModelBase
    {
        private GestionDesMedecins _mainWindow;

        private Medecin medecin;
        public Medecin Medecin { get => medecin; set { medecin = value; if (value != null) RaiseAllChanged(); } }
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string Date { get; set; }
        public string Specialite { get; set; }
        public ICommand NouveauForm { get; set; }
        public ICommand RechercheMedecin { get; set; }
        public ICommand AjouterMedecin { get; set; }
        public ICommand ModifierMedecin { get; set; }
        public ICommand SupprimerMedecin { get; set; }
        public ObservableCollection<Medecin> Medecins { get; set; }

        public GestionDesMedecinViewModel(GestionDesMedecins mainWindow)
        {
            Medecin = new Medecin();
            NouveauForm= new RelayCommand(ActionNouveauForm);
            RechercheMedecin = new RelayCommand(ActionRechercheMedecin);
            AjouterMedecin = new RelayCommand(ActionAjouterMedecin);
            ModifierMedecin = new RelayCommand(ActionModifierMedecin);
            SupprimerMedecin = new RelayCommand(ActionSupprimerMedecin);
            Medecins = new ObservableCollection<Medecin>(Medecin.GetMedecin());

            _mainWindow = mainWindow;
        }

        public void ActionNouveauForm()
        {
            Code = "";
            Nom = "";
            Tel = "";
            Date = "";
            Specialite = "";
            RaisePropertyChanged("Code");
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Tel");
            RaisePropertyChanged("Date");
            RaisePropertyChanged("Specialite");

        }        
        
        public void ActionRechercheMedecin()
        {
            /*Medecins = new ObservableCollection<Medecin>(Medecin.SearchMedecin(Code));
            Nom = "Coucou";
            Tel = "";
            Date = "";
            Specialite = "";
            */
            MessageBox.Show("Fonctionnalité à venir");

        }

        public void ActionAjouterMedecin()
        {
            if(Medecin.Save(Code, Nom, Tel, Specialite) && Code != "" && Nom != "" && Tel != "" && Specialite != "")
                MessageBox.Show("Docteur " + Nom + " spécialisé en " + Specialite + " ajouté avec le code " + Code);
            else
                MessageBox.Show("Erreur lors de l'ajout");
        }

        public void ActionModifierMedecin()
        {
            if(Medecin.Update(Nom, Tel, Specialite, Code))
                MessageBox.Show("Medecin Modifié");
            else
                MessageBox.Show("Erreur");
        }

        public void ActionSupprimerMedecin()
        {
            if(Medecin.Delete(Code))
                MessageBox.Show("Medecin Supprimé");
            else
                MessageBox.Show("Erreur lors de la suppression");
        }

        private void RaiseAllChanged()
        {
            RaisePropertyChanged("Code");
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Tel");
            RaisePropertyChanged("Date");
            RaisePropertyChanged("Specialite");
        }
    }
}
