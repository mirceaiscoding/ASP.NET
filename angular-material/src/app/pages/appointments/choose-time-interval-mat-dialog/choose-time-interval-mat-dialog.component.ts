import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AppointmentDTO } from 'src/app/interfaces/appointment-dto';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';

@Component({
  selector: 'app-choose-time-interval-mat-dialog',
  templateUrl: './choose-time-interval-mat-dialog.component.html',
  styleUrls: ['./choose-time-interval-mat-dialog.component.css']
})
export class ChooseTimeIntervalMatDialogComponent implements OnInit {

  form = new FormGroup({
    newDate: new FormControl('', [Validators.required]),
    newTime: new FormControl('12:00'),
  }, {});

  appointment!: AppointmentDTO;

  constructor(
      private dialogRef: MatDialogRef<ChooseTimeIntervalMatDialogComponent>,
      private adminInformationsServie: AdminInformationsService,
      @Inject(MAT_DIALOG_DATA) data){
        this.appointment = data.appointment;
      }

  ngOnInit() {}

  save() {      
      if (this.form.valid) {
        this.adminInformationsServie.updateAppointmentTime(this.appointment, this.form.value['newDate'], this.form.value['newTime']).subscribe(response => {
          console.log(response);
          this.dialogRef.close(response);
        })
      }
  }

  close() {
      this.dialogRef.close();
  }

}
