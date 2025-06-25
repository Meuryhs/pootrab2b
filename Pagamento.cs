
public interface IPagamento
{
    void ProcessarPagamento(decimal valor);
}

public class PagamentoCartaoCredito : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R${valor} processado no cartão de crédito.");
    }
}

public class PagamentoBoleto : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R${valor} processado via boleto bancário.");
    }
}

public class LojaVirtual
{
    public void RealizarPagamento(IPagamento metodo, decimal valor)
    {
        metodo.ProcessarPagamento(valor);
    }
}