using System;
using System.Collections.Generic;
using System.Linq;

class Aluno
{
    public string RA { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno(string ra, string nome, int idade)
    {
        RA = ra;
        Nome = nome;
        Idade = idade;
    }

    public override string ToString()
    {
        return $"RA: {RA}, Nome: {Nome}, Idade: {Idade}";
    }
}

class Program
{
    static List<Aluno> alunos = new List<Aluno>();

    static void Main(string[] args)
    {
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n--- Sistema de Gerenciamento de Alunos ---");
            Console.WriteLine("1. Cadastrar novo aluno");
            Console.WriteLine("2. Listar todos os alunos");
            Console.WriteLine("3. Alterar dados de um aluno");
            Console.WriteLine("4. Remover um aluno");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarAluno();
                    break;
                case "2":
                    ListarAlunos();
                    break;
                case "3":
                    AlterarAluno();
                    break;
                case "4":
                    RemoverAluno();
                    break;
                case "5":
                    executando = false;
                    Console.WriteLine("Encerrando o programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarAluno()
    {
        Console.WriteLine("\n--- Cadastro de Aluno ---");

        Console.Write("Digite o RA do aluno: ");
        string ra = Console.ReadLine();

        if (alunos.Any(a => a.RA == ra))
        {
            Console.WriteLine("Erro: Já existe um aluno com este RA.");
            return;
        }

        Console.Write("Digite o nome do aluno: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a idade do aluno: ");
        if (!int.TryParse(Console.ReadLine(), out int idade))
        {
            Console.WriteLine("Erro: Idade inválida.");
            return;
        }

        alunos.Add(new Aluno(ra, nome, idade));
        Console.WriteLine("Aluno cadastrado com sucesso!");
    }

    static void ListarAlunos()
    {
        Console.WriteLine("\n--- Lista de Alunos ---");

        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
            return;
        }

        foreach (var aluno in alunos)
        {
            Console.WriteLine(aluno);
        }
    }

    static void AlterarAluno()
    {
        Console.WriteLine("\n--- Alteração de Dados do Aluno ---");

        Console.Write("Digite o RA do aluno que deseja alterar: ");
        string ra = Console.ReadLine();

        Aluno aluno = alunos.FirstOrDefault(a => a.RA == ra);

        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado.");
            return;
        }

        Console.WriteLine($"Dados atuais: {aluno}");

        Console.Write("Digite o novo nome (deixe em branco para não alterar): ");
        string novoNome = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            aluno.Nome = novoNome;
        }

        Console.Write("Digite a nova idade (deixe em branco para não alterar): ");
        string novaIdadeStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novaIdadeStr) && int.TryParse(novaIdadeStr, out int novaIdade))
        {
            aluno.Idade = novaIdade;
        }

        Console.WriteLine("Dados do aluno atualizados com sucesso!");
    }

    static void RemoverAluno()
    {
        Console.WriteLine("\n--- Remoção de Aluno ---");

        Console.Write("Digite o RA do aluno que deseja remover: ");
        string ra = Console.ReadLine();

        Aluno aluno = alunos.FirstOrDefault(a => a.RA == ra);

        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado.");
            return;
        }

        alunos.Remove(aluno);
        Console.WriteLine("Aluno removido com sucesso!");
    }
}