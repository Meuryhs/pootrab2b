using System;
using System.Collections.Generic;
using System.Linq;

class Produto
{
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
}

class Program
{
    static List<Produto> produtos = new List<Produto>();

    static void Main(string[] args)
    {
        bool executando = true;

        while (executando)
        {
            ExibirMenu();
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    RemoverProduto();
                    break;
                case "3":
                    PesquisarProduto();
                    break;
                case "4":
                    MostrarProdutoMenorValor();
                    break;
                case "5":
                    executando = false;
                    Console.WriteLine("Encerrando o programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Gerenciamento de Produtos ===");
        Console.WriteLine("1. Cadastrar produto");
        Console.WriteLine("2. Remover produto");
        Console.WriteLine("3. Pesquisar produto");
        Console.WriteLine("4. Mostrar produto com menor valor");
        Console.WriteLine("5. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void CadastrarProduto()
    {
        Console.Clear();
        Console.WriteLine("=== Cadastro de Produto ===");

        Console.Write("Descrição do produto: ");
        string descricao = Console.ReadLine();

        Console.Write("Valor do produto: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            Console.WriteLine("Valor inválido. O cadastro será cancelado.");
            return;
        }

        produtos.Add(new Produto { Descricao = descricao, Valor = valor });
        Console.WriteLine($"Produto '{descricao}' cadastrado com sucesso!");
    }

    static void RemoverProduto()
    {
        Console.Clear();
        Console.WriteLine("=== Remover Produto ===");

        Console.Write("Digite a descrição do produto a ser removido: ");
        string descricao = Console.ReadLine();

        var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));

        if (produto != null)
        {
            produtos.Remove(produto);
            Console.WriteLine($"Produto '{descricao}' removido com sucesso!");
        }
        else
        {
            Console.WriteLine($"Produto '{descricao}' não encontrado.");
        }
    }

    static void PesquisarProduto()
    {
        Console.Clear();
        Console.WriteLine("=== Pesquisar Produto ===");

        Console.Write("Digite a descrição do produto a ser pesquisado: ");
        string descricao = Console.ReadLine();

        var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));

        if (produto != null)
        {
            Console.WriteLine("\nProduto encontrado:");
            Console.WriteLine($"Descrição: {produto.Descricao}");
            Console.WriteLine($"Valor: {produto.Valor:C}");
        }
        else
        {
            Console.WriteLine($"Produto '{descricao}' não encontrado.");
        }
    }

    static void MostrarProdutoMenorValor()
    {
        Console.Clear();
        Console.WriteLine("=== Produto com Menor Valor ===");

        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        var produtoMenorValor = produtos.OrderBy(p => p.Valor).First();

        Console.WriteLine("\nProduto com menor valor:");
        Console.WriteLine($"Descrição: {produtoMenorValor.Descricao}");
        Console.WriteLine($"Valor: {produtoMenorValor.Valor:C}");
    }
}