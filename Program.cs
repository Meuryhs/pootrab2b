using System;

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            try
            {
                Console.Write("Digite o primeiro número: ");
                int numero1 = int.Parse(Console.ReadLine());

                Console.Write("Digite o segundo número: ");
                int numero2 = int.Parse(Console.ReadLine());

                int resultado = numero1 / numero2;
                Console.WriteLine($"Resultado: {resultado}");

                continuar = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Valor inválido. Digite um número inteiro.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Erro: Não é possível dividir por zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}