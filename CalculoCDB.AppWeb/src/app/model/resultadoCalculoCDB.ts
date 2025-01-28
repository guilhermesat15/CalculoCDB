export class ResultadoCalculadorCDB {

  resultadoBruto: number | undefined;
  resultadoLiquido: number | undefined;

  constructor(resultadoBruto: number, resultadoLiquido: number) {
    this.resultadoBruto = resultadoBruto;
    this.resultadoLiquido = resultadoLiquido;
  }
}
