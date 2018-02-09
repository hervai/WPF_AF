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

namespace WPF_AF.ViewModel
{
    public class ProjetViewModel
    {
        public ObservableCollection<Projet> Liste { get => Sql.ListeProjets; }
        private ICommand m_DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return m_DeleteCommand;
            }
            set
            {
                m_DeleteCommand = value;
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

        public ProjetViewModel()
        {
            DeleteCommand = new RelayCommand(new Action<object>(Supprimer));
            OpenCommand = new RelayCommand(new Action<object>(Ouvrir));
        }

        public void Supprimer(object obj) {
            MessageBox.Show("suppression");
           // Sql.ListeProjets.Remove(//A compléter);
        }

        public void Ouvrir(object obj)
        {
            MessageBox.Show("ouverture");
        }     
    }
}
