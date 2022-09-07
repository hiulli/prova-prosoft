import { Component, OnInit } from '@angular/core';
import { resultadoModel } from 'src/app/modelos/resultado.model';
import { ServicoService } from 'src/app/Servicos/servico.service';

@Component({
  selector: 'app-comparativo',
  templateUrl: './comparativo.component.html',
  styleUrls: ['./comparativo.component.scss'],
  providers: [ServicoService]
})
export class ComparativoComponent implements OnInit {
  displayedColumns: string[] = ['idLogNFeProcessada', 'idNFeProcessada', 'campo', 'valorAntigo', 'valorNovo'];
  logs: any[] = [];
  constructor(private servico: ServicoService) { }

  ngOnInit(): void {
    this
      .servico
      .obtemComparativo()
      .subscribe((resultado: resultadoModel) => {
        if (resultado.sucesso) {
          console.log(resultado);
          this.logs = resultado.dado;
        }
      });
  }
}
