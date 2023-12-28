// import { ComponentFixture, TestBed } from '@angular/core/testing';

// import { InvestimentSimulatorComponent } from './investiment-simulator.component';

// describe('InvestimentSimulatorComponent', () => {
//   let component: InvestimentSimulatorComponent;
//   let fixture: ComponentFixture<InvestimentSimulatorComponent>;

//   beforeEach(async () => {
//     await TestBed.configureTestingModule({
//       declarations: [InvestimentSimulatorComponent]
//     })
//     .compileComponents();
    
//     fixture = TestBed.createComponent(InvestimentSimulatorComponent);
//     component = fixture.componentInstance;
//     fixture.detectChanges();
//   });

//   it('should create', () => {
//     expect(component).toBeTruthy();
//   });
// });


import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { InvestimentSimulatorComponent } from './investiment-simulator.component';
import { InvestimentService } from '../../services/investiment.service';
import { of } from 'rxjs';

describe('InvestimentSimulatorComponent', () => {
  let component: InvestimentSimulatorComponent;
  let fixture: ComponentFixture<InvestimentSimulatorComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        declarations: [InvestimentSimulatorComponent],
        imports: [ReactiveFormsModule, HttpClientModule],
        providers: [InvestimentService, FormBuilder],
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestimentSimulatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('deve inicializar formGroup com valores iniciais', () => {
    expect(component.formGroup).toBeDefined();
    expect(component.formGroup.get('initialValue')?.value).toEqual('');
    expect(component.formGroup.get('rescueMonths')?.value).toEqual('');
  });

  it('não deve enviar o formulário se for inválido', () => {
    const mockData = { FinalValue: 0, FinalValueWithTaxes: 1 };
    spyOn(component.investimentService, 'CalculateCdbInvestiment').and.returnValue(of(mockData));
    component.onSubmit();
    expect(component.cdbInvestimentReturn).toBeUndefined();
  });

  it('deve enviar o formulário e definir cdbInvestimentReturn em caso de sucesso', () => {
    const mockData = { FinalValue: 1000, FinalValueWithTaxes: 900 };
    spyOn(component.investimentService, 'CalculateCdbInvestiment').and.returnValue(of(mockData));

    component.formGroup.patchValue({ initialValue: 1000, rescueMonths: 12 });
    component.onSubmit();

    expect(component.cdbInvestimentReturn).toEqual(mockData);
    expect(component.simulationSucess).toBeTrue();
  });
});
