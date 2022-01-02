import { formatDate } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { AppointmentDTO } from 'src/app/interfaces/appointment-dto';
import { AppoointmentPostModel } from 'src/app/interfaces/appoointment-post-model';
import { DoctorDTO } from 'src/app/interfaces/doctor-dto';
import { PacientDTO } from 'src/app/interfaces/pacient-dto';
import { ProcedureDTO } from 'src/app/interfaces/procedure-dto';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';

@Component({
  selector: 'app-add-appointment-mat-dialog',
  templateUrl: './add-appointment-mat-dialog.component.html',
  styleUrls: ['./add-appointment-mat-dialog.component.css']
})
export class AddAppointmentMatDialogComponent implements OnInit {

  startWithIdRegx = "(^#[0-9]{1,}:[a-zA-Z ]*)";

  form = new FormGroup({
    doctor: new FormControl('', [Validators.required, Validators.pattern(this.startWithIdRegx)]),
    pacient: new FormControl('', [Validators.required, Validators.pattern(this.startWithIdRegx)]),
    procedure: new FormControl('', [Validators.required, Validators.pattern(this.startWithIdRegx)]),
    date: new FormControl(new Date(), [Validators.required]),
    startTime: new FormControl('12:00', [Validators.required]),
    endTime: new FormControl('13:00', [Validators.required]),
  }, {});

  pacients: PacientDTO[] = [];
  procedures: ProcedureDTO[] = [];
  doctors: DoctorDTO[] = [];

  filteredDoctors!: Observable<DoctorDTO[]>;
  filteredPacients!: Observable<PacientDTO[]>;
  filteredProcedures!: Observable<ProcedureDTO[]>;

  constructor(
    private dialogRef: MatDialogRef<AddAppointmentMatDialogComponent>,
    private adminInformationsServie: AdminInformationsService,
    @Inject(MAT_DIALOG_DATA) data) {
    this.pacients = data.pacients;
    this.procedures = data.procedures;
    this.doctors = data.doctors;
  }

  findDoctor(val: string) {
    return this.doctors.filter(x => ("#" + x.id + ": " + x.lastName + " " + x.firstName).toLowerCase().includes(val.toLowerCase()));
  }

  findPacient(val: string) {
    return this.pacients.filter(x => ("#" + x.id + ": " + x.lastName + " " + x.firstName).toLowerCase().includes(val.toLowerCase()));
  }

  findProcedure(val: string) {
    return this.procedures.filter(x => ("#" + x.id + ": " + x.procedureName).toLowerCase().includes(val.toLowerCase()));
  }


  ngOnInit() {
    this.filteredDoctors = this.form.controls['doctor'].valueChanges.pipe(startWith(''), map(term => this.findDoctor(term)));
    this.filteredPacients = this.form.controls['pacient'].valueChanges.pipe(startWith(''), map(term => this.findPacient(term)));
    this.filteredProcedures = this.form.controls['procedure'].valueChanges.pipe(startWith(''), map(term => this.findProcedure(term)));
  }

  save() {
    if (this.form.valid) {
      var formattedDate = formatDate(this.form.controls['date'].value, "yyyy-MM-dd", "en-US");
      console.log(this.form.value);
      var pacient = this.form.controls['pacient'].value;
      var procedure = this.form.controls['procedure'].value;
      var doctor = this.form.controls['doctor'].value;

      var appointment: AppoointmentPostModel =
      {
        pacientId: parseInt(pacient.substr(1, pacient.indexOf(':'))),
        procedureId: parseInt(procedure.substr(1, procedure.indexOf(':'))),
        doctorId: parseInt(doctor.substr(1, doctor.indexOf(':'))),
        startTime: formattedDate + "T" + this.form.controls['startTime'].value,
        endTime: formattedDate + "T" + this.form.controls['endTime'].value,
      }
      this.adminInformationsServie.addAppointment(appointment).subscribe((response: any) => {
        console.log("Appointment Information", response);
        this.dialogRef.close(response);
      })
    }
  }

  close() {
    this.dialogRef.close();
  }
}
