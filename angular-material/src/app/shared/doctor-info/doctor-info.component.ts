import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DoctorDTO } from 'src/app/interfaces/doctor-dto';

@Component({
  selector: 'app-doctor-info',
  templateUrl: './doctor-info.component.html',
  styleUrls: ['./doctor-info.component.css']
})
export class DoctorInfoComponent implements OnInit {

  @Input() doctor:DoctorDTO = {
    id: -1,
    firstName: '',
    lastName: '',
    jobDescription: '',
    phoneNumber: ''
  };

  @Output() onSelectDoctor: EventEmitter<DoctorDTO> = new EventEmitter<DoctorDTO>();

  constructor() { }

  ngOnInit(): void {
  }

  selectDoctor(doctor: DoctorDTO)
  {
    this.onSelectDoctor.emit(doctor);
  }

  getImagePath(doctor: DoctorDTO): string
  {
    return "assets/" + (doctor.lastName + "_" + doctor.firstName + "_Photo").toUpperCase() + ".jpg";
  }

}
