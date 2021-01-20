using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Guifaza
{
    public class Imovel
    {
        public string Nome { get; set; }
        public static bool Status { get; set; } = false;

        public int Qtd { get; set; }
        public double Valor { get; set; }
        public int Bau { get; set; }
        public int[,,] Entrada { get; set; }
        public int[,,] Saida { get; set; }
        public int[,,] BauLoc { get; set; }

        private string Segredo { get; set; }

        public override string ToString()
        {
            return Nome;
        }

    }
}
