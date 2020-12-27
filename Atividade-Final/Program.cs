using System;
using System.Linq;

namespace Atividade_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtos = new Produto[3];

            var sair = 1;
            string escolha;


            while (sair != 0)
            {
                Opcoes();
                escolha = Console.ReadLine();
                Menu(escolha, produtos);
                Console.Write("\ndigite [ 0 ] para sair ou [ 1 ] para voltar ao menu: ");
                sair = Convert.ToInt32(Console.ReadLine());
            }

        }

        static void Opcoes()
        {
            Console.WriteLine("\n#########################");
            Console.WriteLine("Menu");
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
                    Console.WriteLine($"\n Média de preço dos Produtos {prod.Media()}");
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

        static void Atualizar(Produto[] prod)
        {
            Console.WriteLine("\nLista de Produtos para ser Atualizado");
            ListagemProdutos(prod);

            if (prod[0] != null)
            {
                Console.Write("\nInforme o código do produto: ");
                var codigo = Convert.ToInt32(Console.ReadLine());
                var percentual = 0.0;

                var vetorPreechido = prod.Where(x => x != null);
                var produto = vetorPreechido.FirstOrDefault(x => x.Codigo == codigo);
               

                if (produto != null)
                {
                    Console.WriteLine("\nDeseja Desconto ou um Acréscimo no preço: ");
                    Console.Write("Digite [ D ] para desconto ou [ A ] para acréscimo:  ");
                    var resp = Console.ReadLine();

                    if (resp.ToLower() == "desconto" || resp.ToLower() == "d")
                    {
                        Console.Write("\nInforme o percentual de Desconto: ");
                        percentual = Convert.ToInt32(Console.ReadLine());
                        produto.Desconto(percentual);
                        Console.WriteLine("\nProduto Atualizado com Sucesso ");

                    }
                    else if (resp.ToLower() == "acrescimo" || resp.ToLower() == "acréscimo" || resp.ToLower() == "a")
                    {
                        Console.Write("\nInforme o percentual de Acréscimo: ");
                        percentual = Convert.ToInt32(Console.ReadLine());
                        produto.Acrescimo(percentual);
                        Console.WriteLine("\nProduto Atualizado com Sucesso ");
                    }
                    else
                        Console.WriteLine("\nopção inválida!");


                }
                else
                    Console.WriteLine("Código do produto inexistente");
                

            }
            else
                Console.WriteLine("Nenhum produto cadastrado!");
        }


        static void ListagemProdutos(Produto[] prod)
        {
            var vetorPreenchido = prod.Where(x => x != null).ToArray();
            
            if (vetorPreenchido.Length > 0)
            {
                foreach (var item in vetorPreenchido)
                {
                    var propsInfo = item.GetType().GetProperties();
                    foreach (var info in propsInfo)
                    {
                        Console.Write($" {info.Name}: {info.GetValue(item)} ");
                    }
                    Console.Write($" Lucro: {item.Lucro()}\n");
                }
            }
            else
                Console.WriteLine("nenhum item cadastrado!");

        }
        static void Cadastrar(Produto[] prod)
        {
    
            var posicoesPreenchidas = prod.Where(x => x != null).ToArray();
            if (posicoesPreenchidas.Length < prod.Length)
            {
                Console.Write("\nInforme o Codigo do produto: ");
                var codigo = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nInforme a Descrição do produto: ");
                var descricao = Console.ReadLine().ToLower();

                Console.Write("\nInforme o Preco do produto: ");
                var preco = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nInforme o Custo do produto: ");
                var custo = Convert.ToDouble(Console.ReadLine());
                
                var posicoesNaoVazias = prod.Where(x => x != null).ToArray();
                var produtoIgual = posicoesNaoVazias.FirstOrDefault(x => x.Codigo == codigo || x.Descricao == descricao);


                if (produtoIgual == null)
                {
                    for (int i = 0; i < prod.Length; i++)
                    {
                        if (prod[i] == null)
                        {
                            prod[i] = new Produto
                            {
                                Codigo = codigo,
                                Descricao = descricao,
                                Preco = preco,
                                Custo = custo
                            };

                            Console.WriteLine("Produto Cadastrado com sucesso!");
                            break;
                        }
                    }
                }
                else
                    Console.Write("\nProduto já cadastrado no sistema! ");
            }
            else
                Console.WriteLine("\nImpossível cadastar mais produtos!");
        }
    }
}