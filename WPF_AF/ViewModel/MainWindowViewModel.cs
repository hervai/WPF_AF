using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPF_AF.Modele.BDD;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using WPF_AF.Common;
using WPF_AF.View;

namespace WPF_AF.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public static Sql sql = new Sql();
        ProjetView pv = new ProjetView();


        private Projet _projetActif;
        public Projet ProjetActif
        {

            get { return Projet.ProjetActif; }
            set
            {
                if (Projet.ProjetActif != value)
                {
                    Projet.ProjetActif = value;
                    _projetActif = Projet.ProjetActif;
                    OnPropertyChanged("ProjetActif");
                }
            }
        }

        #region Boutons de Commande
        private ICommand m_EquipementsCommand;
        public ICommand EquipementsCommand
        {
            get
            {
                return m_EquipementsCommand;
            }
            set
            {
                m_EquipementsCommand = value;
            }
        }

        private ICommand m_FonctionsCommand;
        public ICommand FonctionsCommand
        {
            get
            {
                return m_FonctionsCommand;
            }
            set
            {
                m_FonctionsCommand = value;
            }
        }

        private ICommand m_AlarmesCommand;
        public ICommand AlarmesCommand
        {
            get
            {
                return m_AlarmesCommand;
            }
            set
            {
                m_AlarmesCommand = value;
            }
        }

        private ICommand m_OpenCommand;
        public ICommand OpenCommand
        {
            get
            {
                return m_OpenCommand;
            }
            set
            {
                m_OpenCommand = value;
            }
        }

        private ICommand m_ExitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return m_ExitCommand;
            }
            set
            {
                m_ExitCommand = value;
            }
        }
        private object _selectedViewModel;

        public object SelectedViewModel

        {

            get { return _selectedViewModel; }

            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }

        }



        #endregion

        public MainWindowViewModel()
        {
            //Définition des commandes de l'interface
            EquipementsCommand = new RelayCommand(new Action<object>(NavigationEquipements));
            FonctionsCommand = new RelayCommand(new Action<object>(NavigationFonctions));
            AlarmesCommand = new RelayCommand(new Action<object>(NavigationAlarmes));
            OpenCommand = new RelayCommand(new Action<object>(Ouvrir));
            ExitCommand = new RelayCommand(new Action<object>(Quitter));

            //Initialisation du projet actif
            Projet.ProjetActif = new Projet();
            
            //Remplissage de la liste des projets
            Sql.GetProjets();

        }

        /// <summary>
        /// Détection des changements de valeur de propriété
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void Nouveau(object obj)
        {
            MessageBox.Show("Nouveau");
        }

        public void Ouvrir(object obj)

        {
            //Ouverture de la vue ProjetView en tant qu'enfant de MainWindow
            pv.Owner = App.Current.MainWindow;
            pv.Show();

        }

        public void Enregistrer(object obj)
        {
            MessageBox.Show("Enregistrer");
        }

        public void Quitter(object obj)
        {
            Application.Current.Shutdown();
        }

        public void NavigationEquipements(object obj)
        {
            SelectedViewModel = new EquipementsViewModel();

        }

        public void NavigationFonctions(object obj)
        {
            SelectedViewModel = new FonctionsViewModel();
        }

        public void NavigationAlarmes(object obj)
        {
            MessageBox.Show("NavigationAlarmes");
        }


    }
}
