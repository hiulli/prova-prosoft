import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListaProcessamentoComponent } from './componente/lista-processamento/lista-processamento.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { RelatorioComponent } from './componente/relatorio/relatorio.component';
import { ComparativoComponent } from './componente/comparativo/comparativo.component';

@NgModule({
  declarations: [
    AppComponent,
    ListaProcessamentoComponent,
    RelatorioComponent,
    ComparativoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
