import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvestimentService } from '../../services/investiment.service';
import { CdbInvestiment } from '../../models/cdb-investiment.interface';
import { CdbInvestimentReturn } from '../../models/cdb-investiment-return.interface';

@Component({
  selector: 'app-investiment-simulator',
  templateUrl: './investiment-simulator.component.html',
  styleUrl: './investiment-simulator.component.css'
})
export class InvestimentSimulatorComponent implements OnInit {

  formGroup!: FormGroup;
  cdbInvestiment!: CdbInvestiment;
  cdbInvestimentReturn!: CdbInvestimentReturn;
  simulationSucess: boolean = false;

  constructor(
    public investimentService: InvestimentService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(){
    this.formGroup = this.formBuilder.group({
      initialValue: ['', [Validators.required, Validators.min(1)]],
      rescueMonths: ['', [Validators.required, Validators.min(2), Validators.max(360)]]
    });
  }

  onSubmit(){
    if(this.formGroup.invalid) return;

    let { initialValue, rescueMonths } = this.formGroup.value;
    this.cdbInvestiment = { initialValue, rescueMonths } as CdbInvestiment;

    this.investimentService.CalculateCdbInvestiment(this.cdbInvestiment).subscribe({
      next: (data) => {
        this.cdbInvestimentReturn = data;
        this.simulationSucess = true;
      },
      error: e => {
        console.log(e)
        alert(`Erro ao tentar calcular!`);
      }
    });
  }

  onClear(){
    this.formGroup.reset();
    this.simulationSucess = false;
  }
}
