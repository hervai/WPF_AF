using Common;
using Common.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WPF_AF.Modele.BDD
{
    /// <summary>
    /// Représente les éléments de la table projets de la base SQL
    /// </summary>
    public class Projet : ElementTableSql, INotifyPropertyChanged
    {

        public override string NomTable => "projets";
        public override string Prefixtable => "p_";

        /// <summary>
        /// Champ "id"
        /// </summary>
        private int _Id;
        [DataField("p_id")]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (value != _Id)
                {
                    _Id = value;
                    //this.DefineProjetById(value);
                    OnPropertyChanged(nameof(Id));

                }
            }
        }

        /// <summary>
        /// Champ "Nom"
        /// </summary>        
        private string _Nom;
        [DataField("p_nom")]
        public string Nom
        {
            get { return _Nom; }
            set
            {
                _Nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }



        private static Projet _ProjetActif;
        /// <summary>
        /// Champ static "ProjetActif"
        /// </summary>   
        public static Projet ProjetActif
        {
            get
            {
                return _ProjetActif;
            }
            set
            {
                if (_ProjetActif != value)
                {
                    _ProjetActif = value;
                    OnStaticPropertyChanged(nameof(ProjetActif));
                }
            }
        }


        #region Change Event
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

        /// <summary>
        /// Détection des changements de valeur de propriété static
        /// </summary>
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        protected static void OnStaticPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = StaticPropertyChanged;
            if (handler != null)
            {
                handler(typeof(Projet), new PropertyChangedEventArgs(PropertyName));
            }
        }

        #endregion


        public Projet()
        {
            Nom = "";
        }


        public Projet(int id)
        {
            Id = id;
            Nom = this.ReadTable<Projet>(NomTable, Id).Nom;
        }
        /// <summary>
        /// Définit le projet en cours à partir d'un id
        /// </summary>
        /// <param name="id"></param>
        public static void DefinirProjetCourant(int id)
        {
            Projet.ProjetActif.Id = id;
            Projet.ProjetActif.DefineProjetById(id);
        }

        public void DefineProjetById(int id)
        {
            this.Nom = this.ReadTable<Projet>(NomTable, id).Nom;
        }
    }
}
