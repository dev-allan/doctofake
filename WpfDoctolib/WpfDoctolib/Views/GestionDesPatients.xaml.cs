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

namespace WpfDoctolib.Views
{
    
    public partial class GestionDesPatients : Window
    {
        public GestionDesPatients()
        {
            InitializeComponent();
            DataContext = new GestionDesPatientsViewModel(this);
        }

    }
}
