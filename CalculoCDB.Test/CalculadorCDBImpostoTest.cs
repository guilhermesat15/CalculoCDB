using CalculoCDB.Service;

namespace CalculoCDB.Test;

[TestClass]
public class CalculadorCDBImpostoTest
{
    ICalculadorCDBService calculadorCDBService = new CalculadorCDBService();

    [TestInitialize]
    public void Setup()
    {
        calculadorCDBService = new CalculadorCDBService();
    }

    [TestMethod]
    public void Test_ValidacaoEntradaNegativa_QtdMeses()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.CalcularImposto(-1, 1000));
    }

    [TestMethod]
    public void Test_ValidacaoEntradaNegativa_ValorResultadoBruto()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.CalcularImposto(12, -1000));
    }

    [TestMethod]
    public void Test_ValidacaoIntervaloMeses()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.CalcularImposto(0, 1000));
    }

    [TestMethod]
    public void Test_ValidacaoValorResultadoBruto()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.CalcularImposto(12, 0));
    }

    [TestMethod]
    public void Test_CalculoImposto()
    {
        // Arrange
        double expectedImposto = 225; // Valor esperado para 22.5% de imposto
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante

        // Act
        double calculatedImposto = calculadorCDBService.CalcularImposto(6, 1000); // 6 meses e 1000 de valor

        // Assert
        Assert.AreEqual(expectedImposto, calculatedImposto, delta);
    }

    [TestMethod]
    public void Teste_Calcular_Imposto_TaxaImpostoCorreta()
    {
        // Arrange & Act
        double resultado = calculadorCDBService.CalcularImposto(6, 1000);

        // Assert
        double expectedImposto = 1000 * 0.225; // Imposto de 22.5%
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

    [TestMethod]
    public void Teste_Calcular_Imposto_ValorPositivo()
    {
        // Arrange & Act
        double resultado = calculadorCDBService.CalcularImposto(12, 1000);

        // Assert
        Assert.IsTrue(resultado >= 0);
    }

    [TestMethod]
    public void Teste_Calcular_Imposto_QtdMesesMenorQueDois()
    {
        Assert.ThrowsException<ArgumentException>(() => calculadorCDBService.CalcularImposto(1, 1000));
    }

    [TestMethod]
    public void Teste_Calcular_Imposto_TaxaAteSeisMeses()
    {
        // Arrange & Act
        double resultado = calculadorCDBService.CalcularImposto(6, 1000);

        // Assert
        double expectedImposto = 1000 * 0.225; // Imposto de 22.5%
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

    [TestMethod]
    public void Teste_Calcular_Imposto_TaxaAteDozeMeses()
    {
        double resultado = calculadorCDBService.CalcularImposto(12, 1000);

        double expectedImposto = 1000 * 0.20; // Imposto de 20%
        double delta = 0.001; // Margem de erro para comparação de valores de ponto flutuante
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

    [TestMethod]
    public void Teste_Calcular_Imposto_TaxaAteVinteQuatroMeses()
    {
        double resultado = calculadorCDBService.CalcularImposto(24, 1000);

        double expectedImposto = 1000 * 0.175;
        double delta = 0.001;
        Assert.AreEqual(expectedImposto, resultado, delta);
    }

    [TestMethod]
    public void Teste_Calcular_Imposto_TaxaAcimaVinteQuatroMeses()
    {
        double resultado = calculadorCDBService.CalcularImposto(36, 1000);

        double expectedImposto = 1000 * 0.15;
        double delta = 0.001;
        Assert.AreEqual(expectedImposto, resultado, delta);
    }
}
