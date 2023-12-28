import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { InvestimentService } from './investiment.service';
import { CdbInvestimentReturn } from '../models/cdb-investiment-return.interface';
import { CdbInvestiment } from '../models/cdb-investiment.interface';

describe('InvestimentService', () => {
  let service: InvestimentService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [InvestimentService]
    });

    service = TestBed.inject(InvestimentService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('deve ter o content-type do header correto', () => {
    const httpOptions = service.httpOptions;
    expect(httpOptions.headers.get('Content-Type')).toEqual('application/json');
  });

  it('deve chamar o método CalculaCdbInvestiment com a URL correta', () => {
    const mockCdbInvestiment: CdbInvestiment = { initialValue: 1000, rescueMonths: 12 };
    const mockCdbInvestimentReturn: CdbInvestimentReturn = { FinalValue: 1200, FinalValueWithTaxes: 1100 };
  
    service.CalculateCdbInvestiment(mockCdbInvestiment).subscribe(response => {
      expect(response).toEqual(mockCdbInvestimentReturn);
    });
  
    const req = httpTestingController.expectOne(`${service.apiUrl}/InvestmentCdb/CalculateCDBReturns`);
    expect(req.request.method).toEqual('POST');
  
    req.flush(mockCdbInvestimentReturn);
  });
});
