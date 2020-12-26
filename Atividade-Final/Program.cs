﻿using System;
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
                Menu(escolha, produtos);
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
                    Console.WriteLine($"Média: {prod.Media()}");
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
            Console.Write("Informe o código do produto: ");
            var codigo = Convert.ToInt32(Console.ReadLine());
            
            try
            {
                var s = prod.Where(x => x.Codigo == codigo).First();
                Console.WriteLine("Deseja Desconto ou um Acréscimo no preço: ");
                Console.WriteLine("Digite [ D ] para desconto ou [ A ] para acréscimo ");
                var resp = Console.ReadLine();
                Console.WriteLine("Informe o percentual: ");
                var percentual = Convert.ToInt32(Console.ReadLine());
                

                if (resp.ToLower() == "desconto" || resp.ToLower() == "d")
                {
                    //s.Preco -= (percentual * s.Preco);
                    s.Desconto(percentual);
                }
                else if (resp.ToLower() == "acrescimo" || resp.ToLower() == "acréscimo" || resp.ToLower() == "a")
                {

                    //s.Preco += (percentual * s.Preco);
                    s.Acrescimo(percentual);
                }
                else
                {
                    Console.WriteLine("opção inválida!");
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Código do produto inexistente");
            }

        }

        static void MediaProduto(Produto[] prod)
        {
            var total = 0.0;
            double count = 0.0;
            foreach (var item in prod)
            {
                if (item != null)
                {
                    total += item.Preco;
                    count++;
                }
            }

            Console.WriteLine($"Média dos Produtos: {total / count}");
        }

        static void ListagemProdutos(Produto[] prod)
        {
            foreach (var item in prod)
            {
                if (item != null)
                {
                    var propsInfo = item.GetType().GetProperties();
                    foreach (var info in propsInfo)
                    {
                        Console.Write($" {info.Name}: {info.GetValue(item)} ");
                    }
                    Console.Write($" Lucro: {item.Lucro()}\n");
                }

            }
        }
        static void Cadastrar(Produto[] prod)
        {

            var vazio = VetorPreenchido(prod);
            if (vazio)
            {
                for (int i = 0; i < prod.Length; i++)
                {
                    if (prod[i] == null)
                    {
                        prod[i] = new Produto();

                        Console.Write("\nInforme o Codigo do produto: ");
                        prod[i].Codigo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nInforme o Descricao do produto: ");
                        prod[i].Descricao = Console.ReadLine();

                        Console.Write("\nInforme o Preco do produto: ");
                        prod[i].Preco = Convert.ToDouble(Console.ReadLine());

                        Console.Write("\nInforme o Custo do produto: ");
                        prod[i].Custo = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nImpossível cadastar mais produtos!");
            }
        }
        static Boolean VetorPreenchido(Produto[] prod)
        {
            var vazio = false;
            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i] == null)
                {
                    vazio = true;
                }
            }
            return vazio;
        }
    }
}
