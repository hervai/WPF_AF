using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_AF.Modele.BDD;

namespace WPF_AF.ViewModel
{
    public class EquipementsViewModel
    {


        public ObservableCollection<Equipement> ListeEquipements { get => Sql.ListeEquipements; }
        public ObservableCollection<TypeEquipement> ListeTypeEquipements { get => Sql.ListeTypeEquipements; }

        private TypeEquipement _currentSelection;
        public TypeEquipement CurrentSelection
        {
            get { return _currentSelection; }
            set
            {
                _currentSelection = value;
                OnPropertyChanged(nameof(CurrentSelection));
            }
        }

        public EquipementsViewModel()
        {
            //Définition des commandes de l'interface
            //EquipementsCommand = new RelayCommand(new Action<object>(NavigationEquipements));
            //FonctionsCommand = new RelayCommand(new Action<object>(NavigationFonctions));


            //Remplissage de la liste des équipements et types d'équipements
            Sql.GetEquipements();
            Sql.GetTypeEquipements();           

        }


        #region Gestionnaire d'événements
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
