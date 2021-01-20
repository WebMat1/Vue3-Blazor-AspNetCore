using System;

namespace Guifaza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (Imovel.Status)
            {
                Imovel imovelMat = new Imovel();

                Imovel imovelGui = new Imovel();
            }
            else
                Console.WriteLine("Não tá ativo pra vc instancia issaquiiii...");

            //imovelMat.Nome = "Gui é bem legal... pena que não pode ver mulher...";
            //imovelGui.Nome = "EItaaa caralhoooo...";

            //Imovel.NomeStatic = "EitaBicho ???";

            //Console.WriteLine(imovelMat.Nome);
            //Console.WriteLine(Imovel.NomeStatic);

        }
    }
}
