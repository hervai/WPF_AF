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
    public class Equipement : ElementTableSql
    {
        //public new static string Table {get=> "equipements"; }
        //public new static string Prefixtable = "e_";
        public override string NomTable => "equipements";
        public override string Prefixtable => "e_";

        /// <summary>
        /// Champ "id"
        /// </summary>
        [DataField("e_id")]
        public int Id { get; set; }
        /// <summary>
        /// Champ "Tag"
        /// </summary>
        [DataField("e_tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Champ "description_fr"
        /// </summary>
        [DataField("e_description_fr_fr")]
        public string DescriptionFr { get; set; }

        /// <summary>
        /// Champ "description_en"
        /// </summary>
        [DataField("e_description_en_gb")]
        public string DescriptionEn { get; set; }


        /// <summary>
        /// Champ "projets_id"
        /// </summary>
        [DataField("e_fk_projets_id")]
        public int ProjetId { get; set; }


        public Projet Projet
        {
            get
            {
                Projet proj;
                proj = new Projet();
                foreach (Projet p in Sql.ListeProjets)
                {
                    if (p.Id == ProjetId)
                    {
                        proj = p;
                    }

                }
                return proj;
            }
            set
            {
                ProjetId = value.Id;
            }
        }



        public TypeEquipement TypeEquipement
        {
            get
            {
                TypeEquipement te;
                te = new TypeEquipement();
                foreach (TypeEquipement e in Sql.ListeTypeEquipements)
                {
                    if (e.Id == Id)
                    {
                        te = e;
                    }

                }
                return te;
            }
            set
            {
                Id = value.Id;
            }
        }

        public Equipement()
        {
            Tag = "";
            DescriptionFr = "A renseigner";
            DescriptionEn = "To complete";
            ProjetId = 0;
        }


        public Equipement(int id)
        {
            Id = id;
            Equipement e = this.ReadTable<Equipement>(NomTable, Id);
            Tag = e.Tag;
            DescriptionFr = e.Tag;
            DescriptionEn = e.DescriptionEn;
            ProjetId = e.ProjetId;
            e = null;
        }


    }
}