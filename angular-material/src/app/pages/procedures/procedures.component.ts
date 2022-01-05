import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ProcedureDTO } from 'src/app/interfaces/procedure-dto';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';
import { AuthService } from 'src/app/services/auth.service';
import { PublicInformationsService } from 'src/app/services/public-informations.service';
import { AddProcedureDialogComponent } from './add-procedure-dialog/add-procedure-dialog.component';

@Component({
  selector: 'app-procedures',
  templateUrl: './procedures.component.html',
  styleUrls: ['./procedures.component.css']
})
export class ProceduresComponent implements OnInit {

  currency = "RON";

  role = "";

  procedures: ProcedureDTO[] = [];

  constructor(
    public publicInformationsService: PublicInformationsService,
     public authService: AuthService,
     public adminInformationsService: AdminInformationsService,
     public dialog: MatDialog) { }

  ngOnInit(): void {
    this.publicInformationsService.getAllProcedures().subscribe((response: any) => {
      this.procedures = response;
      console.log("Procedures", this.procedures);
    });
    this.role = this.authService.getRole();
  }

  addProcedure() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.data = {
    };

    const dialogRef = this.dialog.open(AddProcedureDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(
      data => {
        if (data) {
          console.log("Dialog output:", data);
          this.adminInformationsService.addProcedure(data).subscribe((procedure: any) => {
            this.procedures.push(procedure);
          });
        }
      }
    );
  }

  delete(procedureId: number) {
    this.adminInformationsService.deleteProcedure(procedureId).subscribe((response: any) => {
      if (response === true) {
        this.procedures = this.procedures.filter(x => x.id != procedureId)
      }
    })
  }

  updateCurrency(event: MatSlideToggleChange) {
    if (event.checked == true) {
      this.currency = "EUR";
    } else {
      this.currency = "RON";
    }
    console.log("Currency", this.currency);
  }

}
