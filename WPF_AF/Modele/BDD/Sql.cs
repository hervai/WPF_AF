using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_AF.Modele.BDD
{
    /// <summary>
    /// Classe qui représente la base de données SQL GEN_AF_EIA117
    /// </summary>
    public class Sql
    {
        //Ouverture de la connexion à la base SQL
        //Chaine de connexion "Base_eia117" définie dans App.config    
        public static string connextionstring = ConfigurationManager.ConnectionStrings["Base_eia117"].ToString();
        public static SqlConnection connexion = new SqlConnection(connextionstring);

        //Déclaration des tables de la bases en leur classe équivalente (ObservableCollection<T>)
        public static ObservableCollection<Projet> ListeProjets = new ObservableCollection<Projet>();
        public static ObservableCollection<Equipement> ListeEquipements = new ObservableCollection<Equipement>();

      
        public Sql()
        {
            try
            {

                connexion.Open();
                SqlDependency.Stop(connextionstring);
                SqlDependency.Start(connextionstring);

            }
            catch (Exception e)
            {

            }
        }
        

        /// <summary>
        /// Remplie la liste de projets à partir de la base SQL
        /// </summary>
        /// <param name="ListeProjets"></param>
        public static void GetProjets()
        {
            ListeProjets.Clear();
            //List<int> listeid = TableSql.GetIds(new Projet());
            List<int> listeid = new Projet().GetIds();
            foreach (int id in listeid)
            {
                ListeProjets.Add(new Projet(id));
            }
        }

        /// <summary>
        /// Remplie la liste des équipements à partir de la base SQL
        /// </summary>
        /// <param name="ListeEquipements"></param>
        public static void GetEquipements()
        {
            ListeEquipements.Clear();
            //List<int> listeid = TableSql.GetIds(new Projet());
            List<int> listeid = new Equipement().GetIds();
            foreach (int id in listeid)
            {
                Equipement e = new Equipement(id);
                
                ListeEquipements.Add(new Equipement(id));
            }
        }


    }
}

