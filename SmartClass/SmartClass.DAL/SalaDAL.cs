using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class SalaDAL
    {

        //Listar as salas - Get
        //listar os equipamentos da sala - Get
        //verificar disponibilidade de uma sala - Get
        //buscar os dados de uma sala - Get
        //alterar os equipamentos de uma sala - Put

        public List<Sala> ListarSalas()
        {
            //conectar com o banco
            //ler os dados dados do banco
            //armazenar numa lista
            //dai eu retorno a lista
            return new List<Sala>();
        }

        public List<Equipamento> ListarEquipamentos(int codSala)
        {
            return new List<Equipamento>();

        }

        public bool verificarDisponibilidade (int codSala, string horario)
        {
            return true;
        }

        public Sala getSala(int cdSala)
        {
            return new Sala();
        }

        public void cadastrarEquipamento (int codEquipamento, int codSala)
        {

        }

        public void excluirEquipamento (int codEquipamentoSala)
        {

        }
    }
} 
