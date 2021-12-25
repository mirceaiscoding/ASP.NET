import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';

@Component({
  selector: 'app-choose-time-interval-mat-dialog',
  templateUrl: './choose-time-interval-mat-dialog.component.html',
  styleUrls: ['./choose-time-interval-mat-dialog.component.css']
})
export class ChooseTimeIntervalMatDialogComponent implements OnInit {

  form = new FormGroup({
    newDate: new FormControl('', [Validators.required]),
  }, {});

  constructor(
      private dialogRef: MatDialogRef<ChooseTimeIntervalMatDialogComponent>,
      private adminInformationsServie: AdminInformationsService,
      @Inject(MAT_DIALOG_DATA) data){}

  ngOnInit() {}

  save() {
      if (this.form.valid)
      {
        // this.adminInformationsServie.
        this.dialogRef.close(this.form.value);
      }
  }

  close() {
      this.dialogRef.close();
  }

}
