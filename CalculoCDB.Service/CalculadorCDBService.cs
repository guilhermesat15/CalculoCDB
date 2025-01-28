namespace CalculoCDB.Service;

public class CalculadorCDBService : ICalculadorCDBService
{
    public ResultadoCalculoCDB ExecutarCalculoCdb(int quantiddeMeses, double ValorInicial)
    {
        if (ValorInicial <= 0)
        {
            throw new ArgumentException("O valor inicial deve ser um valor monetário positivo.");
        }

        if (quantiddeMeses <= 1)
        {
            throw new ArgumentException("O prazo em meses, deve ser maior que 1(um).");
        }

        var resultados = new List<double>();
        var valorResultadoBruto = 0.0;

        const double cdi = 0.009; 
        const double taxaBancoSobreCdi = 1.08;

        for (int i = 0; i < quantiddeMeses; i++)
        {
            var resultadoMesAnterior = (i == 0 && resultados.Count == 0) ? ValorInicial : resultados[i - 1] ;
            var resultadoMes = resultadoMesAnterior * (1 + (cdi * taxaBancoSobreCdi));
            
            resultados.Add(resultadoMes);
        }

        valorResultadoBruto = resultados[resultados.Count - 1];

        var lucro = valorResultadoBruto - ValorInicial;

        var valorImposto = CalcularImposto(quantiddeMeses, lucro);

        double valorResultadoLiquido = ValorInicial + (lucro - valorImposto);

        var result = new ResultadoCalculoCDB { resultadoBruto = resultados[resultados.Count - 1], resultadoLiquido = valorResultadoLiquido  };

        return result;
    }

    public double CalcularImposto(int quantiddeMeses, double valorResultadoBruto)
    {
        if (valorResultadoBruto <= 0)
        {
            throw new ArgumentException("O valor do resultado bruto deve ser monetário positivo.");
        }

        if (quantiddeMeses <= 1)
        {
            throw new ArgumentException("O prazo em meses, deve ser maior que 1.");
        }

        double valorImposto = 0.0;

        var taxasImposto = new Dictionary<int, double>
        {
            { 6, 0.225 },  // Até 6 meses: 22.5% de imposto
            { 12, 0.20 },  // Até 12 meses: 20% de imposto
            { 24, 0.175 }, // Até 24 meses: 17.5% de imposto
            { int.MaxValue, 0.15 } // Acima de 24 meses: 15% de imposto
        };

        double taxaImposto = taxasImposto.First(kv => quantiddeMeses <= kv.Key).Value;

        valorImposto = valorResultadoBruto * taxaImposto;

        return valorImposto;
    }
}
