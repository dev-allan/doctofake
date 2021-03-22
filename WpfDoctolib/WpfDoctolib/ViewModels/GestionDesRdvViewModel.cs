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
    public class GestionDesRdvViewModel : ViewModelBase
    {
        private GestionDesRdv _mainWindow;
        private RendezVous rendezVous;
        public RendezVous RendezVous { get => rendezVous; set { rendezVous = value; if (value != null) RaiseAllChanged(); } }

        public string CodePatient { get; set; }
        public string CodeMedecin { get; set; }
        public string DateRDV { get; set; }
        public string HeureRDV { get; set; }

        public ICommand NouveauForm { get; set; }
        public ICommand AjouterRDV { get; set; }

        public GestionDesRdvViewModel(GestionDesRdv mainWindow)
        {
            RendezVous = new RendezVous();
            NouveauForm = new RelayCommand(ActionNouveauForm);
            AjouterRDV = new RelayCommand(ActionAjouterRDV);
            _mainWindow = mainWindow;
        }

        public void ActionNouveauForm()
        {
            CodePatient = "";
            CodeMedecin = "";
            HeureRDV = "";
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("CodeMedecin");
        }

        public void ActionAjouterRDV()
        {
            RendezVous.Save(CodePatient, CodeMedecin, DateRDV, HeureRDV);
            MessageBox.Show("Rendez-Vous ajouté");
        }

        private void RaiseAllChanged()
        {
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("CodeMedecin");
            RaisePropertyChanged("DateRDV");
            RaisePropertyChanged("HeureRDV");
        }
    }
}
