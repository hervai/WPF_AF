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
    public class TypeEquipement : ElementTableSql
    {
        //public new static string Table {get=> "types_equipement"; }
        //public new static string Prefixtable = "te_";
        public override string NomTable => "types_equipement";
        public override string Prefixtable => "te_";

        /// <summary>
        /// Champ "id"
        /// </summary>
        [DataField("te_id")]
        public int Id { get; set; }
        /// <summary>
        /// Champ "Nom"
        /// </summary>
        [DataField("te_nom")]
        public string Nom { get; set; }

        /// <summary>
        /// Champ "prefix_api"
        /// </summary>
        [DataField("te_prefix_api")]
        public string PrefixApi { get; set; }

        /// <summary>
        /// Champ "bloc_api"
        /// </summary>
        [DataField("te_bloc_api")]
        public string BlocApi { get; set; }


        /// <summary>
        /// Champ "prefix_liste_es"
        /// </summary>
        [DataField("te_prefix_liste_es")]
        public string PrefixListeEs { get; set; }


        /// <summary>
        /// Champ "equipements_id"
        /// </summary>
        [DataField("te_fk_equipements_id")]
        public int EquipementId { get; set; }

        /// <summary>
        /// Champ "proprietes_equipements_id"
        /// </summary>
        [DataField("te_fk_proprietes_equipement_id")]
        public int ProprietesEquipementId { get; set; }

      


        public TypeEquipement()
        {
            Nom = "Nom à renseigner";
            PrefixApi = "Préfix API à renseigner";
            BlocApi = "Bloc API à renseigner";
            PrefixListeEs = "Prefixe dans liste d'ES à renseigner";

        }




        public TypeEquipement(int id)
        {
            Id = id;
            TypeEquipement te = this.ReadTable<TypeEquipement>(NomTable, id);
            Nom = te.Nom;
            PrefixApi = te.PrefixApi;
            BlocApi = te.BlocApi;
            PrefixListeEs = te.PrefixListeEs;
            te = null;
        }

    }
}