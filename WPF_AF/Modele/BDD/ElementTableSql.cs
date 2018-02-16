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
    public abstract class ElementTableSql
    {
        public abstract string NomTable { get; }
        public abstract string Prefixtable { get; }

        public ElementTableSql()
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

        /// <summary>
        /// Supprimer la ligne 'id' de la table
        /// </summary>
        /// <param name="id">Id de la ligne à supprimer</param>
        public void SupprimerLigneSql(int id)
        {
            using (SqlCommand cmd = new SqlCommand("delete from [GEN_AF_EIA117].[dbo]." + NomTable + " where " + Prefixtable + "id=" + id, Sql.connexion))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
        }
    }
}
