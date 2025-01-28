namespace CalculoCDB.Service;

public interface ICalculadorCDBService 
{
    ResultadoCalculoCDB ExecutarCalculoCdb(int quantiddeMeses, double ValorInicial);
    double CalcularImposto(int quantiddeMeses, double valorResultadoBruto);
}
