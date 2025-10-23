using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDeBrinquedos.Models;

namespace LojaDeBrinquedos.Controllers
{
    public class BrinquedoExecucao
    {
        private static List<Brinquedo> listaDeBrinquedos;
        static BrinquedoExecucao()
        {
            listaDeBrinquedos = new List<Brinquedo>();
        }

        public static void AdicionarBrinquedo(Brinquedo novoBrinquedo)
        {
            listaDeBrinquedos.Add(novoBrinquedo);
        }

        public static void RemoverBrinquedo(Brinquedo brinquedoParaRemover)
        {
            listaDeBrinquedos.Remove(brinquedoParaRemover);
        }

        public static List<Brinquedo> ObterBrinquedos()
        {
            return listaDeBrinquedos;
        }

    }
}
