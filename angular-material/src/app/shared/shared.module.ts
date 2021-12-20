import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorInfoComponent } from './doctor-info/doctor-info.component';


@NgModule({
  declarations: [
    DoctorInfoComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    DoctorInfoComponent
  ]
})
export class SharedModule { }
