import { Component, OnInit } from '@angular/core';
import { resultadoModel } from 'src/app/modelos/resultado.model';
import { ServicoService } from 'src/app/Servicos/servico.service';

@Component({
  selector: 'app-relatorio',
  templateUrl: './relatorio.component.html',
  styleUrls: ['./relatorio.component.scss'],
  providers: [ServicoService]
})
export class RelatorioComponent implements OnInit {
  displayedColumns: string[] = ['marca', 'valor', 'imposto', 'mes'];
  dadosRelatorio: any[] =[];

  constructor(private servico: ServicoService) { }

  ngOnInit(): void {
    this
    .servico
    .obtemDadosRelatorio()
    .subscribe((resultado: resultadoModel) => {
      if (resultado.sucesso) {
        console.log(resultado);
        this.dadosRelatorio = resultado.dado;
      }
    });
  }
}
