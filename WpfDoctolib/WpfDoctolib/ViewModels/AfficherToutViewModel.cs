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
    public class AfficherToutViewModel : ViewModelBase
    {
        public ObservableCollection<Medecin> Medecins { get; set; }

    }
}