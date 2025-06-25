using System;
using System.Collections.Generic;

class Competidor
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Modalidade { get; set; }

    public Competidor(string nome, int idade, string modalidade)
    {
        Nome = nome;
        Idade = idade;
        Modalidade = modalidade;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Idade: {Idade}, Modalidade: {Modalidade}";
    }
}

class Competicao
{
    public string Nome { get; set; }
    private List<Competidor> competidores = new List<Competidor>();

    public Competicao(string nome)
    {
        Nome = nome;
    }

    public void AdicionarCompetidor(Competidor competidor)
    {
        competidores.Add(competidor);
    }

    public void ListarCompetidores()
    {
        if (competidores.Count == 0)
        {
            Console.WriteLine("Nenhum competidor cadastrado nesta competição.");
            return;
        }

        Console.WriteLine($"Competidores da competição {Nome}:");
        for (int i = 0; i < competidores.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {competidores[i]}");
        }
    }

    public bool EditarCompetidor(int indice, string nome, int idade, string modalidade)
    {
        if (indice < 0 || indice >= competidores.Count)
        {
            return false;
        }

        competidores[indice].Nome = nome;
        competidores[indice].Idade = idade;
        competidores[indice].Modalidade = modalidade;
        return true;
    }

    public bool RemoverCompetidor(int indice)
    {
        if (indice < 0 || indice >= competidores.Count)
        {
            return false;
        }

        competidores.RemoveAt(indice);
        return true;
    }

    public int QuantidadeCompetidores()
    {
        return competidores.Count;
    }
}

class Program
{
    static Competicao competicaoAtual = null;

    static void Main(string[] args)
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1. Cadastrar nova competição");
            Console.WriteLine("2. Adicionar competidores à competição");
            Console.WriteLine("3. Listar competidores cadastrados");
            Console.WriteLine("4. Editar competidor");
            Console.WriteLine("5. Remover competidor");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarCompeticao();
                    break;
                case "2":
                    AdicionarCompetidor();
                    break;
                case "3":
                    ListarCompetidores();
                    break;
                case "4":
                    EditarCompetidor();
                    break;
                case "5":
                    RemoverCompetidor();
                    break;
                case "6":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarCompeticao()
    {
        Console.Write("\nDigite o nome da competição: ");
        string nome = Console.ReadLine();
        competicaoAtual = new Competicao(nome);
        Console.WriteLine($"Competição '{nome}' criada com sucesso!");
    }

    static void AdicionarCompetidor()
    {
        if (VerificarCompeticao()) return;

        Console.WriteLine("\nAdicionar novo competidor:");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Idade: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade))
        {
            Console.Write("Idade inválida. Digite novamente: ");
        }

        Console.Write("Modalidade: ");
        string modalidade = Console.ReadLine();

        Competidor novoCompetidor = new Competidor(nome, idade, modalidade);
        competicaoAtual.AdicionarCompetidor(novoCompetidor);

        Console.WriteLine("Competidor adicionado com sucesso!");
    }

    static void ListarCompetidores()
    {
        if (VerificarCompeticao()) return;

        competicaoAtual.ListarCompetidores();
    }

    static void EditarCompetidor()
    {
        if (VerificarCompeticao()) return;
        if (VerificarCompetidores()) return;

        competicaoAtual.ListarCompetidores();
        Console.Write("\nDigite o número do competidor que deseja editar: ");

        int indice;
        while (!int.TryParse(Console.ReadLine(), out indice) || indice < 1 || indice > competicaoAtual.QuantidadeCompetidores())
        {
            Console.Write("Número inválido. Digite novamente: ");
        }
        indice--;

        Console.WriteLine("\nDigite os novos dados:");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Idade: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade))
        {
            Console.Write("Idade inválida. Digite novamente: ");
        }

        Console.Write("Modalidade: ");
        string modalidade = Console.ReadLine();

        bool sucesso = competicaoAtual.EditarCompetidor(indice, nome, idade, modalidade);

        if (sucesso)
        {
            Console.WriteLine("Competidor editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro ao editar competidor.");
        }
    }

    static void RemoverCompetidor()
    {
        if (VerificarCompeticao()) return;
        if (VerificarCompetidores()) return;

        competicaoAtual.ListarCompetidores();
        Console.Write("\nDigite o número do competidor que deseja remover: ");

        int indice;
        while (!int.TryParse(Console.ReadLine(), out indice) || indice < 1 || indice > competicaoAtual.QuantidadeCompetidores())
        {
            Console.Write("Número inválido. Digite novamente: ");
        }
        indice--;

        bool sucesso = competicaoAtual.RemoverCompetidor(indice);

        if (sucesso)
        {
            Console.WriteLine("Competidor removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro ao remover competidor.");
        }
    }

    static bool VerificarCompeticao()
    {
        if (competicaoAtual == null)
        {
            Console.WriteLine("\nNenhuma competição cadastrada. Por favor, crie uma competição primeiro.");
            return true;
        }
        return false;
    }

    static bool VerificarCompetidores()
    {
        if (competicaoAtual.QuantidadeCompetidores() == 0)
        {
            Console.WriteLine("\nNenhum competidor cadastrado nesta competição.");
            return true;
        }
        return false;
    }
}