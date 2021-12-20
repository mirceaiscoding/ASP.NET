import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DoctorInformationModel } from 'src/app/interfaces/doctor-information-model';

@Component({
  selector: 'app-doctor-info',
  templateUrl: './doctor-info.component.html',
  styleUrls: ['./doctor-info.component.css']
})
export class DoctorInfoComponent implements OnInit {

  @Input() doctor:DoctorInformationModel = {
    id: -1,
    firstName: '',
    lastName: '',
    jobDescription: '',
    phoneNumber: ''
  };

  @Output() onSelectDoctor: EventEmitter<DoctorInformationModel> = new EventEmitter<DoctorInformationModel>();

  constructor() { }

  ngOnInit(): void {
  }

  selectDoctor(doctor: DoctorInformationModel)
  {
    this.onSelectDoctor.emit(doctor);
  }

  getImagePath(doctor: DoctorInformationModel): string
  {
    return "assets/" + (doctor.lastName + "_" + doctor.firstName + "_Photo").toUpperCase() + ".jpg";
  }

}
