class PagamentoCredito
{
    static void Main(string[] args)
    {
        LojaVirtual loja = new LojaVirtual();

        IPagamento cartao = new PagamentoCartaoCredito();
        loja.RealizarPagamento(cartao, 150.50m);

        IPagamento boleto = new PagamentoBoleto();
        loja.RealizarPagamento(boleto, 299.90m);
    }
}