import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaProcessamentoComponent } from './lista-processamento.component';

describe('ListaProcessamentoComponent', () => {
  let component: ListaProcessamentoComponent;
  let fixture: ComponentFixture<ListaProcessamentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaProcessamentoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaProcessamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
