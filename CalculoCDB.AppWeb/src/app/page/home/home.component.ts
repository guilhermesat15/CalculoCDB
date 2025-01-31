import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { CalculadorCDB } from '../../model/calculadorCDB';
import { CalculadorCDBService } from '../../service/calculador-cdb.service';



@Component({
  selector: 'app-home',
  standalone: false,
  
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  public resultadoBruto: number | undefined = 0.0;
  public resultadoLiquido: number | undefined = 0.0;
  public valorInicial: string | undefined;
  public quantidadeMeses: number | undefined;
  public calculoForm: any;
  isFormValid = false;
  areCredentialsInvalid = false;
  public calculadorCDB: CalculadorCDB | undefined;

  constructor(private formBuilder: FormBuilder, private calculadorCDBService: CalculadorCDBService) { }

  ngOnInit(): void {
    this.calculoForm = this.formBuilder.group({
      quantidadeMeses: ['', [Validators.required, Validators.min(2), Validators.max(999999999), Validators.pattern("^[0-9]*$")]],
      valorInicial: ['', [Validators.required, Validators.min(1), Validators.max(999999999)]]
    });
  }

  submitForm(): void {
    if (this.calculoForm?.valid) {      

      this.calcularCDB(new CalculadorCDB(parseInt(this.calculoForm.value["quantidadeMeses"]), this.convertValorMonetario(this.calculoForm.value["valorInicial"])));
      this.isFormValid = false;
    }
    else {
      this.isFormValid = true;
    }

  }
    
  private calcularCDB(formData: CalculadorCDB) {
     
    this.calculadorCDBService.calcularCDB(formData).subscribe(
      data => {
        this.resultadoBruto = (data as any).resultadoBruto.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
        this.resultadoLiquido = (data as any).resultadoLiquido.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
      });
  }

  private convertValorMonetario(valorInicial:string) : number{
    var valorSplit = valorInicial.split(',');
    var valorSplit00 = valorSplit?.at(0)?.replace(".", "");
    var valorSplit01 = valorSplit?.at(1);
    var valorInicialCalculo = valorSplit00 + "." + valorSplit01;
    let valorInicialCalculoConvert: number = parseFloat(valorInicialCalculo);
    return valorInicialCalculoConvert;
  }
 
}
