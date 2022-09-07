import { Component, OnInit } from '@angular/core';
import { ServicoService } from 'src/app/Servicos/servico.service';
import { resultadoModel } from '../../modelos/resultado.model';

@Component({
  selector: 'app-lista-processamento',
  templateUrl: './lista-processamento.component.html',
  styleUrls: ['./lista-processamento.component.scss'],
  providers: [ServicoService]
})
export class ListaProcessamentoComponent implements OnInit {
  
  displayedColumns: string[] = ['id', 'dataHoraFim', 'dataHoraInicio', 'idNotaFinal', 'idNotaInicial', 'quantidadeDeNotasProcessadas', 'quantidadeDeNotasAlteradas'];
  processamentos: any[] = [];

  constructor(private servico: ServicoService) { }

  ngOnInit(): void {
    this
      .servico
      .obtemTodosOsLogs()
      .subscribe((resultado: resultadoModel) => {
        if (resultado.sucesso) {
          console.log(resultado);
          this.processamentos = resultado.dado;
        }
      });
  }
}
