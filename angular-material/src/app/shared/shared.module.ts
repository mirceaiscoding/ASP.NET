import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorInfoComponent } from './doctor-info/doctor-info.component';
import { AppointmentsInfoTableComponent } from './appointments-info-table/appointments-info-table.component';


@NgModule({
  declarations: [
    DoctorInfoComponent,
    AppointmentsInfoTableComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    DoctorInfoComponent
  ]
})
export class SharedModule { }
