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


namespace WPF_AF.Modele.BDD
{
    /// <summary>
    /// Représente les éléments de la table projets de la base SQL
    /// </summary>
    public class Projet : TableSql
    {
        //public new static string Table {get=> "projets"; }
        //public new static string Prefixtable = "p_";
        public override string NomTable => "projets";
        public override string Prefixtable => "p_";

        /// <summary>
        /// Champ "id"
        /// </summary>
        [DataField("p_id")]
        public int Id { get; set; }
        /// <summary>
        /// Champ "Nom"
        /// </summary>
        [DataField("p_nom")]
        public string Nom { get; set; }



        public Projet()
        {
            Nom = "";
        }


        public Projet(int id)
        {
            Id = id;
            Nom =this.ReadTable<Projet>("projets",Id).Nom;            
        }

        public void SupprimerProjet(Projet p)
        {
            //A rédiger
        }
    }
}
