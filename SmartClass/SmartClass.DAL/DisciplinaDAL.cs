using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class DisciplinaDAL
    {
        public List<Disciplina> ListarDisciplinas(String pConnectionString)
        {
            List<Disciplina> lstDisciplinas = new List<Disciplina>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM DISCIPLINA";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Disciplina info = new Disciplina();
                    info.CdDisciplina = int.Parse(dr["cd_disciplina"].ToString());
                    info.DsDisciplina = dr["ds_disciplina"].ToString();
                    lstDisciplinas.Add(info);
                }
                conn.Close();
            }
            return lstDisciplinas;

        }

    }
}
