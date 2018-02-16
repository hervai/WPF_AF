using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_AF.Modele.BDD;
using WPF_AF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPF_AF.Common;

namespace WPF_AF.View
{
    /// <summary>
    /// Logique d'interaction pour ViewProjet.xaml
    /// </summary>
    public partial class ProjetView : Window
    {

        public ProjetView()
        {
            InitializeComponent();



        }


        //Empêche la fermeture de la fenêtre pour pouvoir la réafficher plus tard
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
