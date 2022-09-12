import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FetchDataComponent } from '../hijo/fetch-data.component';
@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  public dataSource: Trabajador[] = [];
  displayedColumns: String[] = ['id', 'nombrescompletos', 'tipodocumento',
   'numerodoc', 'fechaNac','fechaIng','options' ];
   ELEMENT_DATA: Trabajador[] = [
    { id: 1,nombrescompletos: 'Juan'  ,  tipodocumento: 'dni'  , numerodoc:'12345678',fechaNac:new Date(),fechaIng: new Date() },
    { id: 2,nombrescompletos: 'Mateo'    ,  tipodocumento: 'dni'  , numerodoc:'12345678',fechaNac:new Date(),fechaIng: new Date() },
    { id: 3,nombrescompletos: 'Marco'   ,  tipodocumento: 'dni'  , numerodoc:'12345678',fechaNac:new Date(),fechaIng: new Date() },
    { id: 4,nombrescompletos: 'Lucas' ,  tipodocumento: 'dni'  , numerodoc:'12345678',fechaNac:new Date(),fechaIng: new Date() },
    { id: 5,nombrescompletos: 'Pedro'     ,  tipodocumento: 'dni'  , numerodoc:'12345678',fechaNac:new Date(),fechaIng: new Date() },
  ];   
   constructor(public dialog: MatDialog){
    this.dataSource = this.ELEMENT_DATA;
  }
  openDialog(trabajador:Trabajador): void {
     
    this.dialog.open(FetchDataComponent, {
      maxWidth: '850px',
      width: '850px',
      height: '550px',
      data: {
          trabajador
      }
       
    });
  }
}
export interface Trabajador {
  id: number;
  nombrescompletos: string;
  tipodocumento: string;
  numerodoc: string;
  fechaNac: Date;
  fechaIng: Date; 
}
