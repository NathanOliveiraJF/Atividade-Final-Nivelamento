using System;
using System.Linq;

namespace Atividade_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtos = new Produto[100];
            var sair = 1;
            string escolha;


            while (sair != 0)
            {
                Opcoes();
                escolha = Console.ReadLine();

                Console.Write("\nsair digite 0 / 1 para continuar: ");
                sair = Convert.ToInt32(Console.ReadLine());
            }

        }

        static void Opcoes()
        {
            Console.WriteLine("\n#########################");
            Console.WriteLine("[ A ] Cadastrar Produto");
            Console.WriteLine("[ B ] Atualizar o preço de um produto");
            Console.WriteLine("[ C ] Imprimir o preço médio dos produtos");
            Console.WriteLine("[ D ] Imprimir listagem de produtos");
            Console.WriteLine("#########################");

            Console.Write("Selecione uma letra: ");
        }

        static void Menu(string op, Produto[] prod)
        {
            switch (op.ToUpper())
            {
                case "A":
                    Console.WriteLine("\nCadastramento de Produto");
                    Cadastrar(prod);
                    break;
                case "B":
                    Console.WriteLine("\nAtualização de Produto");
                    Atualizar(prod);
                    break;
                case "C":
                    MediaProduto(prod);
                    break;
                case "D":
                    Console.WriteLine("\nListagem dos Produtos");
                    ListagemProdutos(prod);
                    break;
                default:
                    Console.Write("\nOpção inválida!");
                    break;
            }
        }
    }
}
