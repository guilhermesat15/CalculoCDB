using CalculoCDB.Service;

namespace CalculoCDB.Test;

[TestClass]
public class CalculadorCDBServiceTest
{
    ICalculadorCDBService calculadorCDBService = new CalculadorCDBService();

    [TestInitialize]
    public void Setup()
    {
        calculadorCDBService = new CalculadorCDBService();
    }


    [TestMethod]
    public void Teste_Execucao_CalculoCdb_ResultadosValidos()
    {
        int quantidadeMeses = 12;
        double valorInicial = 1000;

        var resultado = calculadorCDBService.ExecutarCalculoCdb(quantidadeMeses, valorInicial);

        Assert.IsNotNull(resultado);
        Assert.IsTrue(resultado.resultadoBruto > valorInicial);
        Assert.IsTrue(resultado.resultadoLiquido >= valorInicial);
    }

    [TestMethod]
    public void Teste_Execucao_CalculoCdb_ResultadosDiferentesParaDiferentesValoresIniciais()
    {
        // Arrange
        int quantidadeMeses = 12;
        double valorInicial1 = 1000;
        double valorInicial2 = 1500;

        // Act
        var resultado1 = calculadorCDBService.ExecutarCalculoCdb(quantidadeMeses, valorInicial1);
        var resultado2 = calculadorCDBService.ExecutarCalculoCdb(quantidadeMeses, valorInicial2);

        // Assert
        Assert.AreNotEqual(resultado1.resultadoBruto, resultado2.resultadoBruto);
    }

    [TestMethod]
    public void Teste_Execucao_CalculoCdb_QtdMesesNegativo()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.ExecutarCalculoCdb(-1, 1000));
    }

    [TestMethod]
    public void Teste_Execucao_CalculoCdb_ValorInicialNegativo()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.ExecutarCalculoCdb(12, -1000));
    }

    [TestMethod]
    public void Teste_Execucao_CalculoCdb_QtdMesesMenorQueDois()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.ExecutarCalculoCdb(1, 1000));
    }
}