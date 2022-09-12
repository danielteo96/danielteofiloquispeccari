import { Component, Inject } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'dialog-confirm',
  templateUrl: 'dialogconfirm.html',
})
export class dialogconfirm {
  constructor(
    public dialogRef: MatDialogRef<dialogconfirm>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    console.log('eliminar hijo:::> ', data);
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  eliminar(): void {
    this.http.delete<any>(this.baseUrl + 'hijos?idhijo='+this.data.idhijo).subscribe(
      (result) => {
        console.log('resultado servicio eliminar: ',result);
        this.dialogRef.close();
         
      },
      (error) => console.error(error)
    );
  }
}
