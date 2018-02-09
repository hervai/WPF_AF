using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using WPF_AF.Modele.BDD;
using System.Data;
using WPF_AF.View;

namespace WPF_AF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        public MainWindow()
        {
            InitializeComponent();

        }
               

        private void Window_Closed(object sender, EventArgs e)
        {
            //Suppression des dépendances de la base SQL
            SqlDependency.Stop(Sql.connextionstring);

            //Fermeture de la connexion à SQL
            Sql.connexion.Close();
        }

    }
}
