using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_AF.Modele.BDD
{
    /// <summary>
    /// Classe faisant le lien entre la base SQL et les classes du projet, qui doivent hériter de cette classe.
    /// </summary>
    public abstract class TableSql
    {
        public abstract string NomTable { get; }
        public abstract string Prefixtable { get; }

        public TableSql()
        {
        }

        /// <summary>
        /// Retourne une instance de T ayant pour paramètres les valeurs associées à l'id dans la base SQL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public T ReadTable<T>(string table, int id) where T : class, new()
        {
            try
            {
                T result = default(T);
                using (SqlCommand cmd = new SqlCommand("select * from [GEN_AF_EIA117].[dbo]." + table + " where p_id=" + id, Sql.connexion))
                {
                    ////Creation de la dependance et association à Sqlcommand
                    //SqlDependency dependency = new SqlDependency(Sql.cmd);
                    ////Souscription aux evenements de SqlDependency
                    //dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);

                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = ReflectPropertyInfo.ReflectType<T>(reader);
                        }
                        reader.Close();
                    }

                }
                return result;
            }

            catch (Exception ex)
            {
                throw;
            }
        }



        /// <summary>
        /// Méthode qui retourne les id présents dans la table SQL passée en paramètre
        /// </summary>
        /// <typeparam name="ElementSql"></typeparam>
        /// <param name="table"></param>
        /// <param name="prefixtable"></param>
        /// <returns></returns>
        //public static List<int> GetIds(TableSql e)
        public List<int> GetIds()
        {          
            string table, prefixtable;
            table = this.NomTable;
            prefixtable = this.Prefixtable;
                   
            List<int> result = new List<int>();
            using (SqlCommand cmd = new SqlCommand("select " + prefixtable + "id from [GEN_AF_EIA117].[dbo]." + table, Sql.connexion))
            {
                cmd.CommandType = CommandType.Text;
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0));
                        }
                    }
                    reader.Close();
                }
            }
            return result;
        }
    }
}
