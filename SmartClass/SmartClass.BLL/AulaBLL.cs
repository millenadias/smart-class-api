using SmartClass.DAL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.BLL
{
    public class AulaBLL
    {
        AulaDAL dal = new AulaDAL();


        public List<Aula> ListarAulas(String pConnectionString)
        {
            return dal.ListarAulas(pConnectionString);
        }

        public List<Aula> ListarAulasProfessor(int pCdProfessor, String pConnectionString)
        {
            return dal.ListarAulasProfessor(pCdProfessor, pConnectionString);
        }

        public List<Aula> ListarAulasDiaProfessor(int pCdProfessor, String pConnectionString)
        {
            return dal.ListarAulasDiaProfessor(pCdProfessor, pConnectionString);

        }
        public Aula getAula(int CdAula, String pConnectionString)
        {
            return dal.getAula(CdAula, pConnectionString);
        }

        public void alterarAula(Aula aula, string pConnectionString)
        {
            dal.alterarAula(aula, pConnectionString);
        }

        public int cadastrarAula(Aula aula, String pConnectionString)
        {
            return dal.cadastrarAula(aula, pConnectionString);
        }

        public void cadastrarPreferenciasAula(int CdAula, List<int> equipamentos, String pConnectionString)
        {
            dal.cadastrarPreferenciasAula(CdAula, equipamentos, pConnectionString);
        }


        public void excluirAula(int CdAula, String pConnectionString)
        {
            dal.excluirAula(CdAula, pConnectionString);
        }

        public void excluirPreferenciaAula(int CdPreferenciaAula, String pConnectionString)
        {
            dal.excluirPreferenciaAula(CdPreferenciaAula, pConnectionString);
        }

        public bool ValidarAulaPermitida(int pCdSala, DateTime pDtIni, DateTime pDtFim, int pCdAula, String pConnectionString)
        {
            return dal.ValidarAulaPermitida(pCdSala, pDtIni, pDtFim, pCdAula, pConnectionString);
        }

        public List<int> ListarPreferencias(int pCdAula, String pConnectionString)
        {
            return dal.ListarPreferencias(pCdAula, pConnectionString);
        }
    }
}
