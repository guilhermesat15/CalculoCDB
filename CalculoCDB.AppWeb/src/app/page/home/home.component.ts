import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CalculadorCDB } from '../../model/calculadorCDB';
import { CalculadorCDBService } from '../../service/calculador-cdb.service';
import { ResultadoCalculadorCDB } from '../../model/resultadoCalculoCDB';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-home',
  standalone: false,
  
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  public resultadoBruto: number | undefined = 0.0;
  public resultadoLiquido: number | undefined = 0.0;
  isFormValid = false;
  areCredentialsInvalid = false;
  resultadoCalculoCDB: ResultadoCalculadorCDB | undefined;

  constructor(private calculadorCDBService: CalculadorCDBService) { }

  ngOnInit() {
  }

  onSubmit(calculadorForm: NgForm) {
    if (!calculadorForm.valid) {
      this.isFormValid = true;
      this.areCredentialsInvalid = false;
      return;
    }
    else {
      this.isFormValid = false;
      this.areCredentialsInvalid = false;
    }

    this.calcularCDB(calculadorForm);
  }

  
  private calcularCDB(calculadorForm: NgForm) {

    const calculadorCDB = new CalculadorCDB(calculadorForm.value.quantidadeMeses, calculadorForm.value.valorInicial);

    var tmp = this.calculadorCDBService.calcularCDB(calculadorCDB).subscribe(
      data => {
        this.resultadoBruto = (data as any).resultadoBruto;
        this.resultadoLiquido = (data as any).resultadoLiquido;
      },
      err => {

      });
  }
 
}
