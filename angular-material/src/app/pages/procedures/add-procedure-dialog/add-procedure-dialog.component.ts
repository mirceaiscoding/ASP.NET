import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';

@Component({
  selector: 'app-add-procedure-dialog',
  templateUrl: './add-procedure-dialog.component.html',
  styleUrls: ['./add-procedure-dialog.component.css']
})
export class AddProcedureDialogComponent implements OnInit {

  numbersOnlyRegx = "^[0-9]*";

  form = new FormGroup({
    procedureName: new FormControl('', [Validators.required]),
    cost: new FormControl('', [Validators.required, Validators.pattern(this.numbersOnlyRegx)]),
  }, {});

  constructor(
    private dialogRef: MatDialogRef<AddProcedureDialogComponent>,
    private adminInformationsServie: AdminInformationsService,
    @Inject(MAT_DIALOG_DATA) data) {
  }

  ngOnInit() {
  }

  save() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    }
  }

  close() {
    this.dialogRef.close();
  }

}
