import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogRef,
} from '@angular/material/dialog';
import { dialogconfirm } from '../DialogConfirm/dialogconfirm';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public hijosForm: FormGroup;
   
  public dataSource: Hijos[] = [];
  displayedColumns: String[] = [
    'idHijo',
    'name',
    'fechaNacimiento',
    'opciones',
  ];

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    @Inject(MAT_DIALOG_DATA) public trabajadordata: any,
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<dialogconfirm>
  ) {
    console.log('recibiendo datos del trabajador ', trabajadordata);

    this.hijosForm = new FormGroup({
      idhijo: new FormControl(''),
      nombrecompleto: new FormControl(''),
      fechaNac: new FormControl(''),
    });

    //temperaturas

    //hijos
    this.listarHijos();
    
  }
  listarHijos():void{
    this.http.get<Hijos[]>(this.baseUrl + 'hijos').subscribe(
      (result) => {
        this.dataSource = result;
        console.log(result);
      },
      (error) => console.error(error)
    );
  }
  editar(hijos: Hijos) {
    console.log('hijos editar,, ', hijos);

    this.hijosForm.setValue({
      idhijo: hijos.idhijo,
      nombrecompleto: hijos.nombrecompleto,
      fechaNac: hijos.fechaNac,
    });
  }
  borrarDialog(hijo: Hijos): void {
    const dialog = this.dialog.open(dialogconfirm, {
      maxWidth: '250px',
      width: '250px',
      data: hijo,
    });
    dialog.afterClosed().subscribe((result) => {
      console.log('resultado after close ' + result);
      this.http.get<Hijos[]>(this.baseUrl + 'hijos').subscribe(
        (result) => {
          this.dataSource = result;
          console.log(result);
        },
        (error) => console.error(error)
      );
    });
  }
   
  onNoClick(): void {
    this.dialogRef.close();
  }

  agregar():void{
    const { idhijo,nombrecompleto, fechaNac } = this.hijosForm.value

    const hijos:Hijos ={fechaNac,idhijo,nombrecompleto};


    this.http.post<Hijos[]>(this.baseUrl + 'hijos',hijos).subscribe(
      (result) => {
        // this.dataSource = result;
        this.listarHijos();
        console.log(result);
      },
      (error) => console.error(error)
    );  
  }

}

 

interface Hijos {
  idhijo: number;
  nombrecompleto: string;
  fechaNac: Date;
}
